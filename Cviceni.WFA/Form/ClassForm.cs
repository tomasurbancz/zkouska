using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

public partial class ClassForm : System.Windows.Forms.Form
{
    private ClassRepository _classRepository;
    private StudentRepository _studentRepository;
    private Guid _guid; 
    private CheckedListBox _studentsBox;
    private Label _studentsLabel;
        
    public ClassForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _classRepository = new ClassRepository(db);
        _studentRepository = new StudentRepository(db);
        _guid = guid;
        _studentsLabel = new Label
        {
            Left = 12,
            Top = 168,
            Width = 360,
            Text = "Žáci ve třídě:"
        };
        _studentsBox = new CheckedListBox
        {
            Left = 12,
            Top = 188,
            Width = 360,
            Height = 110,
            IntegralHeight = false
        };
        Controls.Add(_studentsLabel);
        Controls.Add(_studentsBox);
        kmenovaBox.Visible = false;
        if (_guid != Guid.Empty)
        {
            LoadData();
            create.Text = "Upravit";
        }
        else
        {
            LoadStudentsOptions(new List<Guid>());
            delete.Visible = false;
        }
        ReflowLayout();
        BringToFront();
    }

    private void ReflowLayout()
    {
        int relationTop = kmenovaBox.Visible ? kmenovaBox.Bottom : kmenovaCheck.Bottom;
        _studentsLabel.Top = relationTop + 12;
        _studentsLabel.Width = ClientSize.Width - 24;
        _studentsBox.Top = _studentsLabel.Bottom + 4;
        _studentsBox.Width = ClientSize.Width - 24;
        _studentsBox.Height = 110;
        create.Top = _studentsBox.Bottom + 20;
        delete.Top = create.Top;
        ClientSize = new Size(ClientSize.Width, create.Bottom + 20);
    }

    private async void LoadData()
    {
        ClassEntity classEntity = await _classRepository.GetById(_guid);
        rocnikBox.Text = classEntity.Year + "";
        kodBox.Text = classEntity.Code;
        kmenovaCheck.Checked = classEntity.RootClassRoom;
        if (classEntity.RootClassRoom)
        {
            kmenovaBox.Visible = true;
            kmenovaBox.Text = classEntity.RootClassRoomCode + "";
        }
        await LoadStudentsOptions(classEntity.Students.Select(student => student.Id).ToList());
    }

    private async Task LoadStudentsOptions(List<Guid> selectedStudentIds)
    {
        List<StudentEntity> students = await _studentRepository.GetAll();
        _studentsBox.Items.Clear();
        students.ForEach(student =>
        {
            int index = _studentsBox.Items.Add(new StudentOption(student.Id, $"{student.Name} ({student.Age})"));
            if (selectedStudentIds.Contains(student.Id))
            {
                _studentsBox.SetItemChecked(index, true);
            }
        });
    }


    private async void create_Click_1(object sender, EventArgs e)
    {
        int fYear = 0;
        bool root = false;
        int fRoot = -1;
        if (string.IsNullOrEmpty(kodBox.Text)) return;
        if (!int.TryParse(rocnikBox.Text, out fYear)) return;
        if (fYear <= 0) return;
        if (kmenovaCheck.Checked)
        {
            root = true;
            if(!int.TryParse(kmenovaBox.Text, out fRoot)) return;
        }
        ClassEntity entity = new ClassEntity();
        if (_guid != Guid.Empty)
        {
            entity = await _classRepository.GetById(_guid);
        }

        entity.Year = fYear;
        entity.RootClassRoom = root;
        entity.Code = kodBox.Text;
        entity.RootClassRoomCode = fRoot;
        
        if (_guid != Guid.Empty)
        {
            await _classRepository.Update(entity);
        }
        else
        {
            await _classRepository.Create(entity);
        }
        await SyncStudentsForClass(entity.Id);

        Close();
    }

    private void kmenovaCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (kmenovaCheck.Checked)
        {
            kmenovaBox.Visible = true;
        }
        else
        {
            kmenovaBox.Visible = false;
        }
        ReflowLayout();
    }

    private async void delete_Click(object sender, EventArgs e)
    {
        ClassEntity entity = await _classRepository.GetById(_guid);
        await _classRepository.Delete(entity);
        Close();
        
    }

    private async Task SyncStudentsForClass(Guid classId)
    {
        List<Guid> selectedStudentIds = _studentsBox.CheckedItems
            .OfType<StudentOption>()
            .Select(option => option.Id)
            .ToList();
        List<StudentEntity> allStudents = await _studentRepository.GetAll();

        foreach (StudentEntity student in allStudents)
        {
            bool isSelected = selectedStudentIds.Contains(student.Id);
            if (isSelected && student.ClassEntityId != classId)
            {
                student.ClassEntityId = classId;
                await _studentRepository.Update(student);
            }
            else if (!isSelected && student.ClassEntityId == classId)
            {
                student.ClassEntityId = null;
                await _studentRepository.Update(student);
            }
        }
    }

    private record StudentOption(Guid Id, string Label)
    {
        public override string ToString()
        {
            return Label;
        }
    }
}
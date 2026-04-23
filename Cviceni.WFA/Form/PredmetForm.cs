using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

public partial class PredmetForm : System.Windows.Forms.Form
{
    private SubjectRepository _subjectRepository;
    private TeacherRepository _teacherRepository;
    private Guid _guid; 
    private CheckedListBox _teachersBox;
    private Label _teachersLabel;
        
    public PredmetForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _subjectRepository = new SubjectRepository(db);
        _teacherRepository = new TeacherRepository(db);
        _guid = guid;
        _teachersLabel = new Label
        {
            Left = 12,
            Top = 190,
            Width = 360,
            Text = "Učitelé předmětu:"
        };
        _teachersBox = new CheckedListBox
        {
            Left = 12,
            Top = 210,
            Width = 360,
            Height = 95,
            IntegralHeight = false
        };
        Controls.Add(_teachersLabel);
        Controls.Add(_teachersBox);
        if (_guid != Guid.Empty)
        {
            LoadData();
            create.Text = "Upravit";
        }
        else
        {
            LoadTeachersOptions(new List<Guid>());
            delete.Visible = false;
        }
        ReflowLayout();
        BringToFront();
    }

    private void ReflowLayout()
    {
        _teachersLabel.Top = hodinyBox.Bottom + 12;
        _teachersLabel.Width = ClientSize.Width - 24;
        _teachersBox.Top = _teachersLabel.Bottom + 4;
        _teachersBox.Width = ClientSize.Width - 24;
        _teachersBox.Height = 95;
        create.Top = _teachersBox.Bottom + 20;
        delete.Top = create.Top;
        ClientSize = new Size(ClientSize.Width, create.Bottom + 20);
    }

    private async void LoadData()
    {
        SubjectEntity subjectEntity = await _subjectRepository.GetById(_guid);
        predmetBox.Text = subjectEntity.Name;
        kodBox.Text = subjectEntity.Code;
        rocnikBox.Text = subjectEntity.Year + "";
        hodinyBox.Text = subjectEntity.Hours + "";
        await LoadTeachersOptions(subjectEntity.Teachers.Select(teacher => teacher.Id).ToList());
    }

    private async Task LoadTeachersOptions(List<Guid> selectedTeacherIds)
    {
        List<TeacherEntity> teachers = await _teacherRepository.GetAll();
        _teachersBox.Items.Clear();
        teachers.ForEach(teacher =>
        {
            int index = _teachersBox.Items.Add(new TeacherOption(teacher.Id, $"{teacher.Name} ({teacher.Hours}h)"));
            if (selectedTeacherIds.Contains(teacher.Id))
            {
                _teachersBox.SetItemChecked(index, true);
            }
        });
    }


    private async void create_Click_1(object sender, EventArgs e)
    {
        int fRocnik = 0;
        int fHodin = 0;
        if (string.IsNullOrEmpty(predmetBox.Text)) return;
        if (string.IsNullOrEmpty(kodBox.Text)) return;
        if (!int.TryParse(rocnikBox.Text, out fRocnik)) return;
        if (!int.TryParse(hodinyBox.Text, out fHodin)) return;
        if (fRocnik <= 0) return;
        if (fHodin <= 0) return;
        SubjectEntity entity = new SubjectEntity();
        if (_guid != Guid.Empty)
        {
            entity = await _subjectRepository.GetById(_guid);
        }

        entity.Name = predmetBox.Text;
        entity.Code = kodBox.Text;
        entity.Year = fRocnik;
        entity.Hours = fHodin;

        if (_guid != Guid.Empty)
        {
            await _subjectRepository.Update(entity);
        }
        else
        {
            await _subjectRepository.Create(entity);
        }
        await SyncTeachersForSubject(entity.Id);

        Close();
    }

    private async void delete_Click(object sender, EventArgs e)
    {
        SubjectEntity entity =  await _subjectRepository.GetById(_guid);
        await _subjectRepository.Delete(entity);
        Close();
    }

    private async Task SyncTeachersForSubject(Guid subjectId)
    {
        SubjectEntity? subject = await _subjectRepository.GetById(subjectId);
        if (subject == null) return;

        List<Guid> selectedTeacherIds = _teachersBox.CheckedItems
            .OfType<TeacherOption>()
            .Select(option => option.Id)
            .ToList();
        List<TeacherEntity> allTeachers = await _teacherRepository.GetAll();

        foreach (TeacherEntity teacher in allTeachers)
        {
            bool isSelected = selectedTeacherIds.Contains(teacher.Id);
            bool alreadyLinked = teacher.Subjects.Any(s => s.Id == subjectId);
            if (isSelected && !alreadyLinked)
            {
                teacher.Subjects.Add(subject);
                await _teacherRepository.Update(teacher);
            }
            else if (!isSelected && alreadyLinked)
            {
                SubjectEntity? assigned = teacher.Subjects.FirstOrDefault(s => s.Id == subjectId);
                if (assigned != null)
                {
                    teacher.Subjects.Remove(assigned);
                    await _teacherRepository.Update(teacher);
                }
            }
        }
    }

    private record TeacherOption(Guid Id, string Label)
    {
        public override string ToString()
        {
            return Label;
        }
    }
}
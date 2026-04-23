using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

public partial class TeacherForm : System.Windows.Forms.Form
{
    private TeacherRepository _teacherRepository;
    private SubjectRepository _subjectRepository;
    private Guid _guid; 
    private CheckedListBox _subjectsBox;
    private Label _subjectsLabel;
        
    public TeacherForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _teacherRepository = new TeacherRepository(db);
        _subjectRepository = new SubjectRepository(db);
        _guid = guid;
        _subjectsLabel = new Label
        {
            Left = 12,
            Top = 159,
            Width = 360,
            Text = "Předměty:"
        };
        _subjectsBox = new CheckedListBox
        {
            Left = 12,
            Top = 179,
            Width = 360,
            Height = 120,
            IntegralHeight = false
        };
        Controls.Add(_subjectsLabel);
        Controls.Add(_subjectsBox);
        ReflowLayout();

        if (_guid != Guid.Empty)
        {
            LoadData();
            create.Text = "Upravit";
        }
        else
        {
            LoadSubjectsOptions(new List<Guid>());
            delete.Visible = false;
        }
        BringToFront();
    }

    private void ReflowLayout()
    {
        _subjectsLabel.Top = hoursBox.Bottom + 12;
        _subjectsLabel.Width = ClientSize.Width - 24;
        _subjectsBox.Top = _subjectsLabel.Bottom + 4;
        _subjectsBox.Width = ClientSize.Width - 24;
        _subjectsBox.Height = 120;
        create.Top = _subjectsBox.Bottom + 20;
        delete.Top = create.Top;
        ClientSize = new Size(ClientSize.Width, create.Bottom + 20);
    }

    private async void LoadData()
    {
        TeacherEntity teacherEntity = await _teacherRepository.GetById(_guid);
        jmenoBox.Text = teacherEntity.Name;
        vekBox.Text = teacherEntity.Age + "";
        hoursBox.Text = teacherEntity.Hours + "";
        await LoadSubjectsOptions(teacherEntity.Subjects.Select(subject => subject.Id).ToList());
    }

    private async Task LoadSubjectsOptions(List<Guid> selectedSubjectIds)
    {
        List<SubjectEntity> subjects = await _subjectRepository.GetAll();
        _subjectsBox.Items.Clear();
        if (subjects.Count == 0)
        {
            _subjectsBox.Items.Add("(Nejsou žádné předměty - nejprve je vytvořte v záložce Předměty)");
            _subjectsBox.Enabled = false;
            return;
        }

        _subjectsBox.Enabled = true;
        subjects.ForEach(subject =>
        {
            int index = _subjectsBox.Items.Add(new SubjectOption(subject.Id, $"{subject.Name} ({subject.Code})"));
            if (selectedSubjectIds.Contains(subject.Id))
            {
                _subjectsBox.SetItemChecked(index, true);
            }
        });
    }


    private async void create_Click_1(object sender, EventArgs e)
    {
        int fVek = 0;
        int fHours = 0;
        if (string.IsNullOrEmpty(jmenoBox.Text)) return;
        if (!int.TryParse(vekBox.Text, out fVek)) return;
        if (!int.TryParse(hoursBox.Text, out fHours)) return;
        if (fVek <= 0) return;
        if(fHours <= 0) return;
        TeacherEntity entity = new TeacherEntity();
        if (_guid != Guid.Empty)
        {
            entity = await _teacherRepository.GetById(_guid);
        }

        entity.Name = jmenoBox.Text;
        entity.Age = fVek;
        entity.Hours = fHours;
        List<Guid> selectedSubjectIds = _subjectsBox.CheckedItems
            .OfType<SubjectOption>()
            .Select(option => option.Id)
            .ToList();
        List<SubjectEntity> selectedSubjects = await _subjectRepository.GetAll();
        entity.Subjects = selectedSubjects
            .Where(subject => selectedSubjectIds.Contains(subject.Id))
            .ToList();

        if (_guid != Guid.Empty)
        {
            await _teacherRepository.Update(entity);
        }
        else
        {
            await _teacherRepository.Create(entity);
        }

        Close();
    }

    private async void delete_Click(object sender, EventArgs e)
    {
        TeacherEntity entity =  await _teacherRepository.GetById(_guid);
        await _teacherRepository.Delete(entity);
        Close();
    }

    private record SubjectOption(Guid Id, string Label)
    {
        public override string ToString()
        {
            return Label;
        }
    }
}
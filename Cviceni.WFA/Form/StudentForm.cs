using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

internal partial class StudentForm : System.Windows.Forms.Form
{
    private StudentRepository _studentRepository;
    private ClassRepository _classRepository;
    private Guid _guid; 
    private ComboBox _classBox;
    private Label _classLabel;
        
    public StudentForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _studentRepository = new StudentRepository(db);
        _classRepository = new ClassRepository(db);
        _guid = guid;
        _classLabel = new Label
        {
            Left = 12,
            Top = 140,
            Width = 360,
            Text = "Třída:"
        };
        _classBox = new ComboBox
        {
            Left = 12,
            Top = 159,
            Width = 360,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        Controls.Add(_classLabel);
        Controls.Add(_classBox);
        ReflowLayout();

        if (_guid != Guid.Empty)
        {
            LoadData();
            create.Text = "Upravit";
        }
        else
        {
            LoadClassOptions(null);
            delete.Visible = false;
        }
        BringToFront();
    }

    private void ReflowLayout()
    {
        _classLabel.Top = prospechBox.Bottom + 12;
        _classLabel.Width = ClientSize.Width - 24;
        _classBox.Top = _classLabel.Bottom + 4;
        _classBox.Width = ClientSize.Width - 24;
        create.Top = _classBox.Bottom + 20;
        delete.Top = create.Top;
        ClientSize = new Size(ClientSize.Width, create.Bottom + 20);
    }

    private async void LoadData()
    {
        StudentEntity studentEntity = await _studentRepository.GetById(_guid);
        jmenoBox.Text = studentEntity.Name;
        vekBox.Text = studentEntity.Age + "";
        prospechBox.Text = studentEntity.AverageScore + "";
        await LoadClassOptions(studentEntity.ClassEntityId);
    }

    private async Task LoadClassOptions(Guid? selectedClassId)
    {
        List<ClassEntity> classes = await _classRepository.GetAll();
        _classBox.Items.Clear();
        _classBox.Items.Add(new ClassOption(null, "-- Bez třídy --"));
        classes.ForEach(classEntity =>
        {
            _classBox.Items.Add(new ClassOption(classEntity.Id, $"{classEntity.Year}.{classEntity.Code}"));
        });

        ClassOption? selected = _classBox.Items.Cast<ClassOption>()
            .FirstOrDefault(option => option.Id == selectedClassId);
        _classBox.SelectedItem = selected ?? _classBox.Items[0];
        _classLabel.Text = classes.Count == 0
            ? "Třída: (nejprve vytvořte třídu v záložce Třídy)"
            : "Třída:";
    }


    private async void create_Click_1(object sender, EventArgs e)
    {
        int fVek = 0;
        float fPrumer = 0;
        if (string.IsNullOrEmpty(jmenoBox.Text)) return;
        if (!int.TryParse(vekBox.Text, out fVek)) return;
        if (!float.TryParse(prospechBox.Text, out fPrumer)) return;
        if (fVek <= 0) return;
        if(fPrumer < 1 || fPrumer > 5) return;
        StudentEntity entity = new StudentEntity();
        if (_guid != Guid.Empty)
        {
            entity = await _studentRepository.GetById(_guid);
        }

        entity.Name = jmenoBox.Text;
        entity.Age = fVek;
        entity.AverageScore = fPrumer;
        entity.ClassEntityId = (_classBox.SelectedItem as ClassOption)?.Id;

        if (_guid != Guid.Empty)
        {
            await _studentRepository.Update(entity);
        }
        else
        {
            await _studentRepository.Create(entity);
        }

        Close();
    }

    private async void delete_Click(object sender, EventArgs e)
    {
        StudentEntity entity =  await _studentRepository.GetById(_guid);
        await _studentRepository.Delete(entity);
        Close();
    }

    private record ClassOption(Guid? Id, string Label)
    {
        public override string ToString()
        {
            return Label;
        }
    }
}
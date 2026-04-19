using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

internal partial class StudentForm : System.Windows.Forms.Form
{
    private StudentRepository _studentRepository;
    private Guid _guid; 
        
    public StudentForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _studentRepository = new StudentRepository(db);
        _guid = guid;
        if (_guid != Guid.Empty)
        {
            LoadData();
            create.Text = "Upravit";
        }
        else
        {
            delete.Visible = false;
        }
        BringToFront();
    }

    private async void LoadData()
    {
        StudentEntity studentEntity = await _studentRepository.GetById(_guid);
        jmenoBox.Text = studentEntity.Name;
        vekBox.Text = studentEntity.Age + "";
        prospechBox.Text = studentEntity.AverageScore + "";
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
}
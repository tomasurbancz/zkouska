using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

public partial class TeacherForm : System.Windows.Forms.Form
{
    private TeacherRepository _teacherRepository;
    private Guid _guid; 
        
    public TeacherForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _teacherRepository = new TeacherRepository(db);
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
        TeacherEntity teacherEntity = await _teacherRepository.GetById(_guid);
        jmenoBox.Text = teacherEntity.Name;
        vekBox.Text = teacherEntity.Age + "";
        hoursBox.Text = teacherEntity.Hours + "";
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
}
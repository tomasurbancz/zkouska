using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

public partial class ClassForm : System.Windows.Forms.Form
{
    private ClassRepository _classRepository;
    private Guid _guid; 
        
    public ClassForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _classRepository = new ClassRepository(db);
        _guid = guid;
        kmenovaBox.Visible = false;
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
        ClassEntity classEntity = await _classRepository.GetById(_guid);
        rocnikBox.Text = classEntity.Year + "";
        kodBox.Text = classEntity.Code;
        kmenovaCheck.Checked = classEntity.RootClassRoom;
        if (classEntity.RootClassRoom)
        {
            kmenovaBox.Visible = true;
            kmenovaBox.Text = classEntity.RootClassRoomCode + "";
        }
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
    }

    private async void delete_Click(object sender, EventArgs e)
    {
        ClassEntity entity = await _classRepository.GetById(_guid);
        await _classRepository.Delete(entity);
        Close();
        
    }
}
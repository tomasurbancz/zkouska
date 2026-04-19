using Cviceni.Database;
using Cviceni.Database.Entity;
using Cviceni.Database.Repository;

namespace Cviceni.WFA.Form;

public partial class PredmetForm : System.Windows.Forms.Form
{
    private SubjectRepository _subjectRepository;
    private Guid _guid; 
        
    public PredmetForm(DatabaseContext db, Guid guid)
    {
        InitializeComponent();
        _subjectRepository = new SubjectRepository(db);
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
        SubjectEntity subjectEntity = await _subjectRepository.GetById(_guid);
        predmetBox.Text = subjectEntity.Name;
        kodBox.Text = subjectEntity.Code;
        rocnikBox.Text = subjectEntity.Year + "";
        hodinyBox.Text = subjectEntity.Hours + "";
    }


    private async void create_Click_1(object sender, EventArgs e)
    {
        int fRocnik = 0;
        int fHodin = 0;
        if (string.IsNullOrEmpty(predmetBox.Text)) return;
        if (string.IsNullOrEmpty(kodBox.Text)) return;
        if (!int.TryParse(rocnikBox.Text, out fRocnik)) return;
        if (!int.TryParse(rocnikBox.Text, out fHodin)) return;
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

        Close();
    }

    private async void delete_Click(object sender, EventArgs e)
    {
        SubjectEntity entity =  await _subjectRepository.GetById(_guid);
        await _subjectRepository.Delete(entity);
        Close();
    }
}
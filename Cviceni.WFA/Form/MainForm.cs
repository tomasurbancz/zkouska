using Cviceni.Database;
using Cviceni.WFA.Controls;
using Cviceni.WFA.Controls.Lists;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.WFA.Form;

public partial class MainForm : System.Windows.Forms.Form
{
    public MainForm()
    {
        InitializeComponent();

        DatabaseContext database = new DatabaseContext();
        database.Database.Migrate();
        
        StudentListControl slc = new StudentListControl(database);
        slc.Dock = DockStyle.Fill;
        tabStudent.Controls.Add(slc);
        
        TeacherListControl tlc = new TeacherListControl(database);
        tlc.Dock = DockStyle.Fill;
        tabTeacher.Controls.Add(tlc);
        
        SubjectListControl sublc = new SubjectListControl(database);
        sublc.Dock = DockStyle.Fill;
        tabSubject.Controls.Add(sublc);
        
        ClassListControl clc = new ClassListControl(database);
        clc.Dock = DockStyle.Fill;
        tabClass.Controls.Add(clc);
    }
}
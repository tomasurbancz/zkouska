using Cviceni.WFA.Controls.Lists;

namespace Cviceni.WFA.Form;

public partial class Form : System.Windows.Forms.Form
{
    public Form()
    {
        InitializeComponent();

        StudentListControl slc = new StudentListControl();
        slc.Dock = DockStyle.Fill;
        tabStudent.Controls.Add(slc);
    }
}
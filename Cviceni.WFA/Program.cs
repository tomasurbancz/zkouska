using Cviceni.Database;
using Cviceni.WFA.Form;
using Microsoft.EntityFrameworkCore;

namespace Cviceni.WFA;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        DatabaseContext context = new DatabaseContext();
        context.Database.Migrate();
        ApplicationConfiguration.Initialize();
        Application.Run(new Form.Form());
    }
}
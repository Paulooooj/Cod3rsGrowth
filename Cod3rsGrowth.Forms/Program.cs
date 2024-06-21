using Cod3rsGrowth.Forms.ExecutarMigracoes;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var contextoMigracoes = new Migracoes();
            contextoMigracoes.ExecutarMigracao();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
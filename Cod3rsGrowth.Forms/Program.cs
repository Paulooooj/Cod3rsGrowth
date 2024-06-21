using Cod3rsGrowth.Forms.ExecutarMigracoes;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var contextoMigracoes = new Migracoes();
            contextoMigracoes.ExecutarMigracao();
            ApplicationConfiguration.Initialize();
            Application.Run(new FormListaEmpresa());
        }
    }
}
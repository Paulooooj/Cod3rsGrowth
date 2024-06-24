using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Forms.Injecao;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ExecutarMigracoes();
            ApplicationConfiguration.Initialize();
            ServiceProvider = ExecutarInjecao();
            Application.Run(ServiceProvider.GetRequiredService<FormListaEmpresa>());

        }

        public static IServiceProvider ServiceProvider { get; private set; }

        public static void ExecutarMigracoes()
        {
            var servicos = new ServiceCollection();
            servicos.AdicionarDependenciasNoEscopo();
            ServiceProvider = servicos.BuildServiceProvider();
            var runner = ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        public static IServiceProvider ExecutarInjecao()
        {
            var servicos = new ServiceCollection();
            servicos.ModuloInjecaoServico();
            var teste = servicos.BuildServiceProvider();
            return teste;        
        }

    }
}
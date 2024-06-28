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
            Application.Run(ServiceProvider.GetRequiredService<FormListaEmpresaEProduto>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        public static void ExecutarMigracoes()
        {
            var servicos = new ServiceCollection();
            servicos.AdicionarDependenciasNoEscopo();
            using (var serviceProvider = servicos.BuildServiceProvider())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }

        public static IServiceProvider ExecutarInjecao()
        {
            var servicos = new ServiceCollection();
            servicos.ModuloInjecaoServico();
            return servicos.BuildServiceProvider();
        }

    }
}
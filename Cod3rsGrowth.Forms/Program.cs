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
            var ServiceProvider = ExecutarInjecao();
            Application.Run(ServiceProvider.GetRequiredService<FormListaEmpresaEProduto>());
        }

        public static void ExecutarMigracoes()
        {
            var servicos = new ServiceCollection();
            ModuloDeInjecao.AdicionarServicos(servicos);
            using (var serviceProvider = servicos.BuildServiceProvider())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }

        public static IServiceProvider ExecutarInjecao()
        {
            var servicos = new ServiceCollection();
            ModuloInjecaoServicos.AdicionarServicos(servicos);
            return servicos.BuildServiceProvider();
        }

    }
}
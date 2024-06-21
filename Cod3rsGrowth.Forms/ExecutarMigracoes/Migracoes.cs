using Cod3rsGrowth.Forms.Injecao;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.ExecutarMigracoes
{
    public class Migracoes : FormsBase
    {
        public void ExecutarMigracao()
        {
            var runner = ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}

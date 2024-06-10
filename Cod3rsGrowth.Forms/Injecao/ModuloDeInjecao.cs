using Cod3rsGrowth.Infra;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Cod3rsGrowth.Forms.Injecao
{
    public class ModuloDeInjecao
    {
        public static IConfiguration Configuration { get;}

        public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            servico.AddLinqToDBContext<DbCod3rsGrowth>((provider, options)
                => options
            .UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
        }
    }
}

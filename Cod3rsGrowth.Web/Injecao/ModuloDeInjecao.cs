using Cod3rsGrowth.Infra;
using LinqToDB;
using LinqToDB.AspNet;

namespace Cod3rsGrowth.Web.Injecao
{
    public class ModuloDeInjecao
    {
        public static IConfiguration Configuration { get; }

        public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            servico.AddLinqToDBContext<DbCod3rsGrowth>((provider, options)
                => options
            .UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
        }
    }
}

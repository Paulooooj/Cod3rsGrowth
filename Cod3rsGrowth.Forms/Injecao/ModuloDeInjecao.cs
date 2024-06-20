using Cod3rsGrowth.Dominio.Migrations;
using Cod3rsGrowth.Infra;
using FluentMigrator.Runner;
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
            const string nomeVariavelAmbiente = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] nao encontrada");

            servico
                .AddLinqToDBContext<DbCod3rsGrowth>((provider, options) => options
                .UseSqlServer(Configuration.GetConnectionString(stringConexao)));

            servico
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringConexao)
                .ScanIn(typeof(AdicionarTabelas).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        }
    }
}

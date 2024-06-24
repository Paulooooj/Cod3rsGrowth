using Cod3rsGrowth.Dominio.Migrations;
using Cod3rsGrowth.Infra;
using FluentMigrator.Runner;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public static class ModuloDeInjecao
    {
        public static IConfiguration Configuration { get; }

        public static void AdicionarDependenciasNoEscopo(this IServiceCollection servico)
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
                .ScanIn(typeof(_20240620132500_migracao_da_tabela_empresa).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        }
    }
}
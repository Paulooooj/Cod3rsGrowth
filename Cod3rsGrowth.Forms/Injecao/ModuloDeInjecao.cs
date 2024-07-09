using Cod3rsGrowth.Dominio.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public static class ModuloDeInjecao
    {
        public static void AdicionarServicos(this IServiceCollection servico)
        {
            const string variavelAmbienteStringConexao = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(variavelAmbienteStringConexao)
                ?? throw new Exception($"Variavel de ambiente [{variavelAmbienteStringConexao}] nao encontrada");

            servico
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                .AddSqlServer()
                .WithGlobalConnectionString(stringConexao)
                .ScanIn(typeof(_20240703075800_migracao_da_tabela_empresa).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);
        }
    }
}
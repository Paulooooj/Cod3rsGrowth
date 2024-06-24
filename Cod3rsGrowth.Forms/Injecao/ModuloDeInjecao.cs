using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Migrations;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacao;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.Injecao
{
    public class ModuloDeInjecao
    {
        public static IConfiguration Configuration { get; }

        public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            const string nomeVariavelAmbiente = "ConnectionString";
            var stringConexao = Environment.GetEnvironmentVariable(nomeVariavelAmbiente)
                ?? throw new Exception($"Variavel de ambiente [{nomeVariavelAmbiente}] nao encontrada");
            servico.AddScoped<ServicoEmpresa>();
            servico.AddScoped<ServicoProduto>();
            servico.AddScoped<IValidator<Empresa>, EmpresaValidacao>();
            servico.AddScoped<IValidator<Produto>, ProdutoValidacao>();
            servico.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
            servico.AddScoped<IRepositorioProduto, RepositorioProduto>();

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
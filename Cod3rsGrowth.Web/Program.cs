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


var builder = WebApplication.CreateBuilder(args);

const string variavelAmbienteStringConexao = "ConnectionString";
var stringConexao = Environment.GetEnvironmentVariable(variavelAmbienteStringConexao)
    ?? throw new Exception($"Variavel de ambiente [{variavelAmbienteStringConexao}] nao encontrada");

builder.Services.AddFluentMigratorCore().ConfigureRunner(rb => rb.
AddSqlServer()
.WithGlobalConnectionString(stringConexao)
.ScanIn(typeof(_20240703075800_migracao_da_tabela_empresa).Assembly).For.Migrations())
.AddLogging(lb => lb.AddFluentMigratorConsole());

builder.Services.AddLinqToDBContext<DbCod3rsGrowth>((provider, options) => options.UseSqlServer(stringConexao));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServicoEmpresa>();
builder.Services.AddScoped<ServicoProduto>();
builder.Services.AddScoped<IValidator<Empresa>, ValidadorEmpresa>();
builder.Services.AddScoped<IValidator<Produto>, ValidadorProduto>();
builder.Services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

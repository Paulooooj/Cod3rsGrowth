using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Migrations;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Repositorio;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacao;
using Cod3rsGrowth.Web;
using Cod3rsGrowth.Web.MetodosAuxiliares;
using FluentMigrator.Runner;
using FluentValidation;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.FileProviders;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

if(args?.FirstOrDefault() == "BancoTeste")
{
    ConnectionString.connectionString = "ConnectionStringTeste";
}

var stringConexao = Environment.GetEnvironmentVariable(ConnectionString.connectionString)
    ?? throw new Exception($"Variavel de ambiente [{ConnectionString.connectionString}] nao encontrada");

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

var tipoClientes = Enum.GetValues(typeof(EnumRamoDaEmpresa)).Cast<EnumRamoDaEmpresa>().Select(x => new { Descricao = DescricaoEnum.PegarDescricaoEnum(x)});
var options = new JsonSerializerOptions();

builder.Services.AddMvc().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new Converter<EnumRamoDaEmpresa>());
});

builder.Services.AddCors(p => p.AddPolicy("SAPApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.manipuladorDeExcecoesEDetalhesDoProblema(app.Services.GetRequiredService<ILoggerFactory>());

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

app.UseHttpsRedirection();
app.UseCors("SAPApp");

app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true });

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    EnableDirectoryBrowsing = true
});

app.UseAuthorization();

app.MapControllers();

app.Run();

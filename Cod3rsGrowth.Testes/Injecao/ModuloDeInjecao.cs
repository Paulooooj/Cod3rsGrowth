using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Servico.Validacao;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
      public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            servico.AddScoped<ServicoEmpresa>();
            servico.AddScoped<ServicoProduto>();
            servico.AddScoped<IValidator<Empresa>, EmpresaValidacao>();
            servico.AddScoped<IValidator<Produto>, ProdutoValidacao>();
            servico.AddScoped<IRepositorioEmpresa, EmpresaRepositorioMock>();
            servico.AddScoped<IRepositorioProduto, ProdutoRepositorioMock>();
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
      public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            servico.AddScoped<IServicoEmpresa, ServicoEmpresa>();
            servico.AddScoped<IEmpresaRepositorio, EmpresaRepositorioMock>();
            servico.AddScoped<IProdutoRepositorio, ProdutoRepositorioMock>();
        }
    }
}
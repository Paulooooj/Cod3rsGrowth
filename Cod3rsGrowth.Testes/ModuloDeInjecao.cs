using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Servicos;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
      public static void AdicionarDependenciasNoEscopo(ServiceCollection servico)
        {
            servico.AddScoped<IServicoEmpresa, ServicoEmpresa>();
        }



    }
}

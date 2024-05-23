using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteEmpresaRepositorio : TesteBase
    {
        private readonly IEmpresaRepositorio _repositorioEmpresa;
        public TesteEmpresaRepositorio()
        {
            _repositorioEmpresa = ServiceProvider.GetService<IEmpresaRepositorio>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IEmpresaRepositorio)}");
        }

        public void CriarLista()
        {
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "Invent Software",
                   CNPJ = "123456789",
                   Ramo = EnumRamoDaEmpresa.Servico
                },
                new Empresa
                {
                   Id = 2,
                   RazaoSocial = "Heinz",
                   CNPJ = "987654321",
                   Ramo = EnumRamoDaEmpresa.Industria
                },
                new Empresa
                {
                   Id = 3,
                   RazaoSocial = "Lojas Americanas",
                   CNPJ = "543216789",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            var instancia = EmpresaSingleton.Instancia;
            instancia.AddRange(listaEmpresa);
        }
    }
}
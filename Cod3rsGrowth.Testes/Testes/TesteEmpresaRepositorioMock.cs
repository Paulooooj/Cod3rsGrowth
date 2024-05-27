using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteEmpresaRepositorioMock : TesteBase
    {
        private readonly IRepositorioEmpresa _repositorioEmpresa;
        public TesteEmpresaRepositorioMock()
        {
            _repositorioEmpresa = ServiceProvider.GetService<IRepositorioEmpresa>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IRepositorioEmpresa)}");
        }
        [Fact]
        public void testar_se_o_obtertodos_retorna_o_valor_esperado()
        {
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "InventSoftware",
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
                   RazaoSocial = "LojasAmericanas",
                   CNPJ = "543216789",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            CriarLista();
            var listaEmpresaRetornada = _repositorioEmpresa.ObterTodos();
            Assert.Equivalent(listaEmpresa, listaEmpresaRetornada);
        }

        public void CriarLista()
        {
            var listaDeEmpresas = EmpresaSingleton.Instancia;
            var listaEmpresa = new List<Empresa>
            {
                new Empresa
                {
                   Id = 1,
                   RazaoSocial = "InventSoftware",
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
                   RazaoSocial = "LojasAmericanas",
                   CNPJ = "543216789",
                   Ramo = EnumRamoDaEmpresa.Comercio
                },
            };
            listaDeEmpresas.AddRange(listaEmpresa);
        }
    }
}
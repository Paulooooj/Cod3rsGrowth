using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteServicoEmpresa : TesteBase
    {
        private readonly IServicoEmpresa _servicoEmpresa;
        public TesteServicoEmpresa()
        {
            _servicoEmpresa = ServiceProvider.GetService<IServicoEmpresa>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IServicoEmpresa)}");
        }
        [Fact]
        public void testar_se_o_que_esta_retornando_da_lista__em_obter_todos_e_igual_da_lista_de_teste()
        {
            var valorEsperado = new List<Empresa>();
            valorEsperado.Add( new Empresa { Id = 1, RazaoSocial = "InventSoftware", CNPJ = "123456789", Ramo = EnumRamoDaEmpresa.Servico });
            valorEsperado.Add(new Empresa { Id = 2, RazaoSocial = "EmpresaTeste", CNPJ = "987654321", Ramo = EnumRamoDaEmpresa.Industria });
            valorEsperado.Add(new Empresa { Id = 3, RazaoSocial = "TesteEmpresa", CNPJ = "543216789", Ramo = EnumRamoDaEmpresa.Comercio });
            var resultado = _servicoEmpresa.ObterTodos();
            Assert.Equivalent(resultado, valorEsperado);
        }
    }
}
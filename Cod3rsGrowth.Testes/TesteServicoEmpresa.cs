using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public class TesteServicoEmpresa : TesteBase
    {
        public IServicoEmpresa ServicoEmpresa;
        public TesteServicoEmpresa()
        {
            ServicoEmpresa = ServiceProvider.GetService<IServicoEmpresa>();
        }
        [Fact]
        public void TestarSeOQueEstaRetornandoDaListaEmObterTodosEIgualDaListaDeTeste()
        {
            //Arrange
            var valorEsperado = new List<Empresa>();
            valorEsperado.Add( new Empresa { Id = 1, RazaoSocial = "InventSoftware", CNPJ = "123456789", Ramo = EnumRamoDaEmpresa.Servico });
            valorEsperado.Add(new Empresa { Id = 2, RazaoSocial = "EmpresaTeste", CNPJ = "987654321", Ramo = EnumRamoDaEmpresa.Industria });
            valorEsperado.Add(new Empresa { Id = 3, RazaoSocial = "TesteEmpresa", CNPJ = "543216789", Ramo = EnumRamoDaEmpresa.Comercio });

            //Act
            var resultado = ServicoEmpresa.ObterTodos();

            //Assert
            Assert.Equivalent(resultado, valorEsperado);
        }
    }
}

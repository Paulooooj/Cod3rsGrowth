using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteServicoProduto : TesteBase
    {
        private readonly ServicoProduto _servicoProduto;
        public TesteServicoProduto()
        {
            _servicoProduto = ServiceProvider.GetService<ServicoProduto>()
                ?? throw new Exception($"Erro ao obter servico {nameof(ServicoProduto)}");
        }

        [Fact]
        public void testar_se_o_que_esta_retornando_da_lista__em_obter_todos_e_igual_da_lista_de_teste()
        {
            var listaProduto = new List<Produto>
            {
                new Produto
                {
                    Id = 2,
                    Nome = "Molho de Tomate",
                    ValorDoProduto = 5.50m,
                    DataCadastro = DateTime.Today,
                    TemDataValida = true,
                    DataValidade = DateTime.Parse("30/05/2024"),
                    EmpresaId = 2
                },
                new Produto
                {
                    Id = 1,
                    Nome = "BankPlus",
                    ValorDoProduto = 10500m,
                    DataCadastro = DateTime.Today,
                    TemDataValida = false,
                    EmpresaId = 1
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Arroz",
                    ValorDoProduto = 24.50m,
                    DataCadastro = DateTime.Today,
                    TemDataValida = true,
                    DataValidade = DateTime.Parse("10/09/2025"),
                    EmpresaId = 3
                },
            };
            var resultadoRetornado = _servicoProduto.CriarLista();
            Assert.Equivalent(listaProduto, resultadoRetornado);
        }

        [Fact]
        public void testar_se_a_lista_e_do_tipo_empresa()
        {
            var resultadoRetornado = _servicoProduto.CriarLista().ToList();
            Assert.IsType<List<Produto>>(resultadoRetornado);
        }
    }
}

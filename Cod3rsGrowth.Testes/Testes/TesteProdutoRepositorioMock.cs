using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteProdutoRepositorioMock : TesteBase
    {
        private readonly IRepositorioProduto _repositorioProduto;

        public TesteProdutoRepositorioMock()
        {
            _repositorioProduto = ServiceProvider.GetService<IRepositorioProduto>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IRepositorioProduto)}");
            ProdutoSingleton.Instancia.Clear();
        }

        [Fact]
        public void testar_se_o_obtertodos_retorna_o_valor_esperado()
        {
            var listaProduto = CriarLista();
            var listaProdutoRetornadaMock = _repositorioProduto.ObterTodos();
            Assert.Equivalent(listaProduto, listaProdutoRetornadaMock);
        }

        [Fact]
        public void testar_se_retorna_o_objeto_certo_por_id()
        {
            var listaProduto = CriarLista();
            var retornoProduto = _repositorioProduto.ObterPorId(1);
            Assert.Equivalent(listaProduto[0], retornoProduto);
        }

        [Fact]
        public void testar_um_id_que_nao_existe()
        {
            var lista = CriarLista();
            Assert.Throws<Exception>(() => _repositorioProduto.ObterPorId(4));
        }

        [Fact]
        public void testando_se_o_metodo_adicionar_esta_funcionando()
        {
            var produto = new Produto 
            { 
                Id = 5,
                Nome = "teste", 
                ValorDoProduto = 12.50m, 
                DataCadastro = DateTime.Parse("29/05/2024"), 
                TemDataValida = true, 
                DataValidade = DateTime.Parse("12/10/2024"), 
                EmpresaId = 3 
            };
            _repositorioProduto.Adicionar(produto);
            var retornoProduto = ProdutoSingleton.Instancia.FirstOrDefault()
                 ?? throw new Exception($"O ID {produto.Id} não foi encontrado"); ;
            Assert.Equivalent(retornoProduto, produto);
        }

        [Fact]
        public void testando_se_ao_enviar_id_vazio_vai_retornar_excecao_de_nao_validacao()
        {
            var produto = new Produto
            {
                Nome = "teste",
                ValorDoProduto = 12.50m,
                DataCadastro = DateTime.Today,
                TemDataValida = true,
                DataValidade = DateTime.Parse("12/10/2024"),
                EmpresaId = 3
            };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
        }

        [Fact]
        public void testando_se_ao_nao_enviar_nome_vai_retornar_exececao_de_nao_validacao()
        {
            var produto = new Produto
            {
                Id = 2,
                ValorDoProduto = 12.50m,
                DataCadastro = DateTime.Today,
                TemDataValida = true,
                DataValidade = DateTime.Parse("12/10/2024"),
                EmpresaId = 3
            };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
        }

        [Fact]
        public void testar_se_enviar_o_id_vazio_a_mensagem_de_nao_validacao_retorna_correta()
        {
            var produto = new Produto
            {
                Nome = "teste",
                ValorDoProduto = 12.50m,
                DataCadastro = DateTime.Today,
                TemDataValida = true,
                DataValidade = DateTime.Parse("12/10/2024"),
                EmpresaId = 3
            };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
            Assert.Equal("O campo id é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        public List<Produto> CriarLista()
        {
            var listaProduto = new List<Produto>
            {
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
                    Id = 3,
                    Nome = "Arroz",
                    ValorDoProduto = 24.50m,
                    DataCadastro = DateTime.Today,
                    TemDataValida = true,
                    DataValidade = DateTime.Parse("10/09/2025"),
                    EmpresaId = 3
                },
            };
            var listaDeProdutosSingleton = ProdutoSingleton.Instancia;
            listaDeProdutosSingleton.AddRange(listaProduto);
            return listaProduto;
        }
    }
}
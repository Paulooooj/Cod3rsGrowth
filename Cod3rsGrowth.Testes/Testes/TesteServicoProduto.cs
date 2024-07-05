using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteProdutoRepositorioMock : TesteBase
    {
        private readonly ServicoProduto _repositorioProduto;

        public TesteProdutoRepositorioMock()
        {
            _repositorioProduto = ServiceProvider.GetService<ServicoProduto>()
                ?? throw new Exception($"Erro ao obter servico {nameof(ServicoProduto)}");
            ProdutoSingleton.Instancia.Clear();
        }

        [Fact]
        public void deve_retornar_o_objeto_esperado_no_metodo_obter_todos()
        {
            var listaProduto = CriarLista();
            var listaProdutoRetornadaMock = _repositorioProduto.ObterTodos();
            Assert.Equivalent(listaProduto, listaProdutoRetornadaMock);
        }

        [Fact]
        public void deve_retornar_o_objeto_esperado_no_metodo_obter_por_id()
        {
            var listaProduto = CriarLista();
            int id = 1;
            var indexLista = 0;
            var retornoProduto = _repositorioProduto.ObterPorId(id);
            Assert.Equivalent(listaProduto[indexLista], retornoProduto);
        }

        [Fact]
        public void dever_estourar_excecao_por_enviar_id_que_nao_existe()
        {
            var lista = CriarLista();
            int id = 4;
            Assert.Throws<Exception>(() => _repositorioProduto.ObterPorId(id));
        }

        [Fact]
        public void deve_adicionar_um_novo_produto_na_lista_singleton()
        {
            var produto = new Produto
            {
                Id = 5,
                Nome = "teste",
                ValorDoProduto = 12.50m,
                DataCadastro = DateTime.Today,
                TemDataValidade = true,
                DataValidade = DateTime.Parse("10/11/2024"),
                EmpresaId = 5
            };
            _repositorioProduto.Adicionar(produto);
            var retornoProduto = ProdutoSingleton.Instancia.FirstOrDefault();
            Assert.Equivalent(retornoProduto, produto);
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_valorDoProduto_vazio()
        {
            var produto = new Produto
            {
                Nome = "teste",
                DataCadastro = DateTime.Today,
                TemDataValidade = true,
                DataValidade = DateTime.Parse("12/10/2024"),
                EmpresaId = 3
            };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
        }

        [Fact]
        public void deve_estourar_uma_excecao_ao_mandar_um_nome_vazio()
        {
            var produto = new Produto
            {
                Id = 2,
                ValorDoProduto = 12.50m,
                DataCadastro = DateTime.Today,
                TemDataValidade = true,
                DataValidade = DateTime.Parse("12/10/2024"),
                EmpresaId = 3
            };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
        }

        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_valorDoProduto_vazio_esta_correta()
        {
            var produto = new Produto
            {
                Nome = "teste",
                DataCadastro = DateTime.Today,
                TemDataValidade = true,
                DataValidade = DateTime.Parse("12/10/2024"),
                EmpresaId = 3
            };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
            Assert.Equal("O campo valor é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_atualizar_um_objeto_escolhido_na_lista()
        {
            var listaRetornada = CriarLista();
            var produto = new Produto
            {
                Id = 1,
                Nome = "teste11111",
                ValorDoProduto = 10500m,
                DataCadastro = DateTime.Today,
                TemDataValidade = true,
                DataValidade = DateTime.Parse("30/12/2024"),
                EmpresaId = 1
            };
            _repositorioProduto.Atualizar(produto);
            var retornoProduto = ProdutoSingleton.Instancia.Where(x => x.Id == produto.Id).FirstOrDefault();
            Assert.Equivalent(produto, retornoProduto);
        }

        [Fact]
        public void deve_verificar_se_mandar_sem_nome_vai_estourar_uma_excecao()
        {
            var listaRetornada = CriarLista();
            var produto = new Produto
            {
                Id = 1,
                ValorDoProduto = 10500m,
                DataCadastro = DateTime.Today,
                TemDataValidade = false,
                DataValidade = DateTime.Parse("30/11/2024"),
                EmpresaId = 1
            };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Atualizar(produto));
        }

        [Fact]
        public void deve_verificar_se_a_mensagem_apos_estourar_uma_excecao_de_enviar_um_nome_vazio_no_metodo_atualizar_esta_correta()
        {
            var listaRetornada = CriarLista();
            var produto = new Produto
            {
                Id = 1,
                ValorDoProduto = 10500m,
                DataCadastro = DateTime.Today,
                TemDataValidade = false,
                DataValidade = null,
                EmpresaId = 1
            };
            var mensagemDeErro = Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Atualizar(produto));
            Assert.Equal("O campo Nome é obrigatorio", mensagemDeErro.Errors.Single().ErrorMessage);
        }

        [Fact]
        public void deve_remover_um_objeto_escolhido_na_lista()
        {
            CriarLista();
            var produto = new Produto
            {
                Id = 1,
                Nome = "BankPlus",
                ValorDoProduto = 10500m,
                DataCadastro = DateTime.Today,
                TemDataValidade = false,
                DataValidade = null,
                EmpresaId = 1
            };
            _repositorioProduto.Deletar(produto.Id);
            Assert.DoesNotContain(ProdutoSingleton.Instancia, x => x == produto);
        }

        [Fact]
        public void deve_retornar_o_objeto_correspondente_do_obtertodos_usando_filtro()
        {
            CriarLista();
            var listaProduto = new List<Produto>
            {
              new Produto
                {
                    Id = 1,
                    Nome = "BankPlus",
                    ValorDoProduto = 10500m,
                    DataCadastro = DateTime.Today,
                    TemDataValidade = false,
                    DataValidade = null,
                    EmpresaId = 1
                }
            };
            var filtro = "bank";
            var objetoEmpresaRetornado = _repositorioProduto.ObterTodos(new FiltroProduto { Nome = filtro });
            Assert.Equivalent(listaProduto, objetoEmpresaRetornado);
        }

        [Fact]
        public void deve_verificar_se_ao_mandar_um_filtro_invalido_ele_retorna_uma_lista_vazia()
        {
            CriarLista();
            var listaProduto = new List<Produto> { };
            var filtro = "Teste";
            var tamanhoLista = 0;
            var objetoEmpresaRetornado = _repositorioProduto.ObterTodos(new FiltroProduto { Nome = filtro });
            Assert.Equivalent(listaProduto, objetoEmpresaRetornado);
            Assert.Equal(tamanhoLista, objetoEmpresaRetornado.Count);
        }

        [Fact]
        public void deve_estourar_excecao_ao_mandar_id_que_nao_existe()
        {
            CriarLista();
            var produto = new Produto
            {
                Id = 10,
                Nome = "Teste",
                ValorDoProduto = 10500m,
                DataCadastro = DateTime.Today,
                TemDataValidade = false,
                DataValidade = DateTime.Parse("30/11/2024"),
                EmpresaId = 1
            };
            Assert.Throws<System.Exception>(() => _repositorioProduto.Atualizar(produto));
        }

        [Fact]
        public void deve_atualizar_o_produto_atual_para_o_novo()
        {
            CriarLista();
            var produto = new Produto
            {
                Id = 1,
                Nome = "EmpresaTeste",
                ValorDoProduto = 1000m,
                DataCadastro = DateTime.Today,
                TemDataValidade = false,
                DataValidade = null,
                EmpresaId = 1
            };
            _repositorioProduto.Atualizar(produto);
            var retornoProduto = ProdutoSingleton.Instancia.Find(x => x.Id == produto.Id);
            Assert.Equal(produto, retornoProduto);
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
                    TemDataValidade = false,
                    DataValidade = null,
                    EmpresaId = 1
                },
                new Produto
                {
                    Id = 2,
                    Nome = "Molho de Tomate",
                    ValorDoProduto = 5.50m,
                    DataCadastro = DateTime.Today,
                    TemDataValidade = true,
                    DataValidade = DateTime.Parse("30/06/2024"),
                    EmpresaId = 2
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Arroz",
                    ValorDoProduto = 24.50m,
                    DataCadastro = DateTime.Today,
                    TemDataValidade = true,
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
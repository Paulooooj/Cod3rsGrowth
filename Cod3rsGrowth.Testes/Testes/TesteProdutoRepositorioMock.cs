﻿using Cod3rsGrowth.Dominio.Entidades;
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
        public void testar_um_id_que_não_existe()
        {
            var lista = CriarLista();
            Assert.Throws<Exception>(() => _repositorioProduto.ObterPorId(4));
        }

        [Fact]
        public void testa_verificar_se_esta_sendo_adicionado_um_novo_objeto_no_metodo_adicionar()
        {
            var produto = new Produto 
            { 
                Id = 5,
                Nome = "teste", 
                ValorDoProduto = 12.50m, 
                DataCadastro = DateTime.Today, 
                TemDataValida = true, 
                DataValidade = DateTime.Parse("12/10/2024"), 
                EmpresaId = 3 
            };
            _repositorioProduto.Adicionar(produto);
            var retornoProduto = ProdutoSingleton.Instancia.Where(x => x.Id == produto.Id).FirstOrDefault()
                 ?? throw new Exception($"O ID {produto.Id} não foi encontrado"); ;
            Assert.Equivalent(retornoProduto, produto);
        }

        [Fact]
        public void _testar_se_enviar_o_id_vazio_no_objeto_o_adicionar_vai_funcionar_ou_vai_aconter_erro()
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
            var empresa = new Empresa { RazaoSocial = "EmpresaTestea", CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
        }

        [Fact]
        public void _testar_se_enviar_o_razaosocial_vazio_no_objeto_o_adicionar_vai_funcionar_ou_vai_aconter_erro()
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
            var empresa = new Empresa { Id = 6, CNPJ = "12345678912344", Ramo = EnumRamoDaEmpresa.Servico };
            Assert.Throws<FluentValidation.ValidationException>(() => _repositorioProduto.Adicionar(produto));
        }

        [Fact]
        public void _testar_se_enviar_o_id_vazio_a_mensagem_do_erro_vai_ser_igual_a_esperada()
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
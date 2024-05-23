using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.Testes
{
    public class TesteProdutoRepositorio :TesteBase
    {
        private readonly IProdutoRepositorio _repositorioProduto;
        public TesteProdutoRepositorio()
        {
            _repositorioProduto = ServiceProvider.GetService<IProdutoRepositorio>()
                ?? throw new Exception($"Erro ao obter servico {nameof(IProdutoRepositorio)}");
        }

        public void CriarLista()
        {
            var listaProduto = new List<Produto>
            {
                new Produto
                {
                    Id = 2,
                    Nome = "Molho de Tomate",
                    ValorDoProduto = 5.50m,
                    DataCadastro = DateTime.Now,
                    TemDataValida = true,
                    DataValidade = DateTime.Parse("30/05/2024"),
                    EmpresaId = 2
                },
                new Produto
                {
                    Id = 1,
                    Nome = "BankPlus",
                    ValorDoProduto = 10500m,
                    DataCadastro = DateTime.Now,
                    TemDataValida = false,
                    EmpresaId = 1
                },
                new Produto
                {
                    Id = 3,
                    Nome = "Arroz",
                    ValorDoProduto = 24.50m,
                    DataCadastro = DateTime.Now,
                    TemDataValida = true,
                    DataValidade = DateTime.Parse("10/09/2025"),
                    EmpresaId = 3
                },
            };
            var instancia = ProdutoSingleton.Instancia;
            instancia.AddRange(listaProduto);
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Singleton;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoProduto : IServicoProduto
    {
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
            var listaDeProdutos = ProdutoSingleton.Instancia;
            listaDeProdutos.AddRange(listaProduto);
            return listaDeProdutos;
        }
    }
}

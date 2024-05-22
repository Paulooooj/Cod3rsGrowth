using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class ProdutoRepositorioMock : IProdutoRepositorio
    {
        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterTodos()
        {
            throw new NotImplementedException();
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
            ProdutoSingleton.Instancia.AddRange(listaProduto);
        }
    }
}
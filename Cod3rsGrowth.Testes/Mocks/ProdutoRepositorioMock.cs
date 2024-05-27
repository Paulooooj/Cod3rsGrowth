using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Testes
{
    public class ProdutoRepositorioMock : IRepositorioProduto
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
    }
}
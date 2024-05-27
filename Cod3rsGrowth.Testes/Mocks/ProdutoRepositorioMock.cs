using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class ProdutoRepositorioMock : IRepositorioProduto
    {
        private readonly ProdutoSingleton _intanciaProdutoSingleton = ProdutoSingleton.Instancia;

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
            var produto = _intanciaProdutoSingleton.Where(x => x.Id == id).FirstOrDefault()
                ?? throw new Exception($"O ID {id} não foi encontrado");
            return produto;
        }

        public List<Produto> ObterTodos()
        {
           return _intanciaProdutoSingleton;
        }
    }
}
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;

namespace Cod3rsGrowth.Testes
{
    public class ProdutoRepositorioMock : IRepositorioProduto
    {
        private readonly ProdutoSingleton _intanciaProdutoSingleton;

        public ProdutoRepositorioMock()
        {
            _intanciaProdutoSingleton = ProdutoSingleton.Instancia;
        }

        public void Adicionar(Produto produto)
        {
            _intanciaProdutoSingleton.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            var produtoASerAtualizado = _intanciaProdutoSingleton.Find(x => x.Id == produto.Id);
            var posicao = _intanciaProdutoSingleton.IndexOf(produtoASerAtualizado);
            _intanciaProdutoSingleton[posicao] = produto;
        }

        public void Deletar(int id)
        {
            var produtoASerRemovido = _intanciaProdutoSingleton.Find(x => x.Id == id);
            _intanciaProdutoSingleton.Remove(produtoASerRemovido);
        }

        public Produto ObterPorId(int id)
        {
            return _intanciaProdutoSingleton.Find(x => x.Id == id);
        }

        public List<Produto> ObterTodos(FiltroProduto? filtro = null)
        {
            var listaProduto = _intanciaProdutoSingleton.ToList();

            if (!string.IsNullOrEmpty(filtro?.Nome))
            {
                listaProduto = listaProduto.FindAll(x => x.Nome.StartsWith(filtro?.Nome, StringComparison.OrdinalIgnoreCase));
            }

            if (filtro?.ValorMinimo != null)
            {
                listaProduto = listaProduto.FindAll(x => x.ValorDoProduto >= filtro?.ValorMinimo);
            }

            if (filtro?.DataCadastro != null)
            {
                listaProduto = listaProduto.FindAll(x => x.DataCadastro == filtro?.DataCadastro);
            }

            return listaProduto;
        }
    }
}
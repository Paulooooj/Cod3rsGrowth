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
            var verificacaoSeTemID = _intanciaProdutoSingleton.Find(x => x.Id == produto.Id);
            var posicao = _intanciaProdutoSingleton.IndexOf(verificacaoSeTemID);
            _intanciaProdutoSingleton[posicao] = produto;
        }

        public void Deletar(int id)
        {
            var objetoASerRemovido = _intanciaProdutoSingleton.Find(x => x.Id == id)
                ?? throw new Exception($"Produto com Id: {id} não encontrado");
            _intanciaProdutoSingleton.Remove(objetoASerRemovido);
        }

        public Produto ObterPorId(int id)
        {
            var produto = _intanciaProdutoSingleton.Find(x => x.Id == id)
                ?? throw new Exception($"Produto com Id: {id} não encontrado");
            return produto;
        }

        public List<Produto> ObterTodos(FiltroProduto? filtro = null)
        {
            var listaProduto = _intanciaProdutoSingleton.ToList();

            if (!string.IsNullOrEmpty(filtro?.Nome))
            {
                listaProduto = listaProduto.FindAll(x => x.Nome.StartsWith(filtro?.Nome, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.ValorDoProduto != null)
            {
                listaProduto = listaProduto.FindAll(x => x.ValorDoProduto == filtro?.ValorDoProduto);
            }
            if (filtro?.DataCadastro != null)
            {
                listaProduto = listaProduto.FindAll(x => x.DataCadastro == filtro?.DataCadastro);
            }
            return listaProduto;
        }
    }
}
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Testes
{
    public class ProdutoRepositorioMock : IRepositorioProduto
    {
        private readonly ProdutoSingleton _intanciaProdutoSingleton;
        private readonly IValidator<Produto> _produtoValidacao;

        public ProdutoRepositorioMock(IValidator<Produto> produtoValidacao)
        {
            _intanciaProdutoSingleton = ProdutoSingleton.Instancia;
            _produtoValidacao = produtoValidacao;
        }

        public void Adicionar(Produto produto)
        {
            _produtoValidacao.ValidateAndThrow(produto);
            _intanciaProdutoSingleton.Add(produto);
        }

        public void Atualizar(Produto produtoAtualizado)
        {
            _produtoValidacao.ValidateAndThrow(produtoAtualizado);
            var verificacaoSeTemID = _intanciaProdutoSingleton.Find(x => x.Id == produtoAtualizado.Id)
                ?? throw new Exception($"Produto com Id: {produtoAtualizado.Id} não encontrado");
            var posicao = _intanciaProdutoSingleton.IndexOf(verificacaoSeTemID);
            _intanciaProdutoSingleton[posicao] = produtoAtualizado;
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

        public List<Produto> ObterTodos(FiltroProduto? produto = null)
        {
            return _intanciaProdutoSingleton;
        }
    }
}
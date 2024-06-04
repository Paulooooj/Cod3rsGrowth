using Cod3rsGrowth.Dominio.Entidades;
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
                ?? throw new Exception($"O Id {produtoAtualizado.Id} não existe"); 
            var posicao = _intanciaProdutoSingleton.FindIndex(x => x.Id == produtoAtualizado.Id);
            _intanciaProdutoSingleton[posicao] = produtoAtualizado;
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
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Testes
{
    public class ProdutoRepositorioMock : IRepositorioProduto
    {
        private readonly ProdutoSingleton _intanciaProdutoSingleton;
        private readonly IValidator<Produto> _empresaValidacao;

        public ProdutoRepositorioMock(IValidator<Produto> empresaValidacao)
        {
            _intanciaProdutoSingleton = ProdutoSingleton.Instancia;
            _empresaValidacao = empresaValidacao;
        }

        public void Adicionar(Produto produto)
        {
            _empresaValidacao.ValidateAndThrow(produto);
            _intanciaProdutoSingleton.Add(produto);
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
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System.Collections.Generic;

namespace Cod3rsGrowth.Servico.Servicos
{
    public class ServicoProduto
    {
        private readonly IValidator<Produto> _produtoValidacao;
        private readonly IRepositorioProduto _repositorioProduto;

        public ServicoProduto(IValidator<Produto> produtoValidacao, IRepositorioProduto repositorioProduto)
        {
            _produtoValidacao = produtoValidacao;
            _repositorioProduto = repositorioProduto;
        }

        public void Adicionar(Produto produto)
        {
            _produtoValidacao.ValidateAndThrow(produto);
            _repositorioProduto.Adicionar(produto);
        }

        public void Atualizar(Produto produto)
        {
            _produtoValidacao.ValidateAndThrow(produto);
            _repositorioProduto.Atualizar(produto);
        }

        public void Deletar(int id)
        {
            _repositorioProduto.Deletar(id);
        }

        public Produto ObterPorId(int id)
        {
            var produto = _repositorioProduto.ObterPorId(id);
            return produto;
        }

        public List<Produto> ObterTodos(FiltroProduto? filtro = null)
        {
            var listaProduto = _repositorioProduto.ObterTodos();
            return listaProduto;
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using System;
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

            try
            {
                _repositorioProduto.Atualizar(produto);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new Exception($"Produto com Id: {produto.Id} não encontrado");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex}");
            }
        }

        public void Deletar(int id)
        {
            _repositorioProduto.Deletar(id);
        }

        public Produto ObterPorId(int id)
        {
            return _repositorioProduto.ObterPorId(id);
        }

        public List<Produto> ObterTodos(FiltroProduto? filtro = null)
        {
            return _repositorioProduto.ObterTodos(filtro);
        }
    }
}

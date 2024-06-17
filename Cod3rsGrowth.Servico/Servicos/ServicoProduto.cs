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
            try
            {
                _produtoValidacao.ValidateAndThrow(produto);
                _repositorioProduto.Atualizar(produto);
            }
            catch (ValidationException ve)
            {
                throw new ValidationException(ve.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Deletar(int id)
        {
            try
            {
                _repositorioProduto.Deletar(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

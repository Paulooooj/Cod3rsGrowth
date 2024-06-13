using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class RepositorioProduto : IRepositorioProduto
    {
        private readonly DbCod3rsGrowth _db;

        public RepositorioProduto(DbCod3rsGrowth dbCoders)
        {
            _db = dbCoders;
        }

        public void Adicionar(Produto produto)
        {
            _db.Insert(produto);
        }

        public void Atualizar(Produto produto)
        {
            var verificarId = _db.GetTable<Produto>().ToList().Find(x => x.Id == produto.Id)
                ?? throw new Exception($"Produto com Id: {produto.Id} não encontrado");
            _db.Produtos
                .Where(x => x.Id == produto.Id)
                .Set(x => x.Nome, produto.Nome)
                .Set(x => x.ValorDoProduto, produto.ValorDoProduto)
                .Set(x => x.DataCadastro, produto.DataCadastro)
                .Set(x => x.TemDataValida, produto.TemDataValida)
                .Set(x => x.DataValidade, produto.DataValidade)
                .Update();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Produto ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterTodos(FiltroProduto? filtro = null)
        {
            var listaProduto = _db.GetTable<Produto>().ToList();

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
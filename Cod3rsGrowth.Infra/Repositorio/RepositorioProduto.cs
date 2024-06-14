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
            _db.Update(produto);
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
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using FluentMigrator.Runner.Generators;
using LinqToDB;
using LinqToDB.SqlQuery;
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
            _db.Produtos
                .Delete(x => x.Id == id); ;
        }

        public Produto ObterPorId(int id)
        {
            return _db.GetTable<Produto>()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Produto> ObterTodos(FiltroProduto? filtro = null)
        {
            const int valorMinimoComecarFiltrar = 0;
            var tabelaProduto = _db.GetTable<Produto>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.Nome))
                tabelaProduto = tabelaProduto.Where(x => x.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));

            if (filtro?.ValorMinimo != null && filtro?.ValorMinimo > valorMinimoComecarFiltrar)
                tabelaProduto = tabelaProduto.Where(x => x.ValorDoProduto >= filtro.ValorMinimo);

            if (filtro?.ValorMaximo != null && filtro?.ValorMaximo > valorMinimoComecarFiltrar)
                tabelaProduto = tabelaProduto.Where(x => x.ValorDoProduto <= filtro.ValorMaximo);

            if (filtro?.DataMinima != null)
                tabelaProduto = tabelaProduto.Where(x => x.DataCadastro >= filtro.DataMinima);

            if (filtro?.DataMaxima != null)
                tabelaProduto = tabelaProduto.Where(x => x.DataCadastro <= filtro.DataMaxima);

            return tabelaProduto.ToList();
        }
    }
}
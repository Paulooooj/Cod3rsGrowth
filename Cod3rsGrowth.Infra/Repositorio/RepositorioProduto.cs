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
            var listaProduto = _db.GetTable<Produto>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.Nome))
                listaProduto = listaProduto.Where(x => x.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));

            if (filtro?.ValorMinimo != null && filtro?.ValorMinimo > 0)
                listaProduto = listaProduto.Where(x => x.ValorDoProduto >= filtro.ValorMinimo);

            if (filtro?.ValorMaximo != null && filtro?.ValorMaximo > 0)
                listaProduto = listaProduto.Where(x => x.ValorDoProduto <= filtro.ValorMaximo);

            if (filtro?.DataCadastro != null)
                listaProduto = listaProduto.Where(x => x.DataCadastro >= filtro.DataCadastro);

            return listaProduto.ToList();
        }
    }
}
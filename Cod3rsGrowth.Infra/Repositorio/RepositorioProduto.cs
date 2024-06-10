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
        private readonly DbCod3rsGrowth db;
        
        public RepositorioProduto(DbCod3rsGrowth dbCoders)
        {
            db = dbCoders;
        }

        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
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
            var listaProduto = db.GetTable<Produto>().ToList();
            if(filtro != null)
            {
                if(filtro.Nome != null)
                {
                   listaProduto = listaProduto.Where(x => x.Nome == filtro.Nome).ToList();
                }
                if(filtro.ValorDoProduto != null)
                {
                    listaProduto = listaProduto.Where(x => x.ValorDoProduto == filtro.ValorDoProduto).ToList();
                }
                if(filtro.DataCadastro != null)
                {
                    listaProduto = listaProduto.Where(x => x.DataCadastro == filtro.DataCadastro).ToList();
                }
                return listaProduto;
            }
            return listaProduto;
        }
    }
}

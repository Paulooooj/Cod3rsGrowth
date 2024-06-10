using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly DbCod3rsGrowth db;
        public RepositorioEmpresa(DbCod3rsGrowth dbCod3Rs)
        {
            db = dbCod3Rs;
        }
        public void Adicionar(Empresa empresa)
        {
           
        }

        public void Atualizar(Empresa empresa)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new System.NotImplementedException();
        }

        public Empresa ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Empresa> ObterTodos(FiltroEmpresa? filtro = null)
        {
            var listaEmpresa = db.GetTable<Empresa>().ToList();
            if (filtro != null)
            {
                if(filtro.RazaoSocial != null)
                {
                    listaEmpresa = listaEmpresa.Where(x => x.RazaoSocial == filtro.RazaoSocial).ToList();
                }
                if(filtro.Ramo != EnumRamoDaEmpresa.NaoDefinido)
                {
                    listaEmpresa = listaEmpresa.Where(x => x.Ramo == filtro.Ramo).ToList();
                }
                return listaEmpresa;
            }
            return listaEmpresa;
        }
    }
}

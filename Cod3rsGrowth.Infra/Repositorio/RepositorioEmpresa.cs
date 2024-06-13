using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        private readonly DbCod3rsGrowth _db;

        public RepositorioEmpresa(DbCod3rsGrowth dbCod3Rs)
        {
            _db = dbCod3Rs;
        }

        public void Adicionar(Empresa empresa)
        {
            _db.Insert(empresa);
        }

        public void Atualizar(Empresa empresa)
        {
            var verificarId = _db.GetTable<Empresa>().ToList().Find(x => x.Id == empresa.Id)
                ?? throw new Exception($"Empresa com Id: {empresa.Id} não encontrado"); ;
            _db.Empresas
                .Where(x => x.Id == empresa.Id)
                .Set(x => x.RazaoSocial, empresa.RazaoSocial)
                .Set(x => x.CNPJ, empresa.CNPJ)
                .Set(x => x.Ramo, empresa.Ramo)
                .Update();
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
            var listaEmpresa = _db.GetTable<Empresa>().ToList();

            if (!string.IsNullOrEmpty(filtro?.RazaoSocial))
            {
                listaEmpresa = listaEmpresa.FindAll(x => x.RazaoSocial.StartsWith(filtro?.RazaoSocial, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Ramo != null)
            {
                listaEmpresa = listaEmpresa.FindAll(x => x.Ramo == filtro?.Ramo);
            }
            return listaEmpresa;
        }

        public bool verificarSeTemNomeRepetido(string razaoSocial)
        {
            var verificacao = _db.GetTable<Empresa>().ToList().FindAll(x => x.RazaoSocial == razaoSocial);
            return !(verificacao == null);
        }
    }
}
﻿using Cod3rsGrowth.Dominio.Entidades;
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
            _db.Update(empresa);
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

        public bool verificarSeTemNomeRepetido(Empresa empresa)
        {
            var verificacao = _db.GetTable<Empresa>().ToList().FindAll(x => x.RazaoSocial == razaoSocial);
            var tamanhoListaQuandoForVazia = 0;
            return (verificacao.Count == tamanhoListaQuandoForVazia);
        }
    }
}
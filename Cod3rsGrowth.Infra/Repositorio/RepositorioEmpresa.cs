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
            _db.Update(empresa);
        }

        public void Deletar(int id)
        {
            _db.Empresas
                .Delete(x => x.Id == id);
        }

        public Empresa ObterPorId(int id)
        {
            return _db.GetTable<Empresa>()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Empresa> ObterTodos(FiltroEmpresa? filtro = null)
        {
            var tabelaEmpresa = _db.GetTable<Empresa>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.RazaoSocialECnpj))
                tabelaEmpresa = tabelaEmpresa.Where(x => x.RazaoSocial.
                Contains(filtro.RazaoSocialECnpj, StringComparison.OrdinalIgnoreCase) || x.CNPJ.Contains(filtro.RazaoSocialECnpj, StringComparison.OrdinalIgnoreCase));

            const int valorPadrao = 0;
            if (filtro?.Ramo != null && filtro.Ramo > valorPadrao)
                tabelaEmpresa = tabelaEmpresa.Where(x => x.Ramo == filtro.Ramo);

            return tabelaEmpresa.ToList();
        }

        public bool EhNomeExistenteNoBanco(Empresa empresa)
        {
            return !_db.GetTable<Empresa>().Any(x => x.RazaoSocial == empresa.RazaoSocial &&  x.Id != empresa.Id);
        }
    }
}

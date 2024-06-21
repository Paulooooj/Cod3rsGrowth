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
            var listaEmpresa = _db.GetTable<Empresa>().AsQueryable();

            if (!string.IsNullOrEmpty(filtro?.RazaoSocial))
            {
                listaEmpresa = listaEmpresa.Where(x => x.RazaoSocial.StartsWith(filtro.RazaoSocial, StringComparison.OrdinalIgnoreCase));
            }
            if (filtro?.Ramo != null)
            {
                listaEmpresa = listaEmpresa.Where(x => x.Ramo == filtro.Ramo);
            }
            return listaEmpresa.ToList();
        }

        public bool verificarSeTemNomeRepetido(Empresa empresa)
        {
            var empresaNomeRepetido = _db.GetTable<Empresa>().ToList().Find(x => x.RazaoSocial == empresa.RazaoSocial);

            if (empresaNomeRepetido != null)
            {
                if (empresaNomeRepetido.Id != empresa.Id)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

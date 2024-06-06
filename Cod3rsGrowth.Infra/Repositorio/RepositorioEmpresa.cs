using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using LinqToDB.Data;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Repositorio
{
    public class RepositorioEmpresa : IRepositorioEmpresa
    {
        DataConnection db;
        public RepositorioEmpresa()
        {
        }
        public void Adicionar(Empresa empresa)
        {
            throw new System.NotImplementedException();
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

        public List<Empresa> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioEmpresa
    {
        List<Empresa> ObterTodos(FiltroEmpresa? filtro = null);
        void Adicionar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Deletar(int id);
        Empresa ObterPorId(int id);
    }
}
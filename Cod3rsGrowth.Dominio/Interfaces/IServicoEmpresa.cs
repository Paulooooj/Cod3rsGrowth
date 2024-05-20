using Cod3rsGrowth.Dominio.Entidades;
using System.Reflection.Emit;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoEmpresa
    {
        public List<Empresa> ObterTodos();
        public List<Empresa> Remover(int id);
       
    }
}
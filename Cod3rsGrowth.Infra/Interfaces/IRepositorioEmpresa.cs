using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioEmpresa
    {
        List<Empresa> ObterTodos();
        void Adicionar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Deletar(int id);
        Empresa ObterPorId(int id);
    }
}
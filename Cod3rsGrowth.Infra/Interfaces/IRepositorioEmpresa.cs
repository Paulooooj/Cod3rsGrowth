using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IEmpresaRepositorio
    {
        List<Empresa> ObterTodos();
        void Adicionar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Deletar(Empresa empresa);
        Empresa ObterPorId(int id);
    }
}
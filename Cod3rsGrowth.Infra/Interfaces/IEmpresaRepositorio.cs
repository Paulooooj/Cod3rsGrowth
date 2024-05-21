namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IEmpresaRepositorio
    {
        void ObterTodos();
        void Adicionar();
        void Atualizar();
        void Deletar();
        void ObterPorId();
    }
}
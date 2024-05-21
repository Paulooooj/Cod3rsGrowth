namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IProdutoRepositorio
    {
        void ObterTodos();
        void Adicionar();
        void Atualizar();
        void Deletar();
        void ObterPorId();
        
    }
}
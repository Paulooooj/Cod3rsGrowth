using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IProdutoRepositorio
    {
        List<Produto> ObterTodos(int id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(Produto produto);
        Produto ObterPorId(int id);
        
    }
}
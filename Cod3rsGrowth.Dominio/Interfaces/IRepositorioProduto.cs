using Cod3rsGrowth.Dominio.Entidades;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioProduto
    {
        List<Produto> ObterTodos();
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
        Produto ObterPorId(int id);
    }
}
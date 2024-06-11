using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Filtros;
using System.Collections.Generic;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositorioProduto
    {
        List<Produto> ObterTodos(FiltroProduto? filtro = null);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Deletar(int id);
        Produto ObterPorId(int id);
    }
}
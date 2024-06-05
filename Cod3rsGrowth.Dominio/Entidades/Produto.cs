using System;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public decimal ValorDoProduto { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool TemDataValida { get; set; }
        public DateTime? DataValidade { get; set; }
        public int EmpresaId { get; set; }
    }
}
using System;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Produto")]
    public class Produto
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string? Nome { get; set; }
        [Column]
        public decimal ValorDoProduto { get; set; }
        [Column]
        public DateTime DataCadastro { get; set; }
        [Column]
        public bool TemDataValida { get; set; }
        [Column]
        public DateTime? DataValidade { get; set; }
        [Column]
        public int EmpresaId { get; set; }
    }
}
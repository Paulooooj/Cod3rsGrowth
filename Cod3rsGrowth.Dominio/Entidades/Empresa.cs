using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Entidades
{
    [Table("Empresa")]
    public class Empresa
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string? RazaoSocial { get; set; }
        [Column]
        public string? CNPJ { get; set; }
        [Column]
        public EnumRamoDaEmpresa Ramo { get; set; }
    }
}
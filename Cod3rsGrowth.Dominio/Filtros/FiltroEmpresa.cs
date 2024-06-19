using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Filtros
{
    public class FiltroEmpresa
    {
        public string? RazaoSocial { get; set; }
        public EnumRamoDaEmpresa? Ramo { get; set; }
    }
}

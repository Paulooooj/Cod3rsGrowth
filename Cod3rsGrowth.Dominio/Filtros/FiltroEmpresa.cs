using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Filtros
{
    public class FiltroEmpresa
    {
        public string? RazaoSocialECnpj { get; set; }
        public EnumRamoDaEmpresa? Ramo { get; set; }
    }
}

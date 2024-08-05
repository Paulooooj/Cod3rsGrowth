using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public enum EnumRamoDaEmpresa
    {
        [Description("Todos")]
        NaoDefinido,
        [Description("Indústria")]
        Industria,
        [Description("Comércio")]
        Comercio,
        [Description("Serviço")]
        Servico
    }
}
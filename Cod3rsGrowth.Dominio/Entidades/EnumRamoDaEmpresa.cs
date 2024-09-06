using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public enum EnumRamoDaEmpresa
    {
        [Description("Não Definido")]
        NaoDefinido,
        [Description("Indústria")]
        Industria,
        [Description("Comércio")]
        Comercio,
        [Description("Serviço")]
        Servico
    }
}
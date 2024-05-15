using System.ComponentModel;
namespace Cod3rsGrowth.Dominio.Entidades
{
    public enum EnumRamoDaEmpresa
    {
        [Description("Tem como objetivo a produção de produtos")]
        Industria,
        [Description("Movimenta diferentes tipos de produtos")]
        Comercio,
        [Description("Foco na venda do seu serviço")]
        Servico
    }
}

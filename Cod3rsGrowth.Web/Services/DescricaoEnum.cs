using System.ComponentModel;

namespace Cod3rsGrowth.Web.MetodosAuxiliares
{
    public static class DescricaoEnum
    {
        public static string PegarDescricaoEnum(Enum value)
        {
            const int valorMinimo = 0;
            const int valorInicial = 0;

            var campo = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] atributos = (DescriptionAttribute[])campo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > valorMinimo ? atributos[valorInicial].Description : value.ToString();
        }
    }
}

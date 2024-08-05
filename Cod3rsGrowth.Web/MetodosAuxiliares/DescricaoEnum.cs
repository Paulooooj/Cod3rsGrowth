using System.ComponentModel;

namespace Cod3rsGrowth.Web.MetodosAuxiliares
{
    public static class DescricaoEnum
    {
        public static string pegarDescricaoEnum(Enum value)
        {
            var campo = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])campo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description : value.ToString();
        }
    }
}

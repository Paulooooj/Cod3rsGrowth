

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public EnumRamoDaEmpresa Ramo { get; set; }

    }
}

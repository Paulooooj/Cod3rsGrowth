using System;

namespace Cod3rsGrowth.Infra.Filtros
{
    public class FiltroProduto
    {
        public string? Nome { get; set; }
        public decimal? ValorMinimo { get; set; }
        public decimal? ValorMaximo { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}

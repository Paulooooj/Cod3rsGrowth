using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio.Entidades
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorDoProduto { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool TemDataValida { get; set; }
        public DateTime DataValidade { get; set; }
        public int EmpresaId { get; set; }
    }

}

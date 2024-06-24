using Cod3rsGrowth.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaEmpresa : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        public FormListaEmpresa(ServicoEmpresa servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
            InitializeComponent();
        }
    }
}

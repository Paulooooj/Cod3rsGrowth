using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroEmpresa : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;

        public CadastroEmpresa(ServicoEmpresa servicoEmpresa)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
        }

        private void aoClicarDeveCancelarAdicionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aoClicarDeveAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var empresa = new Empresa();
                empresa.RazaoSocial = razaoSocialCadastroEmpresa.Text;
                cnpjEmpresa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                empresa.CNPJ = cnpjEmpresa.Text;
                empresa.Ramo = (EnumRamoDaEmpresa)ramoDaEmpresa.SelectedIndex;
                _servicoEmpresa.Adicionar(empresa);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

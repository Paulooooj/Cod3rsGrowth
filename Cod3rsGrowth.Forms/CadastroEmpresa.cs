using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroEmpresa : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly Empresa? _empresa;

        public CadastroEmpresa(ServicoEmpresa servicoEmpresa, Empresa? empresa = null)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _empresa = empresa;
            MostrarInformacoesAoAtualizar();
        }

        private void MostrarInformacoesAoAtualizar()
        {
            if (_empresa != null)
            {
                razaoSocialCadastroEmpresa.Text = _empresa.RazaoSocial;
                cnpjEmpresa.Text = _empresa.CNPJ;
                ramoDaEmpresa.SelectedIndex = (int)_empresa.Ramo;
            }
        }

        private void aoClicarDeveCancelarAdicionar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aoClicarDeveSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cnpjEmpresa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;

                var empresa = new Empresa
                {
                    RazaoSocial = razaoSocialCadastroEmpresa.Text,
                    CNPJ = cnpjEmpresa.Text,
                    Ramo = (EnumRamoDaEmpresa)ramoDaEmpresa.SelectedIndex
                };

                SalvarDados(empresa);   
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SalvarDados(Empresa empresa)
        {
            if (_empresa != null)
            {
                empresa.Id = _empresa.Id;
                _servicoEmpresa.Atualizar(empresa);
                return;
            }
            _servicoEmpresa.Adicionar(empresa);
        }
    }
}

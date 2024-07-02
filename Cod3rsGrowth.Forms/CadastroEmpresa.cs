using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using System.Drawing.Printing;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroEmpresa : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly int _id;

        public CadastroEmpresa(ServicoEmpresa servicoEmpresa, int? id = 0)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _id = (int)id;
            MostrarInformacoesAoAtualizar();
        }

        private void MostrarInformacoesAoAtualizar()
        {
            if (_id > 0)
            {
                var empresa = _servicoEmpresa.ObterPorId(_id);
                razaoSocialCadastroEmpresa.Text = empresa.RazaoSocial;
                cnpjEmpresa.Text = empresa.CNPJ;
                ramoDaEmpresa.SelectedIndex = (int)empresa.Ramo;
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
                var empresa = new Empresa();
                empresa.RazaoSocial = razaoSocialCadastroEmpresa.Text;
                cnpjEmpresa.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                empresa.CNPJ = cnpjEmpresa.Text;
                empresa.Ramo = (EnumRamoDaEmpresa)ramoDaEmpresa.SelectedIndex;
                const int quantoNaoTemId = 0;

                if (_id > quantoNaoTemId)
                {
                    empresa.Id = _id;
                    _servicoEmpresa.Atualizar(empresa);
                }
                else
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

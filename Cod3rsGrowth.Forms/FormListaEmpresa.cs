using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaEmpresa : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly ServicoProduto _servicoProduto;

        public FormListaEmpresa(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto)
        {
            _servicoEmpresa = servicoEmpresa;
            _servicoProduto = servicoProduto;
            InitializeComponent();
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(null);
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(null);
            comboBoxEnumRamo.SelectedIndex = 0;

        }

        private void tabPagEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void tabPageProduto_Click(object sender, EventArgs e)
        {

        }

        private void textFiltrarNome_TextChanged(object sender, EventArgs e)
        {
            if (textFiltrarNome.Text != null)
            {
                dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(new FiltroEmpresa { RazaoSocial = textFiltrarNome.Text });
            }
        }

        private void comboBoxEnumRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEnumRamo.SelectedIndex == 0)
            {
                if (textFiltrarNome.Text != null)
                {
                    dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(new FiltroEmpresa { RazaoSocial = textFiltrarNome.Text });
                }
                else
                {
                    dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
                }
            }
            else
            {
                if (textFiltrarNome.Text != null)
                {
                    dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(new FiltroEmpresa { RazaoSocial = textFiltrarNome.Text, Ramo = (EnumRamoDaEmpresa)comboBoxEnumRamo.SelectedIndex });
                }
                else
                {
                    dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(new FiltroEmpresa { Ramo = (EnumRamoDaEmpresa)comboBoxEnumRamo.SelectedIndex });
                }
            }
        }
    }
}

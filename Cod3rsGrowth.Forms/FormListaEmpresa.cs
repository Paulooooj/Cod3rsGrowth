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
        private FiltroProduto filtroProduto;
        private FiltroEmpresa filtroEmpresa;

        public FormListaEmpresa(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoProduto = servicoProduto;
            filtroProduto = new FiltroProduto();
            filtroEmpresa = new FiltroEmpresa();
            comboBoxEnumRamo.SelectedIndex = 0;
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos();
        }

        private void textFiltrarRazaoSocial_TextChanged(object sender, EventArgs e)
        {
            filtroEmpresa.RazaoSocial = textFiltrarRazaoSocial.Text;
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(filtroEmpresa);
        }

        private void comboBoxEnumRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtroEmpresa.Ramo = (EnumRamoDaEmpresa)comboBoxEnumRamo.SelectedIndex;
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(filtroEmpresa);
        }

        private void textFiltrarNomeProduto_TextChanged(object sender, EventArgs e)
        {
            filtroProduto.Nome = textFiltrarNomeProduto.Text;
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtroProduto);
        }

        private void filtrarValorMinimoProduto_ValueChanged(object sender, EventArgs e)
        {
            filtroProduto.ValorMinimo = filtrarValorMinimoProduto.Value;
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtroProduto);
        }

        private void filtrarValorMaximoProduto_ValueChanged(object sender, EventArgs e)
        {
            filtroProduto.ValorMaximo = filtrarValorMaximoProduto.Value;
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtroProduto);
        }

        private void filtrarPorDataMinimaProduto_ValueChanged(object sender, EventArgs e)
        {
            filtroProduto.DataMinima = filtrarPorDataMinimaProduto.Value;
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtroProduto);
        }
       
        private void filtrarPorDataMaximaProduto_ValueChanged(object sender, EventArgs e)
        {
            filtroProduto.DataMaxima = filtrarPorDataMaximaProduto.Value;
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtroProduto);
        }

        private void aoClicarEmAdicionar(object sender, EventArgs e)
        {

        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using Microsoft.Extensions.Logging;

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
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos();
            comboBoxEnumRamo.SelectedIndex = 0;
        }

        private void textFiltrarRazaoSocial_TextChanged(object sender, EventArgs e)
        {
            var filtros = new FiltroEmpresa { RazaoSocial = textFiltrarRazaoSocial.Text, Ramo = (EnumRamoDaEmpresa)comboBoxEnumRamo.SelectedIndex };
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(filtros);
        }

        private void comboBoxEnumRamo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var filtros = new FiltroEmpresa { RazaoSocial = textFiltrarRazaoSocial.Text, Ramo = (EnumRamoDaEmpresa)comboBoxEnumRamo.SelectedIndex };
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos(filtros);
        }

        private void textFiltrarNomeProduto_TextChanged(object sender, EventArgs e)
        {
            var filtros = new FiltroProduto { Nome = textFiltrarNomeProduto.Text, ValorMinimo = filtrarValorMinimoProduto.Value, ValorMaximo = filtrarValorMaximoProduto.Value, DataCadastro = filtrarPorDataProduto.Value };
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtros);
        }

        private void filtrarValorMinimoProduto_ValueChanged(object sender, EventArgs e)
        {
            var filtros = new FiltroProduto { Nome = textFiltrarNomeProduto.Text, ValorMinimo = filtrarValorMinimoProduto.Value, ValorMaximo = filtrarValorMaximoProduto.Value, DataCadastro = filtrarPorDataProduto.Value};
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtros);
        }

        private void filtrarValorMaximoProduto_ValueChanged(object sender, EventArgs e)
        {
            var filtros = new FiltroProduto { Nome = textFiltrarNomeProduto.Text, ValorMinimo = filtrarValorMinimoProduto.Value, ValorMaximo = filtrarValorMaximoProduto.Value, DataCadastro = filtrarPorDataProduto.Value };
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtros);
        }

        private void filtrarPorDataProduto_ValueChanged(object sender, EventArgs e)
        {
            var filtros = new FiltroProduto { Nome = textFiltrarNomeProduto.Text, ValorMinimo = filtrarValorMinimoProduto.Value, ValorMaximo = filtrarValorMaximoProduto.Value, DataCadastro = filtrarPorDataProduto.Value };
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtros);
        }

        private void aoClicarEmAdicionar(object sender, EventArgs e)
        {

        }

    }
}

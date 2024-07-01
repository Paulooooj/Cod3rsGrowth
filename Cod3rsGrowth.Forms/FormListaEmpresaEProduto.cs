using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaEmpresaEProduto : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly ServicoProduto _servicoProduto;
        private FiltroProduto filtroProduto = new FiltroProduto();
        private FiltroEmpresa filtroEmpresa = new FiltroEmpresa();

        public FormListaEmpresaEProduto(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoProduto = servicoProduto;
            var valorTodosComboBox = 0;
            comboBoxEnumRamo.SelectedIndex = valorTodosComboBox;
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos();
            GerarColunaChaveEstrangeira();
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


        private void GerarColunaChaveEstrangeira()
        {
            dataGridViewProduto.AutoGenerateColumns = false;
            dataGridViewProduto.CellFormatting += dataGridViewProduto_CellFormatting;
        }

        private void dataGridViewProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            const string nomeColuna = "Empresa";
            if (dataGridViewProduto.Columns[e.ColumnIndex].HeaderText == nomeColuna)
            {
                var produto = dataGridViewProduto.Rows[e.RowIndex].DataBoundItem as Produto;
                if (produto != null)
                {
                    var empresa = _servicoEmpresa.ObterPorId(produto.EmpresaId);
                    if (empresa != null)
                    {
                        e.Value = empresa.RazaoSocial;
                    }
                }
            }
        }

        private void resetarFiltroData_Click(object sender, EventArgs e)
        {
            filtroProduto.DataMinima = null;
            filtroProduto.DataMaxima = null;
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos(filtroProduto);
        }

        private void aoClicarAdicionarEmpresa_Click(object sender, EventArgs e)
        {
            var cadastroEmpresa = new CadastroEmpresa(_servicoEmpresa);
            cadastroEmpresa.ShowDialog();
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
        }

        private void aoClicarAdicionarProduto_Click(object sender, EventArgs e)
        {
            var cadastrarProduto = new CadastroProduto(_servicoEmpresa, _servicoProduto);
            cadastrarProduto.ShowDialog();
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos();
        }
    }
}

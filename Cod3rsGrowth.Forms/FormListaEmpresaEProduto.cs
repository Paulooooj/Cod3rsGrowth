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

        private void aoClicarRemoverEmpresa_Click(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int colunaRazaoSocial = 1;

            try
            {
                var idEmpresaSerRemovida = (int)dataGridViewEmpresa.CurrentRow.Cells[colunaId].Value;
                var nomeEmpresaSerRemovida = dataGridViewEmpresa.CurrentRow.Cells[colunaRazaoSocial].Value;

                if (MessageBox.Show("Deseja mesmo Remover " + nomeEmpresaSerRemovida + "?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _servicoEmpresa.Deletar(idEmpresaSerRemovida);

                dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aoClicarDeveRemoverProduto_Click(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int colunaNome = 1;

            try
            {
                var idProdutoSerRemovido = (int)dataGridViewProduto.CurrentRow.Cells[colunaId].Value;
                var nomeProdutoSerRemovido = dataGridViewProduto.CurrentRow.Cells[colunaNome].Value;

                if (MessageBox.Show("Deseja mesmo Remover " + nomeProdutoSerRemovido + "?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _servicoProduto.Deletar(idProdutoSerRemovido);

                dataGridViewProduto.DataSource = _servicoProduto.ObterTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void aoClicarDeveAtualizarProduto_Click(object sender, EventArgs e)
        {
            const int colunaId = 0;
            if(dataGridViewProduto.SelectedRows.Count > 1)
            {
                MessageBox.Show("Erro: Selecione só uma linha.", "Erro ao Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idProdutoSerEditado = (int)dataGridViewProduto.CurrentRow.Cells[colunaId].Value;
            var atualizarProduto = new CadastroProduto(_servicoEmpresa, _servicoProduto, idProdutoSerEditado);
            atualizarProduto.ShowDialog();
            dataGridViewProduto.DataSource = _servicoProduto.ObterTodos();
        }

        private void aoClicarDeveAtualizarEmpresa_Click(object sender, EventArgs e)
        {
            const int colunaId = 0;
            if (dataGridViewEmpresa.SelectedRows.Count > 1)
            {
                MessageBox.Show("Erro: Selecione só uma linha.", "Erro ao Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idEmpresaSerEditado = (int)dataGridViewEmpresa.CurrentRow.Cells[colunaId].Value;
            var atualizarEmpresa = new CadastroEmpresa(_servicoEmpresa, idEmpresaSerEditado);
            atualizarEmpresa.ShowDialog();
            dataGridViewEmpresa.DataSource = _servicoEmpresa.ObterTodos();
        }
    }
}

using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListaEmpresaEProduto : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly ServicoProduto _servicoProduto;
        private FiltroProduto _filtroProduto = new FiltroProduto();
        private FiltroEmpresa _filtroEmpresa = new FiltroEmpresa();

        public FormListaEmpresaEProduto(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto)
        {
            InitializeComponent();

            _servicoEmpresa = servicoEmpresa;
            _servicoProduto = servicoProduto;
            const int valorTodosComboBox = 0;
            comboBoxEnumRamo.SelectedIndex = valorTodosComboBox;
            gridListaEmpresas.DataSource = _servicoEmpresa.ObterTodos();
            gridListaProduto.DataSource = _servicoProduto.ObterTodos();
            SubstituirEmpresaIdPorRazaoSocial();
            FormatarCNPJ();
        }

        private void FiltrarRazaoSocial(object sender, EventArgs e)
        {
            _filtroEmpresa.RazaoSocial = textFiltrarRazaoSocial.Text;
            gridListaEmpresas.DataSource = _servicoEmpresa.ObterTodos(_filtroEmpresa);
        }

        private void ComboBoxEnumRamo(object sender, EventArgs e)
        {
            _filtroEmpresa.Ramo = (EnumRamoDaEmpresa)comboBoxEnumRamo.SelectedIndex;
            gridListaEmpresas.DataSource = _servicoEmpresa.ObterTodos(_filtroEmpresa);
        }

        private void FiltrarNomeProduto(object sender, EventArgs e)
        {
            _filtroProduto.Nome = textFiltrarNomeProduto.Text;
            gridListaProduto.DataSource = _servicoProduto.ObterTodos(_filtroProduto);
        }

        private void FiltrarValorMinimoProduto(object sender, EventArgs e)
        {
            _filtroProduto.ValorMinimo = filtrarValorMinimoProduto.Value;
            gridListaProduto.DataSource = _servicoProduto.ObterTodos(_filtroProduto);
        }

        private void FiltrarValorMaximoProduto(object sender, EventArgs e)
        {
            _filtroProduto.ValorMaximo = filtrarValorMaximoProduto.Value;
            gridListaProduto.DataSource = _servicoProduto.ObterTodos(_filtroProduto);
        }

        private void FiltrarPorDataMinimaProduto(object sender, EventArgs e)
        {
            _filtroProduto.DataMinima = filtrarPorDataMinimaProduto.Value;
            gridListaProduto.DataSource = _servicoProduto.ObterTodos(_filtroProduto);
        }

        private void FiltrarPorDataMaximaProduto(object sender, EventArgs e)
        {
            _filtroProduto.DataMaxima = filtrarPorDataMaximaProduto.Value;
            gridListaProduto.DataSource = _servicoProduto.ObterTodos(_filtroProduto);
        }


        private void SubstituirEmpresaIdPorRazaoSocial()
        {
            gridListaProduto.AutoGenerateColumns = false;
            gridListaProduto.CellFormatting += DataGridViewProduto_CellFormatting;
        }

        private void DataGridViewProduto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            const string nomeColuna = "Empresa";
            if (gridListaProduto.Columns[e.ColumnIndex].HeaderText == nomeColuna)
            {
                var produto = gridListaProduto.Rows[e.RowIndex].DataBoundItem as Produto;
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

        private void ResetarFiltroData(object sender, EventArgs e)
        {
            filtrarPorDataMinimaProduto.Value = DateTime.Now;
            filtrarPorDataMaximaProduto.Value = DateTime.Now;
            _filtroProduto.DataMinima = null;
            _filtroProduto.DataMaxima = null;
            gridListaProduto.DataSource = _servicoProduto.ObterTodos(_filtroProduto);
        }

        private void AoClicarAdicionarEmpresa(object sender, EventArgs e)
        {
            var FormCadastroEmpresa = new CadastroEmpresa(_servicoEmpresa);
            FormCadastroEmpresa.ShowDialog();
            gridListaEmpresas.DataSource = _servicoEmpresa.ObterTodos();
        }

        private void AoClicarAdicionarProduto(object sender, EventArgs e)
        {
            var FormCadastrarProduto = new CadastroProduto(_servicoEmpresa, _servicoProduto);
            FormCadastrarProduto.ShowDialog();
            gridListaProduto.DataSource = _servicoProduto.ObterTodos();
        }

        private void AoClicarRemoverEmpresa(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int colunaRazaoSocial = 1;
            const int limiteLinhasSelecionadas = 1;

            if (gridListaEmpresas.SelectedRows.Count != limiteLinhasSelecionadas)
            {
                MessageBox.Show("Erro ao selecionar linhas.", "Erro ao Remover", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var idEmpresaSerRemovida = (int)gridListaEmpresas.CurrentRow.Cells[colunaId].Value;
                var nomeEmpresaSerRemovida = gridListaEmpresas.CurrentRow.Cells[colunaRazaoSocial].Value;

                if (MessageBox.Show("Ao remover " + nomeEmpresaSerRemovida + " vai ser removido todos os produtos relacionados, deseja remover?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _servicoEmpresa.Deletar(idEmpresaSerRemovida);

                gridListaEmpresas.DataSource = _servicoEmpresa.ObterTodos();
                gridListaProduto.DataSource = _servicoProduto.ObterTodos();
            }
            catch (Exception exception)
            {
                const string tituloDoErro = "Erro inesperado";
                MessageBox.Show(exception.Message);
            }
        }

        private void AoClicarDeveRemoverProduto(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int colunaNome = 1;
            const int limiteLinhasSelecionadas = 1;

            if (gridListaProduto.SelectedRows.Count != limiteLinhasSelecionadas)
            {
                MessageBox.Show("Erro ao selecionar linhas.", "Erro ao Remover", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var idProdutoSerRemovido = (int)gridListaProduto.CurrentRow.Cells[colunaId].Value;
                var nomeProdutoSerRemovido = gridListaProduto.CurrentRow.Cells[colunaNome].Value;

                if (MessageBox.Show("Deseja mesmo Remover " + nomeProdutoSerRemovido + "?", "Cadastro de Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    _servicoProduto.Deletar(idProdutoSerRemovido);

                gridListaProduto.DataSource = _servicoProduto.ObterTodos();
            }
            catch (Exception exception)
            {
                const string tituloDoErro = "Erro inesperado";
                MessageBox.Show(exception.Message);
            }
        }

        private void AoClicarDeveAtualizarProduto(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int limiteLinhasSelecionadas = 1;

            if (gridListaProduto.SelectedRows.Count != limiteLinhasSelecionadas)
            {
                MessageBox.Show("Erro ao selecionar linhas.", "Erro ao Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idProdutoSerEditado = (int)gridListaProduto.CurrentRow.Cells[colunaId].Value;
            var produto = _servicoProduto.ObterPorId(idProdutoSerEditado);
            var FormsCadastrarProduto = new CadastroProduto(_servicoEmpresa, _servicoProduto, produto);
            FormsCadastrarProduto.ShowDialog();
            gridListaProduto.DataSource = _servicoProduto.ObterTodos();
        }

        private void AoClicarDeveAtualizarEmpresa(object sender, EventArgs e)
        {
            const int colunaId = 0;
            const int limiteLinhasSelecionadas = 1;
            if (gridListaEmpresas.SelectedRows.Count != limiteLinhasSelecionadas)
            {
                MessageBox.Show("Erro ao selecionar linhas.", "Erro ao Editar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idEmpresaSerEditado = (int)gridListaEmpresas.CurrentRow.Cells[colunaId].Value;
            var empresa = _servicoEmpresa.ObterPorId(idEmpresaSerEditado);
            var FormCadastrarProduto = new CadastroEmpresa(_servicoEmpresa, empresa);
            FormCadastrarProduto.ShowDialog();
            gridListaEmpresas.DataSource = _servicoEmpresa.ObterTodos();
        }

        private void FormatarCNPJ()
        {
            gridListaEmpresas.AutoGenerateColumns = false;
            gridListaEmpresas.CellFormatting += FormatarCelulas;
        }

        private void FormatarCelulas(object sender, DataGridViewCellFormattingEventArgs e)
        {
            const string nomeColuna = "CNPJ";
            if (gridListaEmpresas.Columns[e.ColumnIndex].HeaderText == nomeColuna)
            {
                var empresa = gridListaEmpresas.Rows[e.RowIndex].DataBoundItem as Empresa;
                if (empresa != null)
                {
                    var objetoEmpresaRetornado = _servicoEmpresa.ObterPorId(empresa.Id);
                    if (objetoEmpresaRetornado != null)
                    {
                        e.Value = Regex.Replace(empresa.CNPJ, "(\\d{2})(\\d{" +
                            "3})(\\d{3})(\\d{4})(\\d{2})", "$1.$2.$3/$4-$5");
                    }
                }
            }
        }
        private static void MostrarMensagemErro(string tituloErro, string mensagemErro)
        {
            MessageBox.Show(mensagemErro, tituloErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

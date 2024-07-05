using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Infra.Filtros;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using System.Data;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroProduto : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        private readonly ServicoProduto _servicoProduto;
        private readonly Produto? _produto;

        public CadastroProduto(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto, Produto? produto = null)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoProduto = servicoProduto;
            _produto = produto;
            var listaEmpresa = _servicoEmpresa.ObterTodos().Select(x => x.RazaoSocial);
            tabelaEmpresas.DataSource = listaEmpresa.ToList();
            MostrarInformacoesAoAtualizar();
        }

        private void MostrarInformacoesAoAtualizar()
        {
            if (_produto != null)
            {
                nomeProduto.Text = _produto.Nome;
                valorProduto.Value = _produto.ValorDoProduto;
                dataCadastroProduto.Value = _produto.DataCadastro;
                if (_produto.TemDataValidade)
                {
                    temDataDeValidade.CheckState = CheckState.Checked;
                    dataDeValidade.Value = (DateTime)_produto.DataValidade;
                    dataDeValidade.Visible = true;
                    labelTemDataValidade.Visible = true;
                }
                tabelaEmpresas.SelectedItem = _servicoEmpresa.ObterPorId(_produto.EmpresaId).RazaoSocial;
            }
        }

        private void TemDataDeValidadeVerdadeiro(object sender, EventArgs e)
        {
            if (temDataDeValidade.Checked)
            {
                dataDeValidade.Visible = temDataDeValidade.Checked;
                labelTemDataValidade.Visible = temDataDeValidade.Checked;
                return;
            }
            dataDeValidade.Visible = temDataDeValidade.Checked;
            labelTemDataValidade.Visible = temDataDeValidade.Checked;
        }

        private void AoClicarDeveCancelarAdicionarProduto(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AoClicarDeveSalvar(object sender, EventArgs e)
        {
            try
            {
                var idEmpresa = _servicoEmpresa.ObterTodos(new FiltroEmpresa { RazaoSocial = tabelaEmpresas.SelectedItem.ToString() })
                    .Select(x => x.Id).FirstOrDefault();

                var produto = new Produto
                {
                    Nome = nomeProduto.Text,
                    ValorDoProduto = valorProduto.Value,
                    DataCadastro = dataCadastroProduto.Value.Date,
                    TemDataValidade = temDataDeValidade.Checked,
                    DataValidade = temDataDeValidade.Checked
                                    ? dataDeValidade.Value
                                    : null,
                    EmpresaId = idEmpresa
                };

                SalvarDados(produto);
                this.Close();
            }
            catch (ValidationException validationException)
            {
                var listaDeErros = validationException.Errors.ToList();
                var mensagemErro = "";

                listaDeErros.ForEach(erro => mensagemErro += erro.ToString() + "\n");
                const string tituloDoErro = "Erro de validação";

                MostrarMensagemErro(tituloDoErro, mensagemErro);
            }
            catch (Exception exception)
            {
                const string tituloDoErro = "Erro inesperado";
                MessageBox.Show(exception.Message);
            }
        }

        private void SalvarDados(Produto produto)
        {
            if (_produto != null)
            {
                produto.Id = _produto.Id;
                _servicoProduto.Atualizar(produto);
                return;
            }
            _servicoProduto.Adicionar(produto);
        }

        private static void MostrarMensagemErro(string tituloErro, string mensagemErro)
        {
            MessageBox.Show(mensagemErro, tituloErro, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

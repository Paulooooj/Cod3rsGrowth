using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Servico.Servicos;
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
            var filtro = _servicoEmpresa.ObterTodos().Select(x => x.RazaoSocial);
            mostrarTodasAsEmpresas.DataSource = filtro.ToList();
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
                mostrarTodasAsEmpresas.SelectedItem = _servicoEmpresa.ObterPorId(_produto.EmpresaId).RazaoSocial;
            }
        }

        private void temDataDeValidadeVerdadeiro_CheckedChanged(object sender, EventArgs e)
        {
            if (temDataDeValidade.Checked)
            {
                dataDeValidade.Visible = true;
                labelTemDataValidade.Visible = true;
                return;
            }
            dataDeValidade.Visible = false;
            labelTemDataValidade.Visible = false;

        }

        private void aoClicarDeveCancelarAdicionarProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aoClicarDeveSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var pegarOIdEmpresa = _servicoEmpresa.ObterTodos()
                    .Where(x => x.RazaoSocial == mostrarTodasAsEmpresas.SelectedItem.ToString())
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
                    EmpresaId = pegarOIdEmpresa
                };

                SalvarDados(produto);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
    }
}

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
        private readonly int _id;

        public CadastroProduto(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
            _servicoProduto = servicoProduto;
            var filtro = _servicoEmpresa.ObterTodos().Select(x => x.RazaoSocial);
            mostrarTodasAsEmpresas.DataSource = filtro.ToList();
        }

        public CadastroProduto(ServicoEmpresa servicoEmpresa, ServicoProduto servicoProduto, int id) : this(servicoEmpresa, servicoProduto)
        {
            _id = id;
            MostrarInformacoesAoAtualizar();
        }

        private void MostrarInformacoesAoAtualizar()
        {
            var produto = _servicoProduto.ObterPorId(_id);
            nomeProduto.Text = produto.Nome;
            valorProduto.Value = produto.ValorDoProduto;
            dataCadastroProduto.Value = produto.DataCadastro;
            if (produto.TemDataValidade)
            {
                temDataDeValidade.CheckState = CheckState.Checked;
                dataDeValidade.Value = (DateTime)produto.DataValidade;
                dataDeValidade.Visible = true;
                labelTemDataValidade.Visible = true;
            }
            mostrarTodasAsEmpresas.SelectedItem = _servicoEmpresa.ObterPorId(produto.EmpresaId).RazaoSocial;
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
                var produto = new Produto();
                produto.Nome = nomeProduto.Text;
                produto.ValorDoProduto = valorProduto.Value;
                produto.DataCadastro = dataCadastroProduto.Value.Date;
                produto.TemDataValidade = temDataDeValidade.Checked;
                if (temDataDeValidade.Checked)
                    produto.DataValidade = dataDeValidade.Value;
                var pegarOIdEmpresa = _servicoEmpresa.ObterTodos()
                    .Where(x => x.RazaoSocial == mostrarTodasAsEmpresas.SelectedItem.ToString())
                    .Select(x => x.Id).FirstOrDefault();
                produto.EmpresaId = pegarOIdEmpresa;

                if (_id > 0)
                {
                    produto.Id = _id;
                    _servicoProduto.Atualizar(produto);
                }
                else
                    _servicoProduto.Adicionar(produto);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

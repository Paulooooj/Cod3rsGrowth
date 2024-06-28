using Cod3rsGrowth.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms
{
    public partial class CadastroProduto : Form
    {
        private readonly ServicoEmpresa _servicoEmpresa;
        public CadastroProduto(ServicoEmpresa servicoEmpresa)
        {
            InitializeComponent();
            _servicoEmpresa = servicoEmpresa;
        }

        private void temDataDeValidadeVerdadeiro_CheckedChanged(object sender, EventArgs e)
        {
            if (temDataDeValidadeVerdadeiro.Checked == true)
                dataDeValidade.Visible = true;
            else
                dataDeValidade.Visible = false;
        }

        private void mostrarTodasAsEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarTodasAsEmpresas.DataSource = _servicoEmpresa.ObterTodos().Select(x => x.RazaoSocial);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

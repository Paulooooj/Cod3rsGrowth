namespace Cod3rsGrowth.Forms
{
    partial class FormListaProduto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoProdutoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            temDataValidaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataValidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            produtoBindingSource = new BindingSource(components);
            menuStrip1 = new MenuStrip();
            empresasToolStripMenuItem = new ToolStripMenuItem();
            listaDeEmpresasToolStripMenuItem = new ToolStripMenuItem();
            cadastrarEmpresaToolStripMenuItem = new ToolStripMenuItem();
            produtoToolStripMenuItem = new ToolStripMenuItem();
            listaDeProdutosToolStripMenuItem = new ToolStripMenuItem();
            cadastrarProdutosToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, valorDoProdutoDataGridViewTextBoxColumn, dataCadastroDataGridViewTextBoxColumn, temDataValidaDataGridViewCheckBoxColumn, dataValidadeDataGridViewTextBoxColumn, empresaIdDataGridViewTextBoxColumn });
            dataGridView1.DataSource = produtoBindingSource;
            dataGridView1.Location = new Point(-1, 152);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(803, 286);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // valorDoProdutoDataGridViewTextBoxColumn
            // 
            valorDoProdutoDataGridViewTextBoxColumn.DataPropertyName = "ValorDoProduto";
            valorDoProdutoDataGridViewTextBoxColumn.HeaderText = "ValorDoProduto";
            valorDoProdutoDataGridViewTextBoxColumn.Name = "valorDoProdutoDataGridViewTextBoxColumn";
            // 
            // dataCadastroDataGridViewTextBoxColumn
            // 
            dataCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataCadastro";
            dataCadastroDataGridViewTextBoxColumn.HeaderText = "DataCadastro";
            dataCadastroDataGridViewTextBoxColumn.Name = "dataCadastroDataGridViewTextBoxColumn";
            // 
            // temDataValidaDataGridViewCheckBoxColumn
            // 
            temDataValidaDataGridViewCheckBoxColumn.DataPropertyName = "TemDataValida";
            temDataValidaDataGridViewCheckBoxColumn.HeaderText = "TemDataValida";
            temDataValidaDataGridViewCheckBoxColumn.Name = "temDataValidaDataGridViewCheckBoxColumn";
            // 
            // dataValidadeDataGridViewTextBoxColumn
            // 
            dataValidadeDataGridViewTextBoxColumn.DataPropertyName = "DataValidade";
            dataValidadeDataGridViewTextBoxColumn.HeaderText = "DataValidade";
            dataValidadeDataGridViewTextBoxColumn.Name = "dataValidadeDataGridViewTextBoxColumn";
            // 
            // empresaIdDataGridViewTextBoxColumn
            // 
            empresaIdDataGridViewTextBoxColumn.DataPropertyName = "EmpresaId";
            empresaIdDataGridViewTextBoxColumn.HeaderText = "EmpresaId";
            empresaIdDataGridViewTextBoxColumn.Name = "empresaIdDataGridViewTextBoxColumn";
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Dominio.Entidades.Produto);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { empresasToolStripMenuItem, produtoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(744, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // empresasToolStripMenuItem
            // 
            empresasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaDeEmpresasToolStripMenuItem, cadastrarEmpresaToolStripMenuItem });
            empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            empresasToolStripMenuItem.Size = new Size(69, 20);
            empresasToolStripMenuItem.Text = "Empresas";
            // 
            // listaDeEmpresasToolStripMenuItem
            // 
            listaDeEmpresasToolStripMenuItem.Name = "listaDeEmpresasToolStripMenuItem";
            listaDeEmpresasToolStripMenuItem.Size = new Size(172, 22);
            listaDeEmpresasToolStripMenuItem.Text = "Lista de Empresas";
            // 
            // cadastrarEmpresaToolStripMenuItem
            // 
            cadastrarEmpresaToolStripMenuItem.Name = "cadastrarEmpresaToolStripMenuItem";
            cadastrarEmpresaToolStripMenuItem.Size = new Size(172, 22);
            cadastrarEmpresaToolStripMenuItem.Text = "Cadastrar Empresa";
            // 
            // produtoToolStripMenuItem
            // 
            produtoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaDeProdutosToolStripMenuItem, cadastrarProdutosToolStripMenuItem });
            produtoToolStripMenuItem.Name = "produtoToolStripMenuItem";
            produtoToolStripMenuItem.Size = new Size(62, 20);
            produtoToolStripMenuItem.Text = "Produto";
            // 
            // listaDeProdutosToolStripMenuItem
            // 
            listaDeProdutosToolStripMenuItem.Name = "listaDeProdutosToolStripMenuItem";
            listaDeProdutosToolStripMenuItem.Size = new Size(175, 22);
            listaDeProdutosToolStripMenuItem.Text = "Lista de Produtos";
            // 
            // cadastrarProdutosToolStripMenuItem
            // 
            cadastrarProdutosToolStripMenuItem.Name = "cadastrarProdutosToolStripMenuItem";
            cadastrarProdutosToolStripMenuItem.Size = new Size(175, 22);
            cadastrarProdutosToolStripMenuItem.Text = "Cadastrar Produtos";
            // 
            // FormListaProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(744, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormListaProduto";
            Text = "FormListaProduto";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoProdutoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataCadastroDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn temDataValidaDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataValidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn empresaIdDataGridViewTextBoxColumn;
        private BindingSource produtoBindingSource;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem empresasToolStripMenuItem;
        private ToolStripMenuItem listaDeEmpresasToolStripMenuItem;
        private ToolStripMenuItem cadastrarEmpresaToolStripMenuItem;
        private ToolStripMenuItem produtoToolStripMenuItem;
        private ToolStripMenuItem listaDeProdutosToolStripMenuItem;
        private ToolStripMenuItem cadastrarProdutosToolStripMenuItem;
    }
}
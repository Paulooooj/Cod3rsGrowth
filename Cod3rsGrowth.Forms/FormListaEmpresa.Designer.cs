namespace Cod3rsGrowth.Forms
{
    partial class FormListaEmpresa
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razaoSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cNPJDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ramoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaBindingSource = new BindingSource(components);
            menuStrip1 = new MenuStrip();
            empresaToolStripMenuItem = new ToolStripMenuItem();
            listaDeEmpresasToolStripMenuItem = new ToolStripMenuItem();
            cadastrarEmpresaToolStripMenuItem = new ToolStripMenuItem();
            produtoToolStripMenuItem = new ToolStripMenuItem();
            listaDeProdutosToolStripMenuItem = new ToolStripMenuItem();
            cadastrarProdutosToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, razaoSocialDataGridViewTextBoxColumn, cNPJDataGridViewTextBoxColumn, ramoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = empresaBindingSource;
            dataGridView1.Location = new Point(-2, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(802, 323);
            dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // razaoSocialDataGridViewTextBoxColumn
            // 
            razaoSocialDataGridViewTextBoxColumn.DataPropertyName = "RazaoSocial";
            razaoSocialDataGridViewTextBoxColumn.HeaderText = "RazaoSocial";
            razaoSocialDataGridViewTextBoxColumn.Name = "razaoSocialDataGridViewTextBoxColumn";
            // 
            // cNPJDataGridViewTextBoxColumn
            // 
            cNPJDataGridViewTextBoxColumn.DataPropertyName = "CNPJ";
            cNPJDataGridViewTextBoxColumn.HeaderText = "CNPJ";
            cNPJDataGridViewTextBoxColumn.Name = "cNPJDataGridViewTextBoxColumn";
            // 
            // ramoDataGridViewTextBoxColumn
            // 
            ramoDataGridViewTextBoxColumn.DataPropertyName = "Ramo";
            ramoDataGridViewTextBoxColumn.HeaderText = "Ramo";
            ramoDataGridViewTextBoxColumn.Name = "ramoDataGridViewTextBoxColumn";
            // 
            // empresaBindingSource
            // 
            empresaBindingSource.DataSource = typeof(Dominio.Entidades.Empresa);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { empresaToolStripMenuItem, produtoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // empresaToolStripMenuItem
            // 
            empresaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listaDeEmpresasToolStripMenuItem, cadastrarEmpresaToolStripMenuItem });
            empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            empresaToolStripMenuItem.Size = new Size(64, 20);
            empresaToolStripMenuItem.Text = "Empresa";
            // 
            // listaDeEmpresasToolStripMenuItem
            // 
            listaDeEmpresasToolStripMenuItem.Name = "listaDeEmpresasToolStripMenuItem";
            listaDeEmpresasToolStripMenuItem.Size = new Size(180, 22);
            listaDeEmpresasToolStripMenuItem.Text = "Lista de Empresas";
            // 
            // cadastrarEmpresaToolStripMenuItem
            // 
            cadastrarEmpresaToolStripMenuItem.Name = "cadastrarEmpresaToolStripMenuItem";
            cadastrarEmpresaToolStripMenuItem.Size = new Size(180, 22);
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
            listaDeProdutosToolStripMenuItem.Size = new Size(180, 22);
            listaDeProdutosToolStripMenuItem.Text = "Lista de Produtos";
            // 
            // cadastrarProdutosToolStripMenuItem
            // 
            cadastrarProdutosToolStripMenuItem.Name = "cadastrarProdutosToolStripMenuItem";
            cadastrarProdutosToolStripMenuItem.Size = new Size(180, 22);
            cadastrarProdutosToolStripMenuItem.Text = "Cadastrar Produto";
            // 
            // FormListaEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormListaEmpresa";
            Text = "FormListaEmpresa";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razaoSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cNPJDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ramoDataGridViewTextBoxColumn;
        private BindingSource empresaBindingSource;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem empresaToolStripMenuItem;
        private ToolStripMenuItem listaDeEmpresasToolStripMenuItem;
        private ToolStripMenuItem cadastrarEmpresaToolStripMenuItem;
        private ToolStripMenuItem produtoToolStripMenuItem;
        private ToolStripMenuItem listaDeProdutosToolStripMenuItem;
        private ToolStripMenuItem cadastrarProdutosToolStripMenuItem;
    }
}

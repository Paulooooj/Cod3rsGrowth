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
            dataGridViewEmpresa = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razaoSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cNPJDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ramoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaBindingSource = new BindingSource(components);
            textFiltrarNome = new TextBox();
            comboBoxEnumRamo = new ComboBox();
            tabControl1 = new TabControl();
            tabPagEmpresa = new TabPage();
            tabPageProduto = new TabPage();
            dataGridViewProduto = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoProdutoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataValidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            produtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            tabPagEmpresa.SuspendLayout();
            tabPageProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewEmpresa
            // 
            dataGridViewEmpresa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewEmpresa.AutoGenerateColumns = false;
            dataGridViewEmpresa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEmpresa.BackgroundColor = Color.White;
            dataGridViewEmpresa.BorderStyle = BorderStyle.None;
            dataGridViewEmpresa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmpresa.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, razaoSocialDataGridViewTextBoxColumn, cNPJDataGridViewTextBoxColumn, ramoDataGridViewTextBoxColumn });
            dataGridViewEmpresa.DataSource = empresaBindingSource;
            dataGridViewEmpresa.Location = new Point(0, 67);
            dataGridViewEmpresa.Name = "dataGridViewEmpresa";
            dataGridViewEmpresa.RowHeadersVisible = false;
            dataGridViewEmpresa.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewEmpresa.Size = new Size(656, 323);
            dataGridViewEmpresa.TabIndex = 0;
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
            // textFiltrarNome
            // 
            textFiltrarNome.Location = new Point(8, 22);
            textFiltrarNome.Name = "textFiltrarNome";
            textFiltrarNome.PlaceholderText = "Razão Social";
            textFiltrarNome.Size = new Size(178, 23);
            textFiltrarNome.TabIndex = 2;
            textFiltrarNome.TextChanged += textFiltrarNome_TextChanged;
            // 
            // comboBoxEnumRamo
            // 
            comboBoxEnumRamo.FormattingEnabled = true;
            comboBoxEnumRamo.Items.AddRange(new object[] { "Todos", "Industria", "Comercio", "Servico" });
            comboBoxEnumRamo.Location = new Point(212, 22);
            comboBoxEnumRamo.Name = "comboBoxEnumRamo";
            comboBoxEnumRamo.Size = new Size(113, 23);
            comboBoxEnumRamo.TabIndex = 4;
            comboBoxEnumRamo.SelectedIndexChanged += comboBoxEnumRamo_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPagEmpresa);
            tabControl1.Controls.Add(tabPageProduto);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(664, 424);
            tabControl1.TabIndex = 5;
            // 
            // tabPagEmpresa
            // 
            tabPagEmpresa.Controls.Add(dataGridViewEmpresa);
            tabPagEmpresa.Controls.Add(comboBoxEnumRamo);
            tabPagEmpresa.Controls.Add(textFiltrarNome);
            tabPagEmpresa.Location = new Point(4, 24);
            tabPagEmpresa.Name = "tabPagEmpresa";
            tabPagEmpresa.Padding = new Padding(3);
            tabPagEmpresa.Size = new Size(656, 396);
            tabPagEmpresa.TabIndex = 0;
            tabPagEmpresa.Text = "Empresa";
            tabPagEmpresa.UseVisualStyleBackColor = true;
            // 
            // tabPageProduto
            // 
            tabPageProduto.Controls.Add(dataGridViewProduto);
            tabPageProduto.Location = new Point(4, 24);
            tabPageProduto.Name = "tabPageProduto";
            tabPageProduto.Padding = new Padding(3);
            tabPageProduto.Size = new Size(656, 396);
            tabPageProduto.TabIndex = 1;
            tabPageProduto.Text = "Produto";
            tabPageProduto.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProduto
            // 
            dataGridViewProduto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProduto.AutoGenerateColumns = false;
            dataGridViewProduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduto.BackgroundColor = Color.White;
            dataGridViewProduto.BorderStyle = BorderStyle.None;
            dataGridViewProduto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduto.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn, valorDoProdutoDataGridViewTextBoxColumn, dataCadastroDataGridViewTextBoxColumn, dataValidadeDataGridViewTextBoxColumn, empresaIdDataGridViewTextBoxColumn });
            dataGridViewProduto.DataSource = produtoBindingSource;
            dataGridViewProduto.Location = new Point(0, 106);
            dataGridViewProduto.Name = "dataGridViewProduto";
            dataGridViewProduto.RowHeadersVisible = false;
            dataGridViewProduto.RowTemplate.Height = 25;
            dataGridViewProduto.Size = new Size(656, 278);
            dataGridViewProduto.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
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
            // FormListaEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(668, 421);
            Controls.Add(tabControl1);
            Name = "FormListaEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormListaEmpresa";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresa).EndInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            tabPagEmpresa.ResumeLayout(false);
            tabPagEmpresa.PerformLayout();
            tabPageProduto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewEmpresa;
        private BindingSource empresaBindingSource;
        private TextBox textFiltrarNome;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razaoSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cNPJDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ramoDataGridViewTextBoxColumn;
        private ComboBox comboBoxEnumRamo;
        private TabControl tabControl1;
        private TabPage tabPagEmpresa;
        private TabPage tabPageProduto;
        private DataGridView dataGridViewProduto;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoProdutoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataCadastroDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn temDataValidaDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataValidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn empresaIdDataGridViewTextBoxColumn;
        private BindingSource produtoBindingSource;
    }
}

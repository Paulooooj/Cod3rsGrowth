namespace Cod3rsGrowth.Forms
{
    partial class FormListaEmpresaEProduto
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            gridListaEmpresas = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razaoSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cNPJDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ramoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaBindingSource = new BindingSource(components);
            textFiltrarRazaoSocial = new TextBox();
            comboBoxEnumRamo = new ComboBox();
            tabControl1 = new TabControl();
            tabPagEmpresa = new TabPage();
            aoClicarDeveAtualizarEmpresa = new Button();
            aoClicarRemoverEmpresa = new Button();
            aoClicarAdicionarEmpresa = new Button();
            tabPageProduto = new TabPage();
            aoClicarDeveAtualizarProduto = new Button();
            aoClicarDeveRemoverProduto = new Button();
            aoClicarAdicionarProduto = new Button();
            resetarFiltroData = new Button();
            label4 = new Label();
            label3 = new Label();
            filtrarPorDataMaximaProduto = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            filtrarValorMaximoProduto = new NumericUpDown();
            filtrarValorMinimoProduto = new NumericUpDown();
            filtrarPorDataMinimaProduto = new DateTimePicker();
            textFiltrarNomeProduto = new TextBox();
            gridListaProduto = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoProdutoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            TemDataValidade = new DataGridViewCheckBoxColumn();
            dataValidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            produtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)gridListaEmpresas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            tabPagEmpresa.SuspendLayout();
            tabPageProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMaximoProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMinimoProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridListaProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // gridListaEmpresas
            // 
            gridListaEmpresas.AllowUserToDeleteRows = false;
            gridListaEmpresas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridListaEmpresas.AutoGenerateColumns = false;
            gridListaEmpresas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridListaEmpresas.BackgroundColor = Color.White;
            gridListaEmpresas.BorderStyle = BorderStyle.None;
            gridListaEmpresas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridListaEmpresas.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, razaoSocialDataGridViewTextBoxColumn, cNPJDataGridViewTextBoxColumn, ramoDataGridViewTextBoxColumn });
            gridListaEmpresas.DataSource = empresaBindingSource;
            gridListaEmpresas.Location = new Point(3, 64);
            gridListaEmpresas.Name = "gridListaEmpresas";
            gridListaEmpresas.ReadOnly = true;
            gridListaEmpresas.RowHeadersVisible = false;
            gridListaEmpresas.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            gridListaEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridListaEmpresas.Size = new Size(687, 248);
            gridListaEmpresas.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 42;
            // 
            // razaoSocialDataGridViewTextBoxColumn
            // 
            razaoSocialDataGridViewTextBoxColumn.DataPropertyName = "RazaoSocial";
            razaoSocialDataGridViewTextBoxColumn.HeaderText = "Razao Social";
            razaoSocialDataGridViewTextBoxColumn.Name = "razaoSocialDataGridViewTextBoxColumn";
            razaoSocialDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cNPJDataGridViewTextBoxColumn
            // 
            cNPJDataGridViewTextBoxColumn.DataPropertyName = "CNPJ";
            dataGridViewCellStyle1.NullValue = null;
            cNPJDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            cNPJDataGridViewTextBoxColumn.HeaderText = "CNPJ";
            cNPJDataGridViewTextBoxColumn.Name = "cNPJDataGridViewTextBoxColumn";
            cNPJDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ramoDataGridViewTextBoxColumn
            // 
            ramoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ramoDataGridViewTextBoxColumn.DataPropertyName = "Ramo";
            ramoDataGridViewTextBoxColumn.HeaderText = "Ramo";
            ramoDataGridViewTextBoxColumn.Name = "ramoDataGridViewTextBoxColumn";
            ramoDataGridViewTextBoxColumn.ReadOnly = true;
            ramoDataGridViewTextBoxColumn.Width = 63;
            // 
            // empresaBindingSource
            // 
            empresaBindingSource.DataSource = typeof(Dominio.Entidades.Empresa);
            // 
            // textFiltrarRazaoSocial
            // 
            textFiltrarRazaoSocial.Location = new Point(8, 22);
            textFiltrarRazaoSocial.Name = "textFiltrarRazaoSocial";
            textFiltrarRazaoSocial.PlaceholderText = "Pesquisar Razão Social";
            textFiltrarRazaoSocial.Size = new Size(333, 23);
            textFiltrarRazaoSocial.TabIndex = 2;
            textFiltrarRazaoSocial.TextChanged += FiltrarRazaoSocial;
            // 
            // comboBoxEnumRamo
            // 
            comboBoxEnumRamo.FormattingEnabled = true;
            comboBoxEnumRamo.Items.AddRange(new object[] { "Todos", "Industria", "Comercio", "Servico" });
            comboBoxEnumRamo.Location = new Point(374, 22);
            comboBoxEnumRamo.Name = "comboBoxEnumRamo";
            comboBoxEnumRamo.Size = new Size(113, 23);
            comboBoxEnumRamo.TabIndex = 4;
            comboBoxEnumRamo.SelectedIndexChanged += ComboBoxEnumRamo;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPagEmpresa);
            tabControl1.Controls.Add(tabPageProduto);
            tabControl1.Location = new Point(0, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(701, 381);
            tabControl1.TabIndex = 5;
            // 
            // tabPagEmpresa
            // 
            tabPagEmpresa.Controls.Add(aoClicarDeveAtualizarEmpresa);
            tabPagEmpresa.Controls.Add(aoClicarRemoverEmpresa);
            tabPagEmpresa.Controls.Add(aoClicarAdicionarEmpresa);
            tabPagEmpresa.Controls.Add(gridListaEmpresas);
            tabPagEmpresa.Controls.Add(comboBoxEnumRamo);
            tabPagEmpresa.Controls.Add(textFiltrarRazaoSocial);
            tabPagEmpresa.Location = new Point(4, 24);
            tabPagEmpresa.Name = "tabPagEmpresa";
            tabPagEmpresa.Padding = new Padding(3);
            tabPagEmpresa.Size = new Size(693, 353);
            tabPagEmpresa.TabIndex = 0;
            tabPagEmpresa.Text = "Empresa";
            tabPagEmpresa.UseVisualStyleBackColor = true;
            // 
            // aoClicarDeveAtualizarEmpresa
            // 
            aoClicarDeveAtualizarEmpresa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarDeveAtualizarEmpresa.Location = new Point(513, 318);
            aoClicarDeveAtualizarEmpresa.Name = "aoClicarDeveAtualizarEmpresa";
            aoClicarDeveAtualizarEmpresa.Size = new Size(75, 23);
            aoClicarDeveAtualizarEmpresa.TabIndex = 7;
            aoClicarDeveAtualizarEmpresa.Text = "Editar";
            aoClicarDeveAtualizarEmpresa.UseVisualStyleBackColor = true;
            aoClicarDeveAtualizarEmpresa.Click += AoClicarDeveAtualizarEmpresa;
            // 
            // aoClicarRemoverEmpresa
            // 
            aoClicarRemoverEmpresa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarRemoverEmpresa.Location = new Point(594, 318);
            aoClicarRemoverEmpresa.Name = "aoClicarRemoverEmpresa";
            aoClicarRemoverEmpresa.Size = new Size(75, 23);
            aoClicarRemoverEmpresa.TabIndex = 6;
            aoClicarRemoverEmpresa.Text = "Remover";
            aoClicarRemoverEmpresa.UseVisualStyleBackColor = true;
            aoClicarRemoverEmpresa.Click += AoClicarRemoverEmpresa;
            // 
            // aoClicarAdicionarEmpresa
            // 
            aoClicarAdicionarEmpresa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarAdicionarEmpresa.Location = new Point(432, 318);
            aoClicarAdicionarEmpresa.Name = "aoClicarAdicionarEmpresa";
            aoClicarAdicionarEmpresa.Size = new Size(75, 23);
            aoClicarAdicionarEmpresa.TabIndex = 5;
            aoClicarAdicionarEmpresa.Text = "Adicionar";
            aoClicarAdicionarEmpresa.UseVisualStyleBackColor = true;
            aoClicarAdicionarEmpresa.Click += AoClicarAdicionarEmpresa;
            // 
            // tabPageProduto
            // 
            tabPageProduto.Controls.Add(aoClicarDeveAtualizarProduto);
            tabPageProduto.Controls.Add(aoClicarDeveRemoverProduto);
            tabPageProduto.Controls.Add(aoClicarAdicionarProduto);
            tabPageProduto.Controls.Add(resetarFiltroData);
            tabPageProduto.Controls.Add(label4);
            tabPageProduto.Controls.Add(label3);
            tabPageProduto.Controls.Add(filtrarPorDataMaximaProduto);
            tabPageProduto.Controls.Add(label2);
            tabPageProduto.Controls.Add(label1);
            tabPageProduto.Controls.Add(filtrarValorMaximoProduto);
            tabPageProduto.Controls.Add(filtrarValorMinimoProduto);
            tabPageProduto.Controls.Add(filtrarPorDataMinimaProduto);
            tabPageProduto.Controls.Add(textFiltrarNomeProduto);
            tabPageProduto.Controls.Add(gridListaProduto);
            tabPageProduto.Location = new Point(4, 24);
            tabPageProduto.Name = "tabPageProduto";
            tabPageProduto.Padding = new Padding(3);
            tabPageProduto.Size = new Size(693, 353);
            tabPageProduto.TabIndex = 1;
            tabPageProduto.Text = "Produto";
            tabPageProduto.UseVisualStyleBackColor = true;
            // 
            // aoClicarDeveAtualizarProduto
            // 
            aoClicarDeveAtualizarProduto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarDeveAtualizarProduto.Location = new Point(513, 318);
            aoClicarDeveAtualizarProduto.Name = "aoClicarDeveAtualizarProduto";
            aoClicarDeveAtualizarProduto.Size = new Size(75, 23);
            aoClicarDeveAtualizarProduto.TabIndex = 13;
            aoClicarDeveAtualizarProduto.Text = "Editar";
            aoClicarDeveAtualizarProduto.UseVisualStyleBackColor = true;
            aoClicarDeveAtualizarProduto.Click += AoClicarDeveAtualizarProduto;
            // 
            // aoClicarDeveRemoverProduto
            // 
            aoClicarDeveRemoverProduto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarDeveRemoverProduto.Location = new Point(594, 318);
            aoClicarDeveRemoverProduto.Name = "aoClicarDeveRemoverProduto";
            aoClicarDeveRemoverProduto.Size = new Size(75, 23);
            aoClicarDeveRemoverProduto.TabIndex = 12;
            aoClicarDeveRemoverProduto.Text = "Remover";
            aoClicarDeveRemoverProduto.UseVisualStyleBackColor = true;
            aoClicarDeveRemoverProduto.Click += AoClicarDeveRemoverProduto;
            // 
            // aoClicarAdicionarProduto
            // 
            aoClicarAdicionarProduto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarAdicionarProduto.Location = new Point(432, 318);
            aoClicarAdicionarProduto.Name = "aoClicarAdicionarProduto";
            aoClicarAdicionarProduto.Size = new Size(75, 23);
            aoClicarAdicionarProduto.TabIndex = 11;
            aoClicarAdicionarProduto.Text = "Adicionar";
            aoClicarAdicionarProduto.UseVisualStyleBackColor = true;
            aoClicarAdicionarProduto.Click += AoClicarAdicionarProduto;
            // 
            // resetarFiltroData
            // 
            resetarFiltroData.BackColor = Color.White;
            resetarFiltroData.Location = new Point(510, 80);
            resetarFiltroData.Name = "resetarFiltroData";
            resetarFiltroData.Size = new Size(130, 23);
            resetarFiltroData.TabIndex = 10;
            resetarFiltroData.Text = "Resetar Filtro Data";
            resetarFiltroData.UseVisualStyleBackColor = false;
            resetarFiltroData.Click += ResetarFiltroData;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(397, 62);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "Data Final:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(284, 62);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 8;
            label3.Text = "Data Inicial:";
            // 
            // filtrarPorDataMaximaProduto
            // 
            filtrarPorDataMaximaProduto.Format = DateTimePickerFormat.Short;
            filtrarPorDataMaximaProduto.Location = new Point(397, 80);
            filtrarPorDataMaximaProduto.Name = "filtrarPorDataMaximaProduto";
            filtrarPorDataMaximaProduto.Size = new Size(107, 23);
            filtrarPorDataMaximaProduto.TabIndex = 7;
            filtrarPorDataMaximaProduto.ValueChanged += FiltrarPorDataMaximaProduto;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(134, 62);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 6;
            label2.Text = "Valor Max:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 62);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 5;
            label1.Text = "Valor Min:";
            // 
            // filtrarValorMaximoProduto
            // 
            filtrarValorMaximoProduto.DecimalPlaces = 2;
            filtrarValorMaximoProduto.Location = new Point(134, 80);
            filtrarValorMaximoProduto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            filtrarValorMaximoProduto.Name = "filtrarValorMaximoProduto";
            filtrarValorMaximoProduto.Size = new Size(120, 23);
            filtrarValorMaximoProduto.TabIndex = 4;
            filtrarValorMaximoProduto.ValueChanged += FiltrarValorMaximoProduto;
            // 
            // filtrarValorMinimoProduto
            // 
            filtrarValorMinimoProduto.DecimalPlaces = 2;
            filtrarValorMinimoProduto.Location = new Point(8, 80);
            filtrarValorMinimoProduto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            filtrarValorMinimoProduto.Name = "filtrarValorMinimoProduto";
            filtrarValorMinimoProduto.Size = new Size(120, 23);
            filtrarValorMinimoProduto.TabIndex = 3;
            filtrarValorMinimoProduto.ValueChanged += FiltrarValorMinimoProduto;
            // 
            // filtrarPorDataMinimaProduto
            // 
            filtrarPorDataMinimaProduto.Format = DateTimePickerFormat.Short;
            filtrarPorDataMinimaProduto.Location = new Point(284, 80);
            filtrarPorDataMinimaProduto.Name = "filtrarPorDataMinimaProduto";
            filtrarPorDataMinimaProduto.Size = new Size(107, 23);
            filtrarPorDataMinimaProduto.TabIndex = 2;
            filtrarPorDataMinimaProduto.ValueChanged += FiltrarPorDataMinimaProduto;
            // 
            // textFiltrarNomeProduto
            // 
            textFiltrarNomeProduto.Location = new Point(8, 22);
            textFiltrarNomeProduto.Name = "textFiltrarNomeProduto";
            textFiltrarNomeProduto.PlaceholderText = "Pesquisar Nome";
            textFiltrarNomeProduto.Size = new Size(333, 23);
            textFiltrarNomeProduto.TabIndex = 1;
            textFiltrarNomeProduto.TextChanged += FiltrarNomeProduto;
            // 
            // gridListaProduto
            // 
            gridListaProduto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridListaProduto.AutoGenerateColumns = false;
            gridListaProduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridListaProduto.BackgroundColor = Color.White;
            gridListaProduto.BorderStyle = BorderStyle.None;
            gridListaProduto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridListaProduto.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn, valorDoProdutoDataGridViewTextBoxColumn, dataCadastroDataGridViewTextBoxColumn, TemDataValidade, dataValidadeDataGridViewTextBoxColumn, empresaIdDataGridViewTextBoxColumn });
            gridListaProduto.DataSource = produtoBindingSource;
            gridListaProduto.Location = new Point(3, 111);
            gridListaProduto.Name = "gridListaProduto";
            gridListaProduto.RowHeadersVisible = false;
            gridListaProduto.RowTemplate.Height = 25;
            gridListaProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridListaProduto.Size = new Size(687, 201);
            gridListaProduto.TabIndex = 0;
            gridListaProduto.CellFormatting += DataGridViewProduto_CellFormatting;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.Width = 42;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // valorDoProdutoDataGridViewTextBoxColumn
            // 
            valorDoProdutoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            valorDoProdutoDataGridViewTextBoxColumn.DataPropertyName = "ValorDoProduto";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "R$";
            valorDoProdutoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            valorDoProdutoDataGridViewTextBoxColumn.HeaderText = "Valor Produto";
            valorDoProdutoDataGridViewTextBoxColumn.Name = "valorDoProdutoDataGridViewTextBoxColumn";
            valorDoProdutoDataGridViewTextBoxColumn.Width = 96;
            // 
            // dataCadastroDataGridViewTextBoxColumn
            // 
            dataCadastroDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataCadastro";
            dataCadastroDataGridViewTextBoxColumn.HeaderText = "Data Cadastro";
            dataCadastroDataGridViewTextBoxColumn.Name = "dataCadastroDataGridViewTextBoxColumn";
            dataCadastroDataGridViewTextBoxColumn.Width = 97;
            // 
            // TemDataValidade
            // 
            TemDataValidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            TemDataValidade.DataPropertyName = "TemDataValidade";
            TemDataValidade.HeaderText = "Tem Data Validade";
            TemDataValidade.Name = "TemDataValidade";
            TemDataValidade.Width = 98;
            // 
            // dataValidadeDataGridViewTextBoxColumn
            // 
            dataValidadeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataValidadeDataGridViewTextBoxColumn.DataPropertyName = "DataValidade";
            dataValidadeDataGridViewTextBoxColumn.HeaderText = "Data Validade";
            dataValidadeDataGridViewTextBoxColumn.Name = "dataValidadeDataGridViewTextBoxColumn";
            dataValidadeDataGridViewTextBoxColumn.Width = 95;
            // 
            // empresaIdDataGridViewTextBoxColumn
            // 
            empresaIdDataGridViewTextBoxColumn.DataPropertyName = "EmpresaId";
            empresaIdDataGridViewTextBoxColumn.HeaderText = "Empresa";
            empresaIdDataGridViewTextBoxColumn.Name = "empresaIdDataGridViewTextBoxColumn";
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Dominio.Entidades.Produto);
            // 
            // FormListaEmpresaEProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(705, 394);
            Controls.Add(tabControl1);
            Name = "FormListaEmpresaEProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormListaEmpresa";
            ((System.ComponentModel.ISupportInitialize)gridListaEmpresas).EndInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            tabPagEmpresa.ResumeLayout(false);
            tabPagEmpresa.PerformLayout();
            tabPageProduto.ResumeLayout(false);
            tabPageProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMaximoProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMinimoProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridListaProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridListaEmpresas;
        private BindingSource empresaBindingSource;
        private TextBox textFiltrarRazaoSocial;
        private ComboBox comboBoxEnumRamo;
        private TabControl tabControl1;
        private TabPage tabPagEmpresa;
        private TabPage tabPageProduto;
        private DataGridView gridListaProduto;
        private DataGridViewCheckBoxColumn temDataValidaDataGridViewCheckBoxColumn;
        private BindingSource produtoBindingSource;
        private TextBox textFiltrarNomeProduto;
        private DateTimePicker filtrarPorDataMinimaProduto;
        private NumericUpDown filtrarValorMinimoProduto;
        private NumericUpDown filtrarValorMaximoProduto;
        private Label label2;
        private Label label1;
        private DateTimePicker filtrarPorDataMaximaProduto;
        private Label label4;
        private Label label3;
        private Button resetarFiltroData;
        private Button aoClicarAdicionarEmpresa;
        private Button aoClicarAdicionarProduto;
        private Button aoClicarRemoverEmpresa;
        private Button aoClicarDeveRemoverProduto;
        private Button aoClicarDeveAtualizarEmpresa;
        private Button aoClicarDeveAtualizarProduto;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razaoSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cNPJDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ramoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoProdutoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataCadastroDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn TemDataValidade;
        private DataGridViewTextBoxColumn dataValidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn empresaIdDataGridViewTextBoxColumn;
    }
}

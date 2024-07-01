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
            dataGridViewEmpresa = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            razaoSocialDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cNPJDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ramoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaBindingSource = new BindingSource(components);
            textFiltrarRazaoSocial = new TextBox();
            comboBoxEnumRamo = new ComboBox();
            tabControl1 = new TabControl();
            tabPagEmpresa = new TabPage();
            aoClicarAdicionarEmpresa = new Button();
            tabPageProduto = new TabPage();
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
            dataGridViewProduto = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoProdutoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataCadastroDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            TemDataValidade = new DataGridViewCheckBoxColumn();
            dataValidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            empresaIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            produtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).BeginInit();
            tabControl1.SuspendLayout();
            tabPagEmpresa.SuspendLayout();
            tabPageProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMaximoProduto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMinimoProduto).BeginInit();
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
            dataGridViewEmpresa.Location = new Point(3, 64);
            dataGridViewEmpresa.Name = "dataGridViewEmpresa";
            dataGridViewEmpresa.RowHeadersVisible = false;
            dataGridViewEmpresa.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewEmpresa.Size = new Size(952, 248);
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
            razaoSocialDataGridViewTextBoxColumn.HeaderText = "Razao Social";
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
            // textFiltrarRazaoSocial
            // 
            textFiltrarRazaoSocial.Location = new Point(8, 22);
            textFiltrarRazaoSocial.Name = "textFiltrarRazaoSocial";
            textFiltrarRazaoSocial.PlaceholderText = "Pesquisar Razão Social";
            textFiltrarRazaoSocial.Size = new Size(333, 23);
            textFiltrarRazaoSocial.TabIndex = 2;
            textFiltrarRazaoSocial.TextChanged += textFiltrarRazaoSocial_TextChanged;
            // 
            // comboBoxEnumRamo
            // 
            comboBoxEnumRamo.FormattingEnabled = true;
            comboBoxEnumRamo.Items.AddRange(new object[] { "Todos", "Industria", "Comercio", "Servico" });
            comboBoxEnumRamo.Location = new Point(374, 22);
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
            tabControl1.Size = new Size(966, 381);
            tabControl1.TabIndex = 5;
            // 
            // tabPagEmpresa
            // 
            tabPagEmpresa.Controls.Add(aoClicarAdicionarEmpresa);
            tabPagEmpresa.Controls.Add(dataGridViewEmpresa);
            tabPagEmpresa.Controls.Add(comboBoxEnumRamo);
            tabPagEmpresa.Controls.Add(textFiltrarRazaoSocial);
            tabPagEmpresa.Location = new Point(4, 24);
            tabPagEmpresa.Name = "tabPagEmpresa";
            tabPagEmpresa.Padding = new Padding(3);
            tabPagEmpresa.Size = new Size(958, 353);
            tabPagEmpresa.TabIndex = 0;
            tabPagEmpresa.Text = "Empresa";
            tabPagEmpresa.UseVisualStyleBackColor = true;
            // 
            // aoClicarAdicionarEmpresa
            // 
            aoClicarAdicionarEmpresa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarAdicionarEmpresa.Location = new Point(697, 318);
            aoClicarAdicionarEmpresa.Name = "aoClicarAdicionarEmpresa";
            aoClicarAdicionarEmpresa.Size = new Size(75, 23);
            aoClicarAdicionarEmpresa.TabIndex = 5;
            aoClicarAdicionarEmpresa.Text = "Adicionar";
            aoClicarAdicionarEmpresa.UseVisualStyleBackColor = true;
            aoClicarAdicionarEmpresa.Click += aoClicarAdicionarEmpresa_Click;
            // 
            // tabPageProduto
            // 
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
            tabPageProduto.Controls.Add(dataGridViewProduto);
            tabPageProduto.Location = new Point(4, 24);
            tabPageProduto.Name = "tabPageProduto";
            tabPageProduto.Padding = new Padding(3);
            tabPageProduto.Size = new Size(958, 353);
            tabPageProduto.TabIndex = 1;
            tabPageProduto.Text = "Produto";
            tabPageProduto.UseVisualStyleBackColor = true;
            // 
            // aoClicarAdicionarProduto
            // 
            aoClicarAdicionarProduto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            aoClicarAdicionarProduto.Location = new Point(697, 318);
            aoClicarAdicionarProduto.Name = "aoClicarAdicionarProduto";
            aoClicarAdicionarProduto.Size = new Size(75, 23);
            aoClicarAdicionarProduto.TabIndex = 11;
            aoClicarAdicionarProduto.Text = "Adicionar";
            aoClicarAdicionarProduto.UseVisualStyleBackColor = true;
            aoClicarAdicionarProduto.Click += aoClicarAdicionarProduto_Click;
            // 
            // resetarFiltroData
            // 
            resetarFiltroData.BackColor = Color.White;
            resetarFiltroData.Location = new Point(592, 105);
            resetarFiltroData.Name = "resetarFiltroData";
            resetarFiltroData.Size = new Size(130, 23);
            resetarFiltroData.TabIndex = 10;
            resetarFiltroData.Text = "Resetar Filtro Data";
            resetarFiltroData.UseVisualStyleBackColor = false;
            resetarFiltroData.Click += resetarFiltroData_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(628, 58);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "Data Final:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(622, 6);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 8;
            label3.Text = "Data Inicial:";
            // 
            // filtrarPorDataMaximaProduto
            // 
            filtrarPorDataMaximaProduto.Location = new Point(545, 76);
            filtrarPorDataMaximaProduto.Name = "filtrarPorDataMaximaProduto";
            filtrarPorDataMaximaProduto.Size = new Size(228, 23);
            filtrarPorDataMaximaProduto.TabIndex = 7;
            filtrarPorDataMaximaProduto.ValueChanged += filtrarPorDataMaximaProduto_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(398, 58);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 6;
            label2.Text = "Valor Max:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(400, 6);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 5;
            label1.Text = "Valor Min:";
            // 
            // filtrarValorMaximoProduto
            // 
            filtrarValorMaximoProduto.DecimalPlaces = 2;
            filtrarValorMaximoProduto.Location = new Point(372, 76);
            filtrarValorMaximoProduto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            filtrarValorMaximoProduto.Name = "filtrarValorMaximoProduto";
            filtrarValorMaximoProduto.Size = new Size(120, 23);
            filtrarValorMaximoProduto.TabIndex = 4;
            filtrarValorMaximoProduto.ValueChanged += filtrarValorMaximoProduto_ValueChanged;
            // 
            // filtrarValorMinimoProduto
            // 
            filtrarValorMinimoProduto.DecimalPlaces = 2;
            filtrarValorMinimoProduto.Location = new Point(372, 22);
            filtrarValorMinimoProduto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            filtrarValorMinimoProduto.Name = "filtrarValorMinimoProduto";
            filtrarValorMinimoProduto.Size = new Size(120, 23);
            filtrarValorMinimoProduto.TabIndex = 3;
            filtrarValorMinimoProduto.ValueChanged += filtrarValorMinimoProduto_ValueChanged;
            // 
            // filtrarPorDataMinimaProduto
            // 
            filtrarPorDataMinimaProduto.Location = new Point(545, 22);
            filtrarPorDataMinimaProduto.Name = "filtrarPorDataMinimaProduto";
            filtrarPorDataMinimaProduto.Size = new Size(228, 23);
            filtrarPorDataMinimaProduto.TabIndex = 2;
            filtrarPorDataMinimaProduto.ValueChanged += filtrarPorDataMinimaProduto_ValueChanged;
            // 
            // textFiltrarNomeProduto
            // 
            textFiltrarNomeProduto.Location = new Point(8, 22);
            textFiltrarNomeProduto.Name = "textFiltrarNomeProduto";
            textFiltrarNomeProduto.PlaceholderText = "Pesquisar Nome";
            textFiltrarNomeProduto.Size = new Size(333, 23);
            textFiltrarNomeProduto.TabIndex = 1;
            textFiltrarNomeProduto.TextChanged += textFiltrarNomeProduto_TextChanged;
            // 
            // dataGridViewProduto
            // 
            dataGridViewProduto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProduto.AutoGenerateColumns = false;
            dataGridViewProduto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProduto.BackgroundColor = Color.White;
            dataGridViewProduto.BorderStyle = BorderStyle.None;
            dataGridViewProduto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProduto.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn, valorDoProdutoDataGridViewTextBoxColumn, dataCadastroDataGridViewTextBoxColumn, TemDataValidade, dataValidadeDataGridViewTextBoxColumn, empresaIdDataGridViewTextBoxColumn });
            dataGridViewProduto.DataSource = produtoBindingSource;
            dataGridViewProduto.Location = new Point(3, 148);
            dataGridViewProduto.Name = "dataGridViewProduto";
            dataGridViewProduto.RowHeadersVisible = false;
            dataGridViewProduto.RowTemplate.Height = 25;
            dataGridViewProduto.Size = new Size(952, 150);
            dataGridViewProduto.TabIndex = 0;
            dataGridViewProduto.CellFormatting += dataGridViewProduto_CellFormatting;
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
            valorDoProdutoDataGridViewTextBoxColumn.HeaderText = "Valor Produto";
            valorDoProdutoDataGridViewTextBoxColumn.Name = "valorDoProdutoDataGridViewTextBoxColumn";
            // 
            // dataCadastroDataGridViewTextBoxColumn
            // 
            dataCadastroDataGridViewTextBoxColumn.DataPropertyName = "DataCadastro";
            dataCadastroDataGridViewTextBoxColumn.HeaderText = "Data Cadastro";
            dataCadastroDataGridViewTextBoxColumn.Name = "dataCadastroDataGridViewTextBoxColumn";
            // 
            // TemDataValidade
            // 
            TemDataValidade.DataPropertyName = "TemDataValidade";
            TemDataValidade.HeaderText = "Tem Data Validade";
            TemDataValidade.Name = "TemDataValidade";
            // 
            // dataValidadeDataGridViewTextBoxColumn
            // 
            dataValidadeDataGridViewTextBoxColumn.DataPropertyName = "DataValidade";
            dataValidadeDataGridViewTextBoxColumn.HeaderText = "Data Validade";
            dataValidadeDataGridViewTextBoxColumn.Name = "dataValidadeDataGridViewTextBoxColumn";
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
            ClientSize = new Size(970, 394);
            Controls.Add(tabControl1);
            Name = "FormListaEmpresaEProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormListaEmpresa";
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmpresa).EndInit();
            ((System.ComponentModel.ISupportInitialize)empresaBindingSource).EndInit();
            tabControl1.ResumeLayout(false);
            tabPagEmpresa.ResumeLayout(false);
            tabPagEmpresa.PerformLayout();
            tabPageProduto.ResumeLayout(false);
            tabPageProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMaximoProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)filtrarValorMinimoProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProduto).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewEmpresa;
        private BindingSource empresaBindingSource;
        private TextBox textFiltrarRazaoSocial;
        private ComboBox comboBoxEnumRamo;
        private TabControl tabControl1;
        private TabPage tabPagEmpresa;
        private TabPage tabPageProduto;
        private DataGridView dataGridViewProduto;
        private DataGridViewCheckBoxColumn temDataValidaDataGridViewCheckBoxColumn;
        private BindingSource produtoBindingSource;
        private TextBox textFiltrarNomeProduto;
        private DateTimePicker filtrarPorDataMinimaProduto;
        private NumericUpDown filtrarValorMinimoProduto;
        private NumericUpDown filtrarValorMaximoProduto;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn razaoSocialDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cNPJDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ramoDataGridViewTextBoxColumn;
        private Label label2;
        private Label label1;
        private DateTimePicker filtrarPorDataMaximaProduto;
        private Label label4;
        private Label label3;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoProdutoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataCadastroDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn TemDataValidade;
        private DataGridViewTextBoxColumn dataValidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn empresaIdDataGridViewTextBoxColumn;
        private Button resetarFiltroData;
        private Button aoClicarAdicionarEmpresa;
        private Button aoClicarAdicionarProduto;
    }
}

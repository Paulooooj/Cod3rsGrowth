namespace Cod3rsGrowth.Forms
{
    partial class CadastroProduto
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
            groupBox1 = new GroupBox();
            mostrarTodasAsEmpresas = new ComboBox();
            valorProduto = new NumericUpDown();
            aoClicarDeveCancelarAdicionarProduto = new Button();
            aoClicarDeveSalvar = new Button();
            label6 = new Label();
            labelTemDataValidade = new Label();
            dataDeValidade = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            temDataDeValidade = new CheckBox();
            dataCadastroProduto = new DateTimePicker();
            label1 = new Label();
            nomeProduto = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)valorProduto).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(mostrarTodasAsEmpresas);
            groupBox1.Controls.Add(valorProduto);
            groupBox1.Controls.Add(aoClicarDeveCancelarAdicionarProduto);
            groupBox1.Controls.Add(aoClicarDeveSalvar);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(labelTemDataValidade);
            groupBox1.Controls.Add(dataDeValidade);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(temDataDeValidade);
            groupBox1.Controls.Add(dataCadastroProduto);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(nomeProduto);
            groupBox1.Location = new Point(1, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(348, 377);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastro Produto";
            // 
            // mostrarTodasAsEmpresas
            // 
            mostrarTodasAsEmpresas.FormattingEnabled = true;
            mostrarTodasAsEmpresas.Location = new Point(6, 293);
            mostrarTodasAsEmpresas.Name = "mostrarTodasAsEmpresas";
            mostrarTodasAsEmpresas.Size = new Size(332, 23);
            mostrarTodasAsEmpresas.TabIndex = 16;
            // 
            // valorProduto
            // 
            valorProduto.DecimalPlaces = 2;
            valorProduto.Location = new Point(6, 94);
            valorProduto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            valorProduto.Name = "valorProduto";
            valorProduto.Size = new Size(332, 23);
            valorProduto.TabIndex = 15;
            // 
            // aoClicarDeveCancelarAdicionarProduto
            // 
            aoClicarDeveCancelarAdicionarProduto.Location = new Point(263, 351);
            aoClicarDeveCancelarAdicionarProduto.Name = "aoClicarDeveCancelarAdicionarProduto";
            aoClicarDeveCancelarAdicionarProduto.Size = new Size(75, 23);
            aoClicarDeveCancelarAdicionarProduto.TabIndex = 14;
            aoClicarDeveCancelarAdicionarProduto.Text = "Cancelar";
            aoClicarDeveCancelarAdicionarProduto.UseVisualStyleBackColor = true;
            aoClicarDeveCancelarAdicionarProduto.Click += aoClicarDeveCancelarAdicionarProduto_Click;
            // 
            // aoClicarDeveSalvar
            // 
            aoClicarDeveSalvar.Location = new Point(6, 351);
            aoClicarDeveSalvar.Name = "aoClicarDeveSalvar";
            aoClicarDeveSalvar.Size = new Size(124, 23);
            aoClicarDeveSalvar.TabIndex = 13;
            aoClicarDeveSalvar.Text = "Salvar";
            aoClicarDeveSalvar.UseVisualStyleBackColor = true;
            aoClicarDeveSalvar.Click += aoClicarDeveSalvar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 273);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 12;
            label6.Text = "Empresa";
            // 
            // labelTemDataValidade
            // 
            labelTemDataValidade.AutoSize = true;
            labelTemDataValidade.Location = new Point(8, 223);
            labelTemDataValidade.Name = "labelTemDataValidade";
            labelTemDataValidade.Size = new Size(94, 15);
            labelTemDataValidade.TabIndex = 10;
            labelTemDataValidade.Text = "Data de Validade";
            labelTemDataValidade.Visible = false;
            // 
            // dataDeValidade
            // 
            dataDeValidade.Format = DateTimePickerFormat.Short;
            dataDeValidade.Location = new Point(6, 241);
            dataDeValidade.Name = "dataDeValidade";
            dataDeValidade.Size = new Size(332, 23);
            dataDeValidade.TabIndex = 9;
            dataDeValidade.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 76);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 8;
            label4.Text = "Valor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 180);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 6;
            label3.Text = "Tem Data de Validade";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 128);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 5;
            label2.Text = "Data de Cadastro";
            // 
            // temDataDeValidade
            // 
            temDataDeValidade.AutoSize = true;
            temDataDeValidade.Location = new Point(11, 198);
            temDataDeValidade.Name = "temDataDeValidade";
            temDataDeValidade.Size = new Size(46, 19);
            temDataDeValidade.TabIndex = 3;
            temDataDeValidade.Text = "Sim";
            temDataDeValidade.UseVisualStyleBackColor = true;
            temDataDeValidade.CheckedChanged += temDataDeValidadeVerdadeiro_CheckedChanged;
            // 
            // dataCadastroProduto
            // 
            dataCadastroProduto.Format = DateTimePickerFormat.Short;
            dataCadastroProduto.Location = new Point(6, 146);
            dataCadastroProduto.Name = "dataCadastroProduto";
            dataCadastroProduto.Size = new Size(332, 23);
            dataCadastroProduto.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 22);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // nomeProduto
            // 
            nomeProduto.Location = new Point(6, 40);
            nomeProduto.Name = "nomeProduto";
            nomeProduto.PlaceholderText = "Nome Produto";
            nomeProduto.Size = new Size(332, 23);
            nomeProduto.TabIndex = 0;
            // 
            // CadastroProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(351, 394);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "CadastroProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produto";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)valorProduto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox nomeProduto;
        private DateTimePicker dataCadastroProduto;
        private Label label3;
        private Label label2;
        private CheckBox temDataDeValidade;
        private Label label4;
        private Label labelTemDataValidade;
        private DateTimePicker dataDeValidade;
        private Label label6;
        private Button aoClicarDeveCancelarAdicionarProduto;
        private Button aoClicarDeveSalvar;
        private NumericUpDown valorProduto;
        private ComboBox mostrarTodasAsEmpresas;
    }
}
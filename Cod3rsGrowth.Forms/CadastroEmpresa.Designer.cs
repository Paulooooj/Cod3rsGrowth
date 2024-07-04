namespace Cod3rsGrowth.Forms
{
    partial class CadastroEmpresa
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
            aoClicarDeveCancelarAdicionar = new Button();
            aoClicarDeveSalvar = new Button();
            label3 = new Label();
            cnpjEmpresa = new MaskedTextBox();
            ramoDaEmpresa = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            razaoSocialCadastroEmpresa = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(aoClicarDeveCancelarAdicionar);
            groupBox1.Controls.Add(aoClicarDeveSalvar);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cnpjEmpresa);
            groupBox1.Controls.Add(ramoDaEmpresa);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(razaoSocialCadastroEmpresa);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(349, 267);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cadastro Empresa";
            // 
            // aoClicarDeveCancelarAdicionar
            // 
            aoClicarDeveCancelarAdicionar.BackColor = Color.White;
            aoClicarDeveCancelarAdicionar.Location = new Point(264, 223);
            aoClicarDeveCancelarAdicionar.Name = "aoClicarDeveCancelarAdicionar";
            aoClicarDeveCancelarAdicionar.Size = new Size(75, 23);
            aoClicarDeveCancelarAdicionar.TabIndex = 6;
            aoClicarDeveCancelarAdicionar.Text = "Cancelar";
            aoClicarDeveCancelarAdicionar.UseVisualStyleBackColor = false;
            aoClicarDeveCancelarAdicionar.Click += AoClicarDeveCancelarAdicionar;
            // 
            // aoClicarDeveSalvar
            // 
            aoClicarDeveSalvar.BackColor = Color.White;
            aoClicarDeveSalvar.Location = new Point(7, 223);
            aoClicarDeveSalvar.Name = "aoClicarDeveSalvar";
            aoClicarDeveSalvar.Size = new Size(115, 23);
            aoClicarDeveSalvar.TabIndex = 5;
            aoClicarDeveSalvar.Text = "Salvar";
            aoClicarDeveSalvar.UseVisualStyleBackColor = false;
            aoClicarDeveSalvar.Click += AoClicarDeveSalvar;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 143);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Ramo";
            // 
            // cnpjEmpresa
            // 
            cnpjEmpresa.Location = new Point(7, 105);
            cnpjEmpresa.Mask = "99,999,999/9999-99";
            cnpjEmpresa.Name = "cnpjEmpresa";
            cnpjEmpresa.Size = new Size(332, 23);
            cnpjEmpresa.TabIndex = 2;
            // 
            // ramoDaEmpresa
            // 
            ramoDaEmpresa.FormattingEnabled = true;
            ramoDaEmpresa.Items.AddRange(new object[] { "Ramo", "Industria", "Comercio", "Servico" });
            ramoDaEmpresa.Location = new Point(6, 161);
            ramoDaEmpresa.Name = "ramoDaEmpresa";
            ramoDaEmpresa.Size = new Size(332, 23);
            ramoDaEmpresa.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 87);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 3;
            label2.Text = "CNPJ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 33);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 1;
            label1.Text = "Razão Social";
            // 
            // razaoSocialCadastroEmpresa
            // 
            razaoSocialCadastroEmpresa.Location = new Point(6, 51);
            razaoSocialCadastroEmpresa.Name = "razaoSocialCadastroEmpresa";
            razaoSocialCadastroEmpresa.PlaceholderText = "Razão Social da Empresa";
            razaoSocialCadastroEmpresa.Size = new Size(332, 23);
            razaoSocialCadastroEmpresa.TabIndex = 0;
            // 
            // CadastroEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(363, 280);
            Controls.Add(groupBox1);
            MaximizeBox = false;
            Name = "CadastroEmpresa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Empresa";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox razaoSocialCadastroEmpresa;
        private MaskedTextBox cnpjEmpresa;
        private ComboBox ramoDaEmpresa;
        private Label label2;
        private Label label3;
        private Button aoClicarDeveCancelarAdicionar;
        private Button aoClicarDeveSalvar;
    }
}
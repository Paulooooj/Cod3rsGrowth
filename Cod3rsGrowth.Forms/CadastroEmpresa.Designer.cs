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
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            maskedTextBox1 = new MaskedTextBox();
            comboBox1 = new ComboBox();
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
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(maskedTextBox1);
            groupBox1.Controls.Add(comboBox1);
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
            // button2
            // 
            button2.BackColor = Color.White;
            button2.Location = new Point(264, 223);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Location = new Point(7, 223);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 5;
            button1.Text = "Adicionar Empresa";
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 143);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 4;
            label3.Text = "Ramo";
            label3.Click += label3_Click;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.Location = new Point(7, 105);
            maskedTextBox1.Mask = "99.999.999/9999-99";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(332, 23);
            maskedTextBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Ramo", "Industria", "Comercio", "Servico" });
            comboBox1.Location = new Point(6, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(332, 23);
            comboBox1.TabIndex = 1;
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
        private MaskedTextBox maskedTextBox1;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Button button2;
        private Button button1;
    }
}
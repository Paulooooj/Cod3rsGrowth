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
            numericUpDown1 = new NumericUpDown();
            button2 = new Button();
            button1 = new Button();
            label6 = new Label();
            label5 = new Label();
            dataDeValidade = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            temDataDeValidadeVerdadeiro = new CheckBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            textBox1 = new TextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(mostrarTodasAsEmpresas);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dataDeValidade);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(temDataDeValidadeVerdadeiro);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
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
            mostrarTodasAsEmpresas.SelectedIndexChanged += mostrarTodasAsEmpresas_SelectedIndexChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(6, 94);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(332, 23);
            numericUpDown1.TabIndex = 15;
            // 
            // button2
            // 
            button2.Location = new Point(263, 351);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 14;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(6, 351);
            button1.Name = "button1";
            button1.Size = new Size(124, 23);
            button1.TabIndex = 13;
            button1.Text = "Adicionar Produto";
            button1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 273);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 12;
            label6.Text = "Id Empresa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 223);
            label5.Name = "label5";
            label5.Size = new Size(94, 15);
            label5.TabIndex = 10;
            label5.Text = "Data de Validade";
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
            // temDataDeValidadeVerdadeiro
            // 
            temDataDeValidadeVerdadeiro.AutoSize = true;
            temDataDeValidadeVerdadeiro.Location = new Point(11, 198);
            temDataDeValidadeVerdadeiro.Name = "temDataDeValidadeVerdadeiro";
            temDataDeValidadeVerdadeiro.Size = new Size(46, 19);
            temDataDeValidadeVerdadeiro.TabIndex = 3;
            temDataDeValidadeVerdadeiro.Text = "Sim";
            temDataDeValidadeVerdadeiro.UseVisualStyleBackColor = true;
            temDataDeValidadeVerdadeiro.CheckedChanged += temDataDeValidadeVerdadeiro_CheckedChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(6, 146);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(332, 23);
            dateTimePicker1.TabIndex = 2;
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
            // textBox1
            // 
            textBox1.Location = new Point(6, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 23);
            textBox1.TabIndex = 0;
            // 
            // CadastroProduto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(351, 394);
            Controls.Add(groupBox1);
            Name = "CadastroProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Produto";
            TopMost = true;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private Label label3;
        private Label label2;
        private CheckBox temDataDeValidadeVerdadeiro;
        private Label label4;
        private Label label5;
        private DateTimePicker dataDeValidade;
        private Label label6;
        private Button button2;
        private Button button1;
        private NumericUpDown numericUpDown1;
        private ComboBox mostrarTodasAsEmpresas;
    }
}
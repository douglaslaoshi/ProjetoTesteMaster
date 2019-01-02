namespace WindowsFormsApp1
{
    partial class FormNaoAbrirCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNaoAbrirCadastro));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TabNotOpen = new System.Windows.Forms.ComboBox();
            this.ADDDEMONoOpen = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tabulação CTA por chamada encerrada.";
            // 
            // TabNotOpen
            // 
            this.TabNotOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TabNotOpen.FormattingEnabled = true;
            this.TabNotOpen.Items.AddRange(new object[] {
            "10 - Suspeita de Fraude | REPA",
            "11 - Promessa de Ac. | ACVB",
            "18 - Alega Pagamento | REPA",
            "29 - Financ. para Terceiros | REPA",
            "37 - Desempregado sem con. acord. | REPA",
            "84 - Sem condições | REPA",
            "89 - Cliente Falecido | REPA",
            "90 - Devolvido | FNNA",
            "424 - Preventivo Positivo | ACVB",
            "425 - Preventivo Negativo | REPA",
            "510 - Queda de ligação terceiro | FNNA",
            "550 - Telefone Mudo s/ Ag. | FNNA",
            "585 - Não quer passar dados por Tel. | FNNA",
            "651 - Ligação desligada pelo cliente | REPA",
            "677 - Contrato quitato | FNNA",
            "743 - Sem previsão de pagamento | REPA",
            "856 - Consta Pagamento | PAGO",
            "861 - Acordo Pago | PAGO",
            "1096 - Recado | RECD",
            "1145 - Desconhece Cliente | FNNA",
            "1811 - Já possui acordo registrado no sistema | FNNA"});
            this.TabNotOpen.Location = new System.Drawing.Point(12, 25);
            this.TabNotOpen.Name = "TabNotOpen";
            this.TabNotOpen.Size = new System.Drawing.Size(335, 21);
            this.TabNotOpen.TabIndex = 99;
            // 
            // ADDDEMONoOpen
            // 
            this.ADDDEMONoOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ADDDEMONoOpen.Location = new System.Drawing.Point(12, 52);
            this.ADDDEMONoOpen.MaxLength = 0;
            this.ADDDEMONoOpen.Multiline = true;
            this.ADDDEMONoOpen.Name = "ADDDEMONoOpen";
            this.ADDDEMONoOpen.Size = new System.Drawing.Size(335, 80);
            this.ADDDEMONoOpen.TabIndex = 98;
            // 
            // FormNaoAbrirCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(2)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(359, 173);
            this.Controls.Add(this.TabNotOpen);
            this.Controls.Add(this.ADDDEMONoOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNaoAbrirCadastro";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TabNotOpen;
        public System.Windows.Forms.TextBox ADDDEMONoOpen;
    }
}
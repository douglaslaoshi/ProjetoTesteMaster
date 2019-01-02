namespace WindowsFormsApp1
{
    partial class GCADivergente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GCADivergente));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.VlRcb = new System.Windows.Forms.Label();
            this.UserBackoffice = new System.Windows.Forms.TextBox();
            this.PassBackoffice = new System.Windows.Forms.TextBox();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.VlCta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(11, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dispensa de Juros maior que 100% !";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(65, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valor de GCA divergente.";
            // 
            // VlRcb
            // 
            this.VlRcb.AutoSize = true;
            this.VlRcb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VlRcb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.VlRcb.Location = new System.Drawing.Point(92, 72);
            this.VlRcb.Name = "VlRcb";
            this.VlRcb.Size = new System.Drawing.Size(15, 16);
            this.VlRcb.TabIndex = 2;
            this.VlRcb.Text = "0";
            this.VlRcb.Click += new System.EventHandler(this.label3_Click);
            // 
            // UserBackoffice
            // 
            this.UserBackoffice.Location = new System.Drawing.Point(95, 94);
            this.UserBackoffice.Name = "UserBackoffice";
            this.UserBackoffice.Size = new System.Drawing.Size(148, 20);
            this.UserBackoffice.TabIndex = 3;
            this.UserBackoffice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // PassBackoffice
            // 
            this.PassBackoffice.Location = new System.Drawing.Point(95, 126);
            this.PassBackoffice.Name = "PassBackoffice";
            this.PassBackoffice.Size = new System.Drawing.Size(148, 20);
            this.PassBackoffice.TabIndex = 4;
            this.PassBackoffice.UseSystemPasswordChar = true;
            // 
            // btnAprovar
            // 
            this.btnAprovar.BackColor = System.Drawing.Color.White;
            this.btnAprovar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprovar.Location = new System.Drawing.Point(97, 157);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(81, 30);
            this.btnAprovar.TabIndex = 5;
            this.btnAprovar.Text = "Recalcular";
            this.btnAprovar.UseVisualStyleBackColor = false;
            this.btnAprovar.Click += new System.EventHandler(this.btnAprovar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(38, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "RCB: R$";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(156, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "CTA: R$";
            // 
            // VlCta
            // 
            this.VlCta.AutoSize = true;
            this.VlCta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VlCta.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.VlCta.Location = new System.Drawing.Point(209, 72);
            this.VlCta.Name = "VlCta";
            this.VlCta.Size = new System.Drawing.Size(15, 16);
            this.VlCta.TabIndex = 15;
            this.VlCta.Text = "0";
            this.VlCta.Click += new System.EventHandler(this.VlCta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(30, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Usuário:";
            this.label3.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(38, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Senha:";
            // 
            // GCADivergente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(2)))), ((int)(((byte)(94)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(281, 198);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.VlCta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.PassBackoffice);
            this.Controls.Add(this.UserBackoffice);
            this.Controls.Add(this.VlRcb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(692, 310);
            this.Name = "GCADivergente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.GCADivergente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label VlRcb;
        private System.Windows.Forms.TextBox UserBackoffice;
        private System.Windows.Forms.TextBox PassBackoffice;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label VlCta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
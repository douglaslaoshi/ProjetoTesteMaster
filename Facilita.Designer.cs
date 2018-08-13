namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.txtCNPJRCB = new System.Windows.Forms.TextBox();
            this.txtUserRCB = new System.Windows.Forms.TextBox();
            this.txtPassRCB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassCICS = new System.Windows.Forms.TextBox();
            this.txtUserCICS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassSISCOB = new System.Windows.Forms.TextBox();
            this.txtUserSISCOB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(187, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Logar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCNPJRCB
            // 
            this.txtCNPJRCB.BackColor = System.Drawing.SystemColors.Window;
            this.txtCNPJRCB.Location = new System.Drawing.Point(60, 38);
            this.txtCNPJRCB.Name = "txtCNPJRCB";
            this.txtCNPJRCB.Size = new System.Drawing.Size(128, 20);
            this.txtCNPJRCB.TabIndex = 4;
            this.txtCNPJRCB.Text = "10851805000100";
            this.txtCNPJRCB.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // txtUserRCB
            // 
            this.txtUserRCB.Location = new System.Drawing.Point(60, 71);
            this.txtUserRCB.Name = "txtUserRCB";
            this.txtUserRCB.Size = new System.Drawing.Size(116, 20);
            this.txtUserRCB.TabIndex = 5;
            this.txtUserRCB.Text = "FL47250";
            this.txtUserRCB.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtPassRCB
            // 
            this.txtPassRCB.Location = new System.Drawing.Point(60, 104);
            this.txtPassRCB.Name = "txtPassRCB";
            this.txtPassRCB.Size = new System.Drawing.Size(116, 20);
            this.txtPassRCB.TabIndex = 6;
            this.txtPassRCB.Text = "Banco@04";
            this.txtPassRCB.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "CNPJ:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Usuário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Senha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "RCB - Acordos de Cobrança";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(466, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "CTA - CICS Main Frame";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Senha:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Usuário:";
            // 
            // txtPassCICS
            // 
            this.txtPassCICS.Location = new System.Drawing.Point(63, 104);
            this.txtPassCICS.Name = "txtPassCICS";
            this.txtPassCICS.Size = new System.Drawing.Size(116, 20);
            this.txtPassCICS.TabIndex = 15;
            this.txtPassCICS.Text = "2020Casa";
            this.txtPassCICS.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txtUserCICS
            // 
            this.txtUserCICS.Location = new System.Drawing.Point(63, 71);
            this.txtUserCICS.Name = "txtUserCICS";
            this.txtUserCICS.Size = new System.Drawing.Size(116, 20);
            this.txtUserCICS.TabIndex = 14;
            this.txtUserCICS.Text = "x210595";
            this.txtUserCICS.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(37, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "SISCOB - CSLog";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtPassSISCOB
            // 
            this.txtPassSISCOB.Location = new System.Drawing.Point(65, 104);
            this.txtPassSISCOB.Name = "txtPassSISCOB";
            this.txtPassSISCOB.Size = new System.Drawing.Size(116, 20);
            this.txtPassSISCOB.TabIndex = 20;
            this.txtPassSISCOB.Text = "sis1234";
            this.txtPassSISCOB.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtUserSISCOB
            // 
            this.txtUserSISCOB.Location = new System.Drawing.Point(65, 71);
            this.txtUserSISCOB.Name = "txtUserSISCOB";
            this.txtUserSISCOB.Size = new System.Drawing.Size(116, 20);
            this.txtUserSISCOB.TabIndex = 19;
            this.txtUserSISCOB.Text = "301";
            this.txtUserSISCOB.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Senha:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Usuário:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.txtPassSISCOB);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtUserSISCOB);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(239, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 152);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPassCICS);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtUserCICS);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(455, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 152);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox3.Controls.Add(this.txtCNPJRCB);
            this.groupBox3.Controls.Add(this.txtUserRCB);
            this.groupBox3.Controls.Add(this.txtPassRCB);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(9, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 152);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(403, 209);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 34);
            this.button4.TabIndex = 25;
            this.button4.Text = "Sair";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(658, 255);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Facilita";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCNPJRCB;
        private System.Windows.Forms.TextBox txtUserRCB;
        private System.Windows.Forms.TextBox txtPassRCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtPassCICS;
		private System.Windows.Forms.TextBox txtUserCICS;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPassSISCOB;
		private System.Windows.Forms.TextBox txtUserSISCOB;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}


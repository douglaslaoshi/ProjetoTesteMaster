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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassCICS = new System.Windows.Forms.TextBox();
            this.txtUserCICS = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassSISCOB = new System.Windows.Forms.TextBox();
            this.txtUserSISCOB = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(325, 247);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 39);
            this.button1.TabIndex = 2;
            this.button1.Text = "Logar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCNPJRCB
            // 
            this.txtCNPJRCB.BackColor = System.Drawing.SystemColors.Window;
            this.txtCNPJRCB.Location = new System.Drawing.Point(92, 140);
            this.txtCNPJRCB.Name = "txtCNPJRCB";
            this.txtCNPJRCB.Size = new System.Drawing.Size(179, 20);
            this.txtCNPJRCB.TabIndex = 4;
            this.txtCNPJRCB.Text = "10851805000100";
            this.txtCNPJRCB.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            this.txtCNPJRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtCNPJRCB_Validating);
            this.txtCNPJRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtCNPJRCB2_Validating);
            // 
            // txtUserRCB
            // 
            this.txtUserRCB.Location = new System.Drawing.Point(92, 174);
            this.txtUserRCB.Name = "txtUserRCB";
            this.txtUserRCB.Size = new System.Drawing.Size(179, 20);
            this.txtUserRCB.TabIndex = 5;
            this.txtUserRCB.Text = "FL47250";
            this.txtUserRCB.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtUserRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserRCB_Validating);
            this.txtUserRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserRCB2_Validating);

            // 
            // txtPassRCB
            // 
            this.txtPassRCB.Location = new System.Drawing.Point(92, 208);
            this.txtPassRCB.Name = "txtPassRCB";
            this.txtPassRCB.Size = new System.Drawing.Size(179, 20);
            this.txtPassRCB.TabIndex = 6;
            this.txtPassRCB.Text = "Banco@04";
            this.txtPassRCB.UseSystemPasswordChar = true;
            this.txtPassRCB.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            this.txtPassRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassRCB_Validating);
            this.txtPassRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassRCB1_Validating);
            this.txtPassRCB.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassRCB2_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(9)))), ((int)(((byte)(2)))), ((int)(((byte)(94)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(156, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "RCB";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(719, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "CTA - CICS";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtPassCICS
            // 
            this.txtPassCICS.Location = new System.Drawing.Point(682, 173);
            this.txtPassCICS.Name = "txtPassCICS";
            this.txtPassCICS.Size = new System.Drawing.Size(179, 20);
            this.txtPassCICS.TabIndex = 15;
            this.txtPassCICS.Text = "2020Casa";
            this.txtPassCICS.UseSystemPasswordChar = true;
            this.txtPassCICS.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            this.txtPassCICS.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassCICS_Validating);
            this.txtPassCICS.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassCICS1_Validating);
            this.txtPassCICS.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassCICS2_Validating);
            // 
            // txtUserCICS
            // 
            this.txtUserCICS.Location = new System.Drawing.Point(682, 139);
            this.txtUserCICS.Name = "txtUserCICS";
            this.txtUserCICS.Size = new System.Drawing.Size(179, 20);
            this.txtUserCICS.TabIndex = 14;
            this.txtUserCICS.Text = "x210595";
            this.txtUserCICS.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            this.txtUserCICS.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserCICS_Validating);
            this.txtUserCICS.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserCICS2_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label8.Location = new System.Drawing.Point(396, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "SISCOB - CSLog";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtPassSISCOB
            // 
            this.txtPassSISCOB.Location = new System.Drawing.Point(388, 173);
            this.txtPassSISCOB.Name = "txtPassSISCOB";
            this.txtPassSISCOB.Size = new System.Drawing.Size(179, 20);
            this.txtPassSISCOB.TabIndex = 20;
            this.txtPassSISCOB.Text = "flex2018";
            this.txtPassSISCOB.UseSystemPasswordChar = true;
            this.txtPassSISCOB.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            this.txtPassSISCOB.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassSISCOB_Validating);
            this.txtPassSISCOB.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassSISCOB1_Validating);
            this.txtPassSISCOB.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassSISCOB2_Validating);
            // 
            // txtUserSISCOB
            // 
            this.txtUserSISCOB.Location = new System.Drawing.Point(388, 139);
            this.txtUserSISCOB.Name = "txtUserSISCOB";
            this.txtUserSISCOB.Size = new System.Drawing.Size(179, 20);
            this.txtUserSISCOB.TabIndex = 19;
            this.txtUserSISCOB.Text = "301";
            this.txtUserSISCOB.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            this.txtUserSISCOB.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserSISCOB_Validating);
            this.txtUserSISCOB.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserSISCOB2_Validating);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(470, 247);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 39);
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(2)))), ((int)(((byte)(94)))));
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(888, 330);
            this.Controls.Add(this.txtCNPJRCB);
            this.Controls.Add(this.txtPassSISCOB);
            this.Controls.Add(this.txtUserRCB);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtPassRCB);
            this.Controls.Add(this.txtPassCICS);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserSISCOB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUserCICS);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCNPJRCB;
        private System.Windows.Forms.TextBox txtUserRCB;
        private System.Windows.Forms.TextBox txtPassRCB;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPassCICS;
		private System.Windows.Forms.TextBox txtUserCICS;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtPassSISCOB;
		private System.Windows.Forms.TextBox txtUserSISCOB;
		private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}


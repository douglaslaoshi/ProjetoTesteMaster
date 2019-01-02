using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using WindowsFormsApp1.Utils;
using System.Threading.Tasks;
using Facilita;
using System.Windows.Threading;

//using Santander.Automation.TN3270Bot;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string UserCICSText;
		public static string PassCICSText;
		public static string Contrato { get; set; }
        private TestStack.White.UIItems.WindowItems.Window chamada3cx;
        private TestStack.White.UIItems.WindowItems.Window discador;
        private TestStack.White.UIItems.WindowItems.Window f2;
   


        public Form1()
        {
            InitializeComponent();
 
#if DEBUG       
            txtUserRCB.Text = "FL47250";
            txtPassRCB.Text = "BANCO@30";
            txtUserCICS.Text = "x208430";
            txtPassCICS.Text = "amor2525";
            txtUserSISCOB.Text = "301";
            txtPassSISCOB.Text = "flex2019";
#endif
            KillProcess("3CXPhone");
            KillProcess("cobdesk");
            WebDriverExtensions.KillChrome();
            UserCICSText = txtUserCICS.Text;
            PassCICSText = txtPassCICS.Text;

            //WebServiceSiscob.CallWebService();

            //Thread.Sleep(30000);

          

        }

		

		private static Process getProcess(string process)
        {
            Process[] process1 = Process.GetProcessesByName(process);

            if (process1.Count() > 0)
            {
                return process1[0];
            }
            else
            {
                return null;
            }

        }

        private static void KillProcess(string process)
        {
            Process[] process1 = Process.GetProcessesByName(process);

            if (process1.Count() > 0)
            {
                process1[0].Kill();
            }

        }

       

        private async void button1_ClickAsync(object sender, EventArgs e)

		{
            if(String.IsNullOrEmpty(txtCNPJRCB.Text) || String.IsNullOrEmpty(txtUserRCB.Text)
                || String.IsNullOrEmpty(txtPassRCB.Text) || String.IsNullOrEmpty(txtUserCICS.Text)
                    || String.IsNullOrEmpty(txtPassCICS.Text) || String.IsNullOrEmpty(txtUserSISCOB.Text)
                || String.IsNullOrEmpty(txtPassSISCOB.Text))
            {

                DialogResult result2 = MessageBox.Show(
                "Usuario ou senha está incompleto!!",
                "Facilita",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                );


                return;
            }
            barraApp();

            //WebServiceSiscob.CallWebService("95671555", "01", "Teste Robo");		

            this.Hide();

            //Tela registro para finalizar acordo ou cancelar
            //Form1 f = Application.OpenForms["Form1"] as Form1;
            //Form1 f = new Form1();
           
            //-----------------------------------------------------------------------------------------------------------
            //TelaRegistro cons = new TelaRegistro(f.txtUserCICS.Text, f.txtPassCICS.Text, "TCPIP71.santanderbr.corp", 2023);
            //-----------------------------------------------------------------------------------------------------------
            //cons.Show();
            //Thread.Sleep(1000);
            //cons.Activate();

            await Siscob.IniLogin();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += timer_Tick;
            timer.Start();

        }

		 void timer_Tick(object sender, EventArgs e)
		{
			var app2 = TestStack.White.Application.Attach("cobdesk");
			int timeout1 = 0;
		
				var windows1 = app2.GetWindows();

				foreach (var wind1 in windows1)
				{
					if (wind1.Name.Contains("Chamada DISCADOR"))
					{
						var discador = wind1;
                        //Identifica Ativo/Receptivo
                        //var txtCpf = discador.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("txtUserDefined14"));
                        var txtsAtendimento = wind1.GetMultiple<TestStack.White.UIItems.TextBox>(SearchCriteria.ByControlType(ControlType.Edit));

                        var fechar = discador.Get(SearchCriteria.ByText("Fechar"));
						fechar.SetForeground();
						fechar.Focus();
						Thread.Sleep(100);
						fechar.Click();
						Thread.Sleep(1500);

                    if (txtsAtendimento.Count() > 16)
                    {
                        //iniciar tela registro receptivo
                        Siscob.TelaReg(true);

                    }
                    else
                    {
                        //iniciar tela registro ativo
                        Siscob.TelaReg(false);
                    }

                    timeout1 = 10000;
						break;
					}

				}
				Console.WriteLine(timeout1++);
				Thread.Sleep(1000);

		


		}

		public void barraApp()
        {
            
            BarraAplicativos barraApp = new BarraAplicativos();
            barraApp.Show();

        }

        

		private InitializeOption AndIndex(int v)
        {
            throw new NotImplementedException();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {



        }
        private void button4_Click(object sender, EventArgs e)
        {

			Form1 f = Application.OpenForms["Form1"] as Form1;
			f.Close();
			//Application.Exit();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
			
	}

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        internal static string ReferenceEquals(object text)
        {
            throw new NotImplementedException();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }



        private void txtCNPJRCB_Validating(object sender, CancelEventArgs e)
        {
            if (txtCNPJRCB.Text.Length >= 15)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCNPJRCB, "CNPJ Inválido");
            }


        }
        private void txtCNPJRCB2_Validating(object sender, CancelEventArgs e)
        {
            if (txtCNPJRCB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCNPJRCB, "Preencher campo !!!");
            }


        }

        private void txtUserRCB_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserRCB.Text.Length >= 8)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserRCB, "Usuário RCB Inválido");

            }

        }
        private void txtUserRCB2_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserRCB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserRCB, "Preencher campo !!!");

            }

        }
        private void txtPassRCB_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassRCB.Text.Length >= 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassRCB, "Senha RCB Inválido");

            }

        }
        private void txtPassRCB1_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassRCB.Text.Length <= 5)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassRCB, "Senha RCB deve conter pelo menos 6 caracteres");

            }

        }
        private void txtPassRCB2_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassRCB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassRCB, "Preencher campo !!!");

            }

        }

        private void txtUserSISCOB_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserSISCOB.Text.Length >= 4)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserSISCOB, "Usuário SISCOB Inválido");

            }


        }
        private void txtUserSISCOB2_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserSISCOB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserSISCOB, "Preencher campo !!!");

            }


        }
        private void txtPassSISCOB_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassSISCOB.Text.Length >= 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassSISCOB, "Senha SISCOB Inválido");

            }



        }

        private void txtPassSISCOB1_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassSISCOB.Text.Length <= 5)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassSISCOB, "Senha SISCOB deve conter pelo menos 6 caracteres");

            }



        }
        private void txtPassSISCOB2_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassSISCOB.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassSISCOB, "Preencher campo !!!");

            }



        }
        private void txtUserCICS_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserCICS.Text.Length >= 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserCICS, "Usuário CICS Inválido");

            }


        }
        private void txtUserCICS2_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserCICS.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserCICS, "Preencher campo !!!");

            }


        }
        private void txtPassCICS_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassCICS.Text.Length >= 9)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassCICS, "Senha CICS Inválido");

            }

        }
        private void txtPassCICS1_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassCICS.Text.Length <= 5)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassCICS, "Senha CICS deve conter pelo menos 6 caracteres");

            }

        }
        private void txtPassCICS2_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassCICS.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassCICS, "Preencher campo !!!");

            }

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        internal void ToString(object text)
        {
            throw new NotImplementedException();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

    }
 }







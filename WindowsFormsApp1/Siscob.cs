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
using TestStack.White.UIItems.WindowItems;

namespace WindowsFormsApp1
{
	public class Siscob
	{
		public static string UserCICSText;
		public static string PassCICSText;
		public static string Xuserr;
		public static string Contrato { get; set; }
		public static string idContrato { get; set; }
		public bool Enabled { get; private set; }
		public static Form1 formFacilita = Application.OpenForms["Form1"] as Form1;
		public static CancellationTokenSource siscobSourceToken = new CancellationTokenSource();
		public static CancellationToken siscobToken;

		//[DllImport("user32.dll")]
		//[return: MarshalAs(UnmanagedType.Bool)]
		//public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		//private const int SW_MAXIMIZE = 3;
		//private const int SW_MINIMIZE = 6;

		//private TestStack.White.UIItems.WindowItems.Window chamada3cx;
		//private TestStack.White.UIItems.WindowItems.Window discador;
		//private TestStack.White.UIItems.WindowItems.Window f2;

		public Siscob()
		{

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

		public async static Task IniLogin()

		{
			KillProcess("3CXPhone");
			KillProcess("cobdesk");

			//Licença por data de uso *************************************************************************************************
			//StreamReader sr = File.OpenText("Licenca.txt");
			//string Licenca = DateTime.Now.ToShortDateString();
			//string input = null;
			//while ((input = sr.ReadLine()) != null)
			//    if (Licenca == input)
			//{
			//    int mess = 0;
			//    while (mess++ < mess)
			//    {
			//        DialogResult msg = MessageBox.Show("LICENÇA EXPIRADA !!!","Facilita",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			//    }
			//}

			DialogResult result2 = MessageBox.Show(
			"Favor aguardar a finalização do processo automático!!!",
			"Facilita",
			MessageBoxButtons.OK,
			MessageBoxIcon.Warning
			);

			//log do sistema
			Logger.Init1("LogFlex");


			//Login SISCOB  *************************************************************************************************
			try
			{
				//Aplicação Receber Chamada para operador
				Login3CX();

				//Login SISCOBWhite
				//Form1 f1 = Application.OpenForms["Form1"] as Form1;
				if (!LoginSISCOBWhite(formFacilita.txtUserSISCOB.Text, formFacilita.txtPassSISCOB.Text))
				{
					//this.Enabled = true;
					return;
				}

			}
			catch (Exception ex)
			{
				//this.Enabled = true;
				Console.WriteLine(ex.StackTrace);
				return;

			}
			//Thread.Sleep(2000);

			return;



		}
		public static void Login3CX()
		{
			var process3cx = Process.Start(@"C:\Program Files\3CXPhone\3CXPhone.exe");
			Thread.Sleep(5000);
			SendKeys.SendWait("%{F4}");

		}


		private void LoginSISCOB(string User, string Pass)
		{
			Process.Start(@"C:\Program Files\CSLog\Cobranca2\startsiscob.exe");
			Thread.Sleep(6000);
			SendKeys.SendWait(User);
			Thread.Sleep(100);
			SendKeys.SendWait("{ENTER}");
			Thread.Sleep(100);
			SendKeys.SendWait(Pass);
			Thread.Sleep(100);
			SendKeys.SendWait("(^){ENTER} ");
			Thread.Sleep(100);
			SendKeys.SendWait("{ENTER}");
			Thread.Sleep(100);
			SendKeys.SendWait("(^){V} ");
			Thread.Sleep(100);
			SendKeys.SendWait("{BACKSPACE}");
			Thread.Sleep(100);
			SendKeys.SendWait("{ENTER}");

		}

		public static bool LoginSISCOBWhite(string User, string Pass)
		{
			//Carrega o numero do ramal das configurações do 3cx
			IniFile ramalConfig = new IniFile(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\3CX VoIP Phone\3CXVoipPhone.ini");

			int profile = 0;
			String ramal = "";

			while (true)
			{

				if (ramalConfig.KeyExists("CallerID", "Profile" + profile.ToString()))
				{
					if (ramalConfig.Read("Enabled", "Profile" + profile.ToString()).Equals("1"))
					{
						ramal = ramalConfig.Read("CallerID", "Profile" + profile.ToString());
						break;
					}
				}
				else
				{
					break;
				}
				profile++;
			}






			var appLauncher = TestStack.White.Application.Launch(@"C:\Program Files\CSLog\Cobranca2\startsiscob.exe");
			while (Process.GetProcessesByName("cobdesk").Count() == 0)
			{
				Thread.Sleep(100);
			}


			var app2 = TestStack.White.Application.Attach("cobdesk");
			var mainWindow = app2.GetWindow("Login CSLog");
			var txtLogin = mainWindow.Get(SearchCriteria.ByClassName("TEditCob"));
			txtLogin.SetValue(User);
			var txtSenha = mainWindow.Get(SearchCriteria.ByClassName("TMaskEditCob"));
			txtSenha.SetValue(Pass);
			var btnEnter = mainWindow.Get(SearchCriteria.ByText("[Ctrl + Enter]"));
			btnEnter.Click();

			Thread.Sleep(500);
			try
			{
				mainWindow.Get(SearchCriteria.ByClassName("TMaskEditCob"));
				Logger.LoginSicobError();

				DialogResult result2 = MessageBox.Show("SENHA INCORRETA. RESTA(M) 2 TENTATIVA(S) PARA BLOQUEIO !!!", "Facilita", MessageBoxButtons.OK, MessageBoxIcon.Error);
				var loginCerto = TestStack.White.Application.Attach("cobdesk");
				var ramalWindow = app2.GetWindow("Digite o seu Ramal:");
				var txtRamal = ramalWindow.Get(SearchCriteria.ByClassName("TEditCob"));
				txtRamal.SetValue(ramal);
				Thread.Sleep(300);
				ramalWindow.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);

				return true;


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				var ramalWindow = app2.GetWindow("Digite o seu Ramal:");
				var txtRamal = ramalWindow.Get(SearchCriteria.ByClassName("TEditCob"));
				txtRamal.SetValue(ramal);
				Thread.Sleep(300);
				ramalWindow.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
				Thread.Sleep(1000);

				Ligacao();
				//if (liga)
				//            {
				//                //Pronto chamada
				//                //Task.Run(() => RetornarLigacao());

				//            }

				return true;
			}

		}


		public static void Ligacao()
		{
			var app2 = TestStack.White.Application.Attach("cobdesk");

			try
			{

				var windows = app2.GetWindows();

				foreach (var wind in windows)
				{
					if (wind.Name.Contains("cslog_rr_prod"))
					{

						var chamada3cx = wind;

						var pronto = chamada3cx.Get(SearchCriteria.ByAutomationId("btnReady"));



						do
						{
							pronto.SetForeground();
							pronto.Focus();

						} while (!pronto.IsFocussed);

						Thread.Sleep(2000);
						pronto.Click();
						Thread.Sleep(2000);
						SendKeys.SendWait("{ENTER}");
						Thread.Sleep(2000);

						//ShowWindow(getProcess("3CXPhone").MainWindowHandle, SW_MINIMIZE);
						chamada3cx.Focus();

						break;
					}
				}

				//esperar e detectar chamada
				int timeout1 = 0;
				do
				{
					var windows1 = app2.GetWindows();

					foreach (var wind1 in windows1)
					{
						if (wind1.Name.Contains("Chamada DISCADOR"))
						{
							var discador = wind1;


                            //Identifica Ativo/Receptivo
                            var txtsAtendimento = wind1.GetMultiple<TestStack.White.UIItems.TextBox>(SearchCriteria.ByControlType(ControlType.Edit));
                            //Identifica Ativo/Receptivo
                            //var txtCpf = discador.Get<TestStack.White.UIItems.TextBox>(SearchCriteria.ByAutomationId("txtUserDefined14"));

                            var fechar = discador.Get(SearchCriteria.ByText("Fechar"));
                            fechar.SetForeground();
                            fechar.Focus();
                            Thread.Sleep(100);
                            fechar.Click();
                            Thread.Sleep(1500);

                            if (txtsAtendimento.Count() > 16)
                            {
                                //iniciar tela registro receptivo
                                TelaReg(true);

                            }
                            else
                            {
                                //iniciar tela registro ativo
                                TelaReg(false);
                            }

                            timeout1 = 10000;

                            break;
						}


					}

					timeout1++;
					Thread.Sleep(1000);

				} while (timeout1 <= 10000);



			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return;
			}

		}
		public static void TelaReg(bool ligacao)
		{
			var app = TestStack.White.Application.Attach("cobdesk");
			var windows = app.GetWindows();
			foreach (var wind2 in windows)
			{
				if (wind2.Name.Contains("cslog_rr_prod"))
				{
					try
					{

						var numContrato = wind2.GetMultiple<TestStack.White.UIItems.TextBox>(SearchCriteria.ByControlType(ControlType.Edit));
						//Console.WriteLine(numContrato[18].Text.ToString());
						Contrato = numContrato[18].Text.ToString();
                        //idContrato = numContrato[41].Text.ToString();

                        //int id = 0;
                        //foreach(TestStack.White.UIItems.TextBox t in numContrato)
                        //{
                        //    Console.WriteLine(id + " - " + t.Text);
                        //    id++;
                        //}


                        //Form1 df = Application.OpenForms["Form1"] as Form1;
                        //formFacilita.Activate();


                        if (ligacao)
                        {


                            DialogResult dialogOpen = MessageBox.Show(new Form { TopMost = true },
                            "Deseja abrir cadastro do cliente?",
                            "Facilita",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning
                            );

                            if (dialogOpen == DialogResult.No)
                            {
                                new FormNaoAbrirCadastro().Show();

                            }
                            else
                            {
                                //Tela registro para finalizar acordo ou cancelar
                                Form1 f = Application.OpenForms["Form1"] as Form1;
                                //Form1 f = new Form1();                           
                                //-----------------------------------------------------------------------------------------------------------
                                TelaRegistro cons = new TelaRegistro(f.txtUserCICS.Text, f.txtPassCICS.Text, "TCPIP71.santanderbr.corp", 2023);
                                //-----------------------------------------------------------------------------------------------------------
                                cons.Show();
                                //Thread.Sleep(1000);
                                cons.Activate();

                            }
                        }
                      

					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.StackTrace);
					}
				}
			}

			

		}
		

	}
}

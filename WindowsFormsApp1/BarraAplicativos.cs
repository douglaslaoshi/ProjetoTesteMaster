using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using TestStack.White.UIItems.Finders;

namespace WindowsFormsApp1
{
    public partial class BarraAplicativos : Form
    {
        Form1 f1 = Application.OpenForms["Form1"] as Form1;
        private ChromeDriver driver;

        public BarraAplicativos()
        {
            InitializeComponent();
			//initCTA();
			//initRCB();
			//initSiscob();
	
		}
		

		private void button1_Click(object sender, EventArgs e)
        {
            initSiscob();
        }

        public void initSiscob()
        {
            KillProcess("3CXPhone");
            KillProcess("cobdesk");

            //dialogAguarde();

            //log do sistema
            Logger.Init1("LogFlex");

            //Login SISCOB  *************************************************************************************************
            try
            {
                //Aplicação Receber Chamada para operador
                Siscob.Login3CX();

                //Login SISCOBWhite

                if (!Siscob.LoginSISCOBWhite(f1.txtUserSISCOB.Text, f1.txtPassSISCOB.Text))
                {
                    this.Enabled = true;
                    return;
                }

            }
            catch
            {
                this.Enabled = true;
                return;

            }
            //Thread.Sleep(2000);



            //dialogFinalizado();


        }

        private void dialogAguarde()
        {
            DialogResult result2 = MessageBox.Show(
              "Favor aguardar a finalização do processo automático!!!",
              "Facilita",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning
              );
            

        }

        private void dialogFinalizado()
        {
            DialogResult result2 = MessageBox.Show(
              "Processo automático finalizado!!!",
              "Facilita",
              MessageBoxButtons.OK,
              MessageBoxIcon.Warning
              );

        }

        private static void KillProcess(string process)
        {
            Process[] process1 = Process.GetProcessesByName(process);

            if (process1.Count() > 0)
            {
                process1[0].Kill();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            initRCB();
        }

        public void initRCB()
        {
            //dialogAguarde();

            try
            {


                if (!LoginRCB(f1.txtCNPJRCB.Text, f1.txtUserRCB.Text, f1.txtPassRCB.Text))
                {

                    this.Enabled = true;
                    return;
                }
                else
                {



                    this.Enabled = true;
                    //dialogFinalizado();
                    return;
                }
            }
            catch
            {
                this.Enabled = true;
                //dialogFinalizado();
                return;
            }

        }

        bool LoginRCB(string Cnpj, string UserRcb, string PassRcb)
        {

            WebDriverExtensions.KillDriversAndBrowsers();
            ChromeOptions options = new ChromeOptions();/*FirefoxDriver(@"c:\");*/
            options.AddArguments("no-sandbox");
            options.AddArguments("disable-extensions");
            options.AddAdditionalCapability("useAutomationExtension", false);
            //string chromePath = @"C:\ProgramData\Microsoft\AppV\Client\Integration\8F06C98E - CE78 - 4FCF - B8E3 - 68C443159F3F\Root\VFS\ProgramFilesX86\Google\Chrome\Application\chrome.exe";         
            driver = new ChromeDriver(options);

            driver.Url = "https://negocios.santander.com.br/RcbWeb";
            driver.Manage().Window.Maximize();
            driver.Navigate().Refresh();
            WebDriverExtensions.WaitForPageLoad(driver);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            WebDriverWait wait10 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("_id35:_id48")));
            driver.FindElement(By.Id("_id35:_id48")).SendKeys(Cnpj);
            Thread.Sleep(200);

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("_id35:_id52")));
            driver.FindElement(By.Id("_id35:_id52")).SendKeys(UserRcb);
            Thread.Sleep(200);

            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("_id35:_id56")));
            driver.FindElement(By.Name("_id35:_id56")).SendKeys(PassRcb);
            Thread.Sleep(200);

            //js.ExecuteScript("iceSubmit(form,this,event);return false;");
            SendKeys.SendWait("{ENTER}");

            try
            {
                // continua se estiver ja logado

                wait5.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("_id411:_id431")));
                IWebElement btconfirmar = driver.FindElement(By.Id("_id411:_id431"));
                btconfirmar.Click();

            }
            catch { }

            try
            {
                //erro usuario ou senha
                wait5.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("_id70:_id95")));
                IWebElement btok = driver.FindElement(By.Name("_id70:_id95"));
                Thread.Sleep(500);
                driver.Close();
                Logger.LoginRCBError();

                DialogResult result2 = MessageBox.Show("ERRO SENHA NÃO CONFERE.", "Facilita", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Thread.Sleep(500);
                return false;

            }
            catch { return true; }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            initCTA();
        }
        public void initCTA()
        {
            //dialogAguarde();
            KillProcess("PCSCM");
            KillProcess("PCSWS");

            LoginCICS(f1.txtUserCICS.Text, f1.txtPassCICS.Text);
            //dialogFinalizado();
        }

        private void LoginCICS(string User, string Pass)
        {
            
            Process.Start(@"C:\ProgramData\Microsoft\AppV\Client\Integration\53497622-CAD0-434C-A3C3-2D42D8DF3B99\Root\VFS\ProgramFilesX86\IBM\Personal Communications\private\Terminal_Financeira.WS");

            Process.Start(@"C:\ProgramData\Microsoft\AppV\Client\Integration\53497622-CAD0-434C-A3C3-2D42D8DF3B99\Root\VFS\ProgramFilesX86\IBM\Personal Communications\pcscm.exe");

            Thread.Sleep(14000);
            SendKeys.SendWait("0cicabnpt");
            Thread.Sleep(500);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait(User);
            Thread.Sleep(200);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait(Pass);
            Thread.Sleep(500);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(200);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("ocal");
            Thread.Sleep(200);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(400);
            SendKeys.SendWait("{TAB}");
            Thread.Sleep(400);
            SendKeys.SendWait("{TAB}");
        }
    }
}

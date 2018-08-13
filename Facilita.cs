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
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using TestStack.Seleno.BrowserStack.Core.Actions;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WebBrowser;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //Login SISCOB  *****************************************************************************************************


            try
            {

                try
                {
                    //Aplicação Receber Chamada para operador

                    Login3CX();


                    //TODO: colocar TRY CATCH


                    LoginSISCOBWhite(txtUserSISCOB.Text, txtPassSISCOB.Text);

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


                //Login RCB *****************************************************************************************************





                // Login CTA  *****************************************************************************************************


                LoginCICS(txtUserCICS.Text, txtPassCICS.Text);

                    if (!LoginRCB(txtCNPJRCB.Text, txtUserRCB.Text, txtPassRCB.Text))
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


        }


        private static void Login3CX()
        {
            Thread.Sleep(3000);
            Process.Start(@"C:\Program Files\3CXPhone\3CXPhone.exe");
            Thread.Sleep(7000);
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(400);
            SendKeys.SendWait("{LEFT}");
            Thread.Sleep(400);
            SendKeys.SendWait("{RIGHT}");
            Thread.Sleep(400);
            SendKeys.SendWait("{RIGHT}");
            Thread.Sleep(400);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(400);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(400);
            SendKeys.SendWait("(^){C} ");
            Thread.Sleep(400);
            SendKeys.SendWait("{ESC}");
            Thread.Sleep(400);
            SendKeys.SendWait("{ESC}");
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


        private void LoginSISCOBWhite(string User, string Pass)
        {


            var appLauncher = TestStack.White.Application.Launch(@"C:\Program Files\CSLog\Cobranca2\startsiscob.exe");
            while (Process.GetProcessesByName("cobdesk").Count() == 0)
            {
                Thread.Sleep(100);
            }


            var app2 = TestStack.White.Application.Attach("cobdesk");
            var mainWindow = app2.GetWindow("Login CSLog");
            // var dbg = TestStack.White.Debug.Details(mainWindow.AutomationElement);
            //1443170 Senha
            //459426 Login
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
                app2.Close();
                MessageBox.Show("***********************    ERRO DE LOGIN !!!   ***********************");

                return;

            }
            catch (Exception)
            {
                var ramalWindow = app2.GetWindow("Digite o seu Ramal:");
                //var dbg1 = TestStack.White.Debug.Details(ramalWindow.AutomationElement);
                var txtRamal = ramalWindow.Get(SearchCriteria.ByClassName("TEditCob"));
                txtRamal.SetForeground();
                txtRamal.Focus();
                SendKeys.SendWait("(^){V}");
                ramalWindow.Keyboard.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);

                return;

            }

        }



        /// <summary>
        /// Faz login no sistema RCB
        /// </summary>
        /// <param name="CNPJ"></param>
        /// <param name="User"></param>
        /// <param name="Pass"></param>
        /// <returns>Retorna true em caso de login com sucesso</returns>
        private bool LoginRCB(string CNPJ, string User, string Pass)
        {

            IWebDriver driver = new FirefoxDriver(@"c:\");
            Thread.Sleep(800);
            driver.Url = "https://negocios.santander.com.br/RcbWeb";
            driver.Manage().Window.Maximize();
            Thread.Sleep(700);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            WebDriverWait wait10 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("_id35:_id48")));
            driver.FindElement(By.Id("_id35:_id48")).SendKeys(CNPJ);

            Thread.Sleep(800);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("_id35:_id52")));
            driver.FindElement(By.Id("_id35:_id52")).SendKeys(User);

            Thread.Sleep(800);
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("_id35:_id56")));
            driver.FindElement(By.Name("_id35:_id56")).SendKeys(Pass);
            SendKeys.SendWait("{ENTER}");


            try
            {
                wait10.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("_id70:_id95")));
                IWebElement btconfirmar = driver.FindElement(By.Name("_id70:_id95"));
                Thread.Sleep(500);
                driver.Close();

                MessageBox.Show("***********************    ERRO DE LOGIN !!!   ***********************");


                Thread.Sleep(500);

                return false;

            }
            catch (Exception)
            {
                wait5.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("mnu1:_id52")));
                IWebElement acordos = driver.FindElement(By.Id("mnu1:_id52"));
                acordos.Click();

                wait5.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("mnu1:_id55")));
                IWebElement inclusao = driver.FindElement(By.Id("mnu1:_id55"));
                inclusao.Click();
                Thread.Sleep(2000);
                return true;

            }
        }
        private void LoginCICS(string User, string Pass)
        {
            Thread.Sleep(3000);
            Process.Start(@"C:\ProgramData\Microsoft\AppV\Client\Integration\163F9BEB-E7BC-4A83-8B8A-8A4C8C6CE32C\Root\VFS\ProgramFilesX86\IBM\Personal Communications\private\Terminal_Financeira.WS");
            Thread.Sleep(8000);
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
            Thread.Sleep(100);
            SendKeys.SendWait("{TAB}");
            Thread.Sleep(100);
            SendKeys.SendWait("{TAB}");
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


            Application.Exit();


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
            if (txtCNPJRCB.Text.Length != 14)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCNPJRCB, "CNPJ Inválido");
            }


        }

        private void txtUserRCB_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserRCB.Text.Length != 7)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserRCB, "Usuário RCB Inválido");

            }

        }
        private void txtPassRCB_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassRCB.Text.Length != 8)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassRCB, "Senha RCB Inválido");

            }

        }
        private void txtUserSISCOB_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserSISCOB.Text.Length != 3)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserSISCOB, "Usuário SISCOB Inválido");

            }


        }
        private void txtPassSISCOB_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassSISCOB.Text.Length != 7)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassSISCOB, "Senha SISCOB Inválido");

            }


        }
        private void txtUserCICS_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserCICS.Text.Length != 7)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserCICS, "Senha SISCOB Inválido");

            }


        }
        private void txtPassCICS_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassCICS.Text.Length != 8)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassCICS, "Senha SISCOB Inválido");

            }

        }


    }
}






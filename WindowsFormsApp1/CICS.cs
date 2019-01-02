using Open3270;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
//using WindowsFormsApp1;

namespace Santander.Automation.TN3270Bot
{
    public class CICS : IAudit
    {
        private int _timeout = 200000;
        private int _maxRetries = 20;
        public static string Nomecliente;

        public TNEmulator ConnectAndLogin(string user, string pass, string ip, int port)
        {
            TNEmulator emulator = new TNEmulator();
            emulator.Audit = this;
            emulator.Debug = false;
            emulator.Config.TermType = "IBM-3278-2-E";
            emulator.Config.FastScreenMode = true;
            emulator.Connect(ip, port, null);
            if (!emulator.WaitForText(0, 5, "THIS TERMINAL IS LOGGED ON", _timeout))
                throw new Exception("Erro ao logar, não encontrada mensagem: THIS TERMINAL IS LOGGED ON");
            emulator.SendText("0cicabnpt");
            emulator.SendKey(true, TnKey.Enter, _timeout);
            emulator.SendKey(true, TnKey.Enter, _timeout);

            if (!emulator.WaitForText(1, 2, "WELCOME TO CICS", _timeout))
                throw new Exception("Erro ao logar, não encontrada mensagem: WELCOME TO CICS");

            WriteTextToField(emulator.CurrentScreenXML.Fields[18], emulator, user);
            WriteTextToField(emulator.CurrentScreenXML.Fields[25], emulator, pass);
            emulator.SendKey(true, TnKey.Enter, _timeout);
            emulator.WaitForHostSettle(200, _timeout);
            emulator.SendKey(true, TnKey.Enter, _timeout);

            if (!emulator.WaitForText(5, 0, "CICS-SSO", _timeout))
                throw new Exception("Erro ao logar, não encontrada mensagem: CICS-SSO");
            return emulator;
        }

      

        public void ResetToMainMenu(TNEmulator emulator)
        {
            int count = 0;
            while (count <= _maxRetries)
            {
                //emulator.SendKey(true, TnKey.F3, _timeout);
                emulator.WaitForHostSettle(2000, _timeout);
                if (emulator.CurrentScreenXML.Dump().Contains("Aymore Financiamentos"))
                    return;
                count++;
            }
            throw new Exception("Erro ao retornar ao menu principal, não encontrada mensagem: Aymore Financiamentos");
        }

        public List<string> AutorizarDispensaJuros(TNEmulator emulator)
        {
            List<string> contratosAprovados = new List<string>();
            ResetToMainMenu(emulator);
            //string menuOption = "";
            //for (int i = 0; i < emulator.CurrentScreenXML.Fields.Length; i++)
            //{
            //if (emulator.CurrentScreenXML.Fields[3].Text != null)
            //{
            WriteTextToField(emulator.CurrentScreenXML.Fields[3], emulator, "ocal");
            emulator.SendKey(true, TnKey.Enter, _timeout);
            Console.Write(emulator.CurrentScreenXML.Dump());

            //break;
            //}
            //}

            WriteTextToField(emulator.CurrentScreenXML.Fields[22], emulator, "20026731403");

            emulator.SendKey(true, TnKey.Enter, _timeout);

            emulator.SendKey(true, TnKey.F2, _timeout);

            //Nomecliente = emulator.CurrentScreenXML.Fields[21].Text;

           

            Nomecliente = emulator.CurrentScreenXML.Fields[21].Text;

            TelaRegistro tl = new TelaRegistro();
            tl.NomeC.Text = Nomecliente;

            //TelaRegistro reg = new TelaRegistro();
            //reg.NomeC.Text = Nomecliente

            //DialogResult result6 = MessageBox.Show(tl.NomeC.Text, "Facilita", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //WriteTextToField(emulator.CurrentScreenXML.Fields[21].Text, "");
            Console.Write(emulator.CurrentScreenXML.Dump());













            //if (string.IsNullOrEmpty(menuOption))
            //    throw new Exception("Erro ao autorizar despesa, não foi possível encontrar a opção do menu");
            //emulator.SetText(menuOption);
            //emulator.SendKey(true, TnKey.Enter, _timeout);
            //emulator.SendKey(true, TnKey.Enter, _timeout);
            //if (!emulator.WaitForText(27, 1, "ATENDIMENTO AO CLIENTE", _timeout))
            //    throw new Exception("Erro ao logar, não encontrada mensagem: ATENDIMENTO AO CLIENTE");
            //emulator.WaitForHostSettle(200, _timeout);
            //emulator.SetText("16");
            //emulator.SendKey(true, TnKey.Enter, _timeout);
            //WriteTextToField(emulator.CurrentScreenXML.Fields[18], emulator, "10");
            //WriteTextToField(emulator.CurrentScreenXML.Fields[38], emulator, "i");
            //WriteTextToField(emulator.CurrentScreenXML.Fields[46], emulator, "2");
            //WriteTextToField(emulator.CurrentScreenXML.Fields[67], emulator, "1235");
            //if (!emulator.SendKey(true, TnKey.Enter, _timeout))
            //    throw new Exception("Timeout ao entrar na tela de dispensa de juros");
            //if (String.IsNullOrEmpty(emulator.CurrentScreenXML.Fields[45].Text))
            //{
            //    Console.Clear();
            //    Console.Write(emulator.CurrentScreenXML.Dump());
            //    return contratosAprovados;
            //}
            //else
            //{

            //    //12 linhas, com 12 campos por linha
            //    for (int i = 45; i < 45 + (12 * 12); i += 12)
            //    {
            //        //i = index contrato
            //        //aprovacao = i-1
            //        //taxa = i+7
            //        if (!String.IsNullOrEmpty(emulator.CurrentScreenXML.Fields[i].Text))
            //        {
            //            if (float.TryParse(emulator.CurrentScreenXML.Fields[i + 7].Text, out float taxa))
            //            {
            //                if (taxa <= 100)
            //                {
            //                    contratosAprovados.Add(emulator.CurrentScreenXML.Fields[i].Text);
            //                    WriteTextToField(emulator.CurrentScreenXML.Fields[i - 1], emulator, "a");
            //                }
            //                else
            //                {

            //                    // DESCOMENTAR PARA REPROVAR SE FOR MAIOR QUE 100%
            //                    //WriteTextToField(emulator.CurrentScreenXML.Fields[i - 1], emulator, "r");
            //                    //contratosAprovados.Add("r"+emulator.CurrentScreenXML.Fields[i].Text);
            //                }
            //            }
            //        }



            //    }
            //    Console.Clear();
            //    Console.Write(emulator.CurrentScreenXML.Dump());
            //    if (contratosAprovados.Any())
            //    {

            //        emulator.SendKey(true, TnKey.F5, _timeout);
            //    }

            //}


            return contratosAprovados;

        }
        //public void Nomecliente(Open3270.TN3270.XMLScreenField field, TNEmulator emulator, string Nomecliente)
        //{
        //    Nomecliente = emulator.CurrentScreenXML.Fields[21].Text;
        //    emulator.SetText(emulator.CurrentScreenXML.Fields[21].Text);

        //}
       

        private void WriteTextToField(Open3270.TN3270.XMLScreenField field, TNEmulator emulator, string text)
        {
            emulator.SetText(text, field.Location.left, field.Location.top);
        }


        public void Write(string text)
        {

        }

        public void WriteLine(string text)
        {
        }
    }
}

using Open3270;
using Santander.Automation.TN3270Lib.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Santander;
using System.Threading;
using System.Globalization;



namespace Santander.Automation.TN3270Lib
{
    public class CICS 
    {
        private int _timeout = 200000;
        private int _maxRetries = 20;
        private string _user, _pass,_ip;
        private int _port;
        
        TNEmulator ConnectAndLogin(string user, string pass, string ip, int port)
        {
            CloseTerminal();
            TNEmulator emulator = new TNEmulator();
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
            emulator.WaitForHostSettle(100, _timeout);
            emulator.SendKey(true, TnKey.Enter, _timeout);

            if (!emulator.WaitForText(5, 0, "CICS-SSO", _timeout))
                throw new Exception("Erro ao logar, não encontrada mensagem: CICS-SSO");
            return emulator;
        }

        void ResetToMainMenu(TNEmulator emulator)
        {
            int count = 0;
            while (count <= _maxRetries)
            {

                emulator.WaitForHostSettle(50, _timeout);
                if (emulator.CurrentScreenXML.Dump().Contains("Aymore Financiamentos"))
                    return;
                count++;
            }
            throw new Exception("Erro ao retornar ao menu principal, não encontrada mensagem: Aymore Financiamentos");
        }
       
        public CICS(string user, string pass, string ip, int port)
        {
            _user = user;
            _pass = pass;
            _ip = ip;
            _port = port;
           
        }



        private void WriteTextToField(Open3270.TN3270.XMLScreenField field, TNEmulator emulator, string text)
        {
            emulator.SetText(text, field.Location.left, field.Location.top);
        }
        private void Write(string text)
        {

        }
       
        private void WriteLine(string text)
        {
        }

        public LaminaContrato GetOcalCalc(string contrato, DateTime data)
        {
            
            using (var emulator = ConnectAndLogin(_user, _pass, _ip, _port))
            {
                ResetToMainMenu(emulator);
                emulator.WaitForHostSettle(100, _timeout);
                
                //Navega até a tela Ocal
                WriteTextToField(emulator.CurrentScreenXML.Fields[3], emulator, "ocal");
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(100, _timeout);

                //Pesquisa pelo contrato
                WriteTextToField(emulator.CurrentScreenXML.Fields[22], emulator, (contrato));
                Thread.Sleep(100);
                emulator.SendKey(true, TnKey.Enter, _timeout);
                Thread.Sleep(50);
               

                //Pega num total de parcelas
                string total = "";
                string[] tot = emulator.CurrentScreenXML.Fields[25].Text.ToString().Split(' ');

                for (int p = 0; p< tot.Length; p++)
                {
                    if(tot[p] == "PAR")
                    {
                        total = tot[p + 2];
                        break;
                    }
                }

                int TotalParcelas = int.Parse(total);

                Thread.Sleep(50);
                emulator.SendKey(true, TnKey.F2, _timeout);

                Thread.Sleep(50);


                var retVal = new LaminaContrato();

                //Captura de dados do cliente
                retVal.NomeCliente = emulator.CurrentScreenXML.Fields[21].Text.Substring(8,35);             
                retVal.CpfCli = emulator.CurrentScreenXML.Fields[23].Text.Substring(10,16);
                retVal.Nascimento = emulator.CurrentScreenXML.Fields[23].Text.Substring(58);
                retVal.Endereco = emulator.CurrentScreenXML.Fields[25].Text.Substring(0,40); 
                retVal.BairroC = emulator.CurrentScreenXML.Fields[25].Text.Substring(40);
                retVal.Cidade = emulator.CurrentScreenXML.Fields[27].Text;
                emulator.SendKey(true, TnKey.F2, _timeout);
                retVal.Marca = emulator.CurrentScreenXML.Fields[35].Text.Substring(0,50);
                retVal.Cor = emulator.CurrentScreenXML.Fields[37].Text.Substring(0,60);
                retVal.TIC = emulator.CurrentScreenXML.Fields[63].Text;

                //Pega parcela atual
                
                emulator.SendKey(true, TnKey.F2, _timeout);
                string[] atu = emulator.CurrentScreenXML.Fields[23].Text.ToString().Split(' ');
                int parcelaAtual = int.Parse(atu[1]);
                //Console.Write(emulator.CurrentScreenXML.Dump());

                //Navegação até a tela CALC 
                //emulator.SendKey(true, TnKey.F2, _timeout);
                WriteTextToField(emulator.CurrentScreenXML.Fields[2], emulator, "calc");
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(100, _timeout);
             

                retVal.ContratoCliente = emulator.CurrentScreenXML.Fields[24].Text;
                WriteTextToField(emulator.CurrentScreenXML.Fields[27], emulator, data.ToString("ddMMyyyy"));
                emulator.SendKey(true, TnKey.Enter, _timeout);
              
                //Console.Write(emulator.CurrentScreenXML.Dump());
                //Captura de parcelas

                for (int p = 0; p <= ((TotalParcelas - parcelaAtual) /6); p++)
                { 

                    for (int i = 0; i <=6; i++)
                    {
                        var toAdd = new ParcelaLaminaContrato();

                            toAdd.Parcela = emulator.CurrentScreenXML.Fields[81 + (16 * i)].Text;
                            toAdd.Vencimento = emulator.CurrentScreenXML.Fields[83 + (16 * i)].Text;
                            toAdd.ValorParcela = emulator.CurrentScreenXML.Fields[85 + (16 * i)].Text;
                            toAdd.JurosDesc = emulator.CurrentScreenXML.Fields[87 + (16 * i)].Text;
                            toAdd.IOF = emulator.CurrentScreenXML.Fields[89 + (16 * i)].Text;
                            toAdd.Tec = emulator.CurrentScreenXML.Fields[90 + (16 * i)].Text;
                            toAdd.ValorTotal = emulator.CurrentScreenXML.Fields[92 + (16 * i)].Text;
                            toAdd.Gca = emulator.CurrentScreenXML.Fields[204].Text;

                        if (emulator.CurrentScreenXML.Fields[85 + (16 * i)].Text != null)
                        {
                            retVal.Parcelas.Add(toAdd);
                    
                        }
                    }

                 

                    emulator.SendKey(true, TnKey.F8, _timeout);
                   
                }

            return retVal;
            }
        }
        public List<String> GetHistoricoContatosAnt(string contrato)
        {

            List<String> result = new List<String>();

            using (var emulator = ConnectAndLogin(_user, _pass, _ip, _port))
            {
                ResetToMainMenu(emulator);
                emulator.WaitForHostSettle(100, _timeout);

                //Navega até a tela Ocal
                WriteTextToField(emulator.CurrentScreenXML.Fields[3], emulator, "ocal");

                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);

                //Pesquisa pelo contrato
                WriteTextToField(emulator.CurrentScreenXML.Fields[22], emulator, (contrato));
                emulator.SendKey(true, TnKey.Enter, _timeout);

                //Acessa histórico de contatos
                WriteTextToField(emulator.CurrentScreenXML.Fields[2], emulator, "ocvi");
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);

                String linha = "";

                do
                {

                    for (int i = 0; i < 13; i++)
                    { 
                        LaminaHistContatosAnt hist = new LaminaHistContatosAnt();

                        linha = emulator.CurrentScreenXML.Fields[54 + (2 * i)].Text;

                        if (!String.IsNullOrEmpty(linha))
                        {
                            result.Add(linha);
                        }
                        
                    }

                    emulator.SendKey(true, TnKey.F8, _timeout);
                    emulator.WaitForHostSettle(50, _timeout);

                } while (result.Any("END".Contains));
            }

            return result;

        }

        public List<LaminaHistPagamento> GetHistoricoPagamento(string contrato)
        {

            List<LaminaHistPagamento> result = new List<LaminaHistPagamento>();

            using (var emulator = ConnectAndLogin(_user, _pass, _ip, _port))
            {
                do
                {
                    emulator.SendKey(true, TnKey.Enter, _timeout);
                    emulator.SendKey(true, TnKey.Enter, _timeout);

                    ResetToMainMenu(emulator);
                    emulator.WaitForHostSettle(50, _timeout);

                    //Navega até a tela Ocal
                    WriteTextToField(emulator.CurrentScreenXML.Fields[3], emulator, "ocal");
                    emulator.SendKey(true, TnKey.Enter, _timeout);
                    emulator.WaitForHostSettle(100, _timeout);

                    //Pesquisa pelo contrato
                    WriteTextToField(emulator.CurrentScreenXML.Fields[22], emulator, (contrato));
                    Thread.Sleep(50);
                    emulator.SendKey(true, TnKey.Enter, _timeout);
                    emulator.WaitForHostSettle(100, _timeout);

                    //Acessa histórico de pagamento
                    WriteTextToField(emulator.CurrentScreenXML.Fields[2], emulator, "hist");
                    Thread.Sleep(50);
                    emulator.SendKey(true, TnKey.Enter, _timeout);
                    emulator.WaitForHostSettle(50, _timeout);

                } while (emulator.CurrentScreenXML.Fields.Count() < 66);

                do
                {

                    for (int i = 0; i < 8; i++)
                    {

                        LaminaHistPagamento hist = new LaminaHistPagamento();
                        hist.prt = emulator.CurrentScreenXML.Fields[66 + (8 * i)].Text;
                        hist.dataMotivo = emulator.CurrentScreenXML.Fields[67 + (8 * i)].Text;
                        hist.dataOcorrencia = emulator.CurrentScreenXML.Fields[68 + (8 * i)].Text;
                        hist.situacao = emulator.CurrentScreenXML.Fields[69 + (8 * i)].Text;
                        hist.ageReceb = emulator.CurrentScreenXML.Fields[70 + (8 * i)].Text;
                        hist.vlOcorrencia = emulator.CurrentScreenXML.Fields[71 + (8 * i)].Text;
                        hist.vlPrestacao = emulator.CurrentScreenXML.Fields[72 + (8 * i)].Text;

                        result.Add(hist);

                    }

                    emulator.SendKey(true, TnKey.F8, _timeout);
                    emulator.WaitForHostSettle(50, _timeout);

                    Thread.Sleep(50);

                } while (!(emulator.CurrentScreenXML.Fields[145].Text != null ? emulator.CurrentScreenXML.Fields[145].Text : "").Contains("FIM"));
                
            }
    
            return result;
            
        }

        public List<TabulacaoCta> GetTabulacaoCTA(string contrato, string tabaddmemo, string tabret, string tabaction)
        {

            List<TabulacaoCta> tabula = new List<TabulacaoCta>();
            try
            {

            using (var emulator = ConnectAndLogin(_user, _pass, _ip, _port))
            {
                ResetToMainMenu(emulator);
                emulator.WaitForHostSettle(50, _timeout);

                //Navega até a tela Ocal
                WriteTextToField(emulator.CurrentScreenXML.Fields[3], emulator, "ocal");
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);

                //Pesquisa pelo contrato
                WriteTextToField(emulator.CurrentScreenXML.Fields[22], emulator, (contrato));
                Thread.Sleep(50);
                emulator.SendKey(true, TnKey.Enter, _timeout);
                    
                    //campo mensagem da tabulacao
                    if (tabaddmemo.Length > 49)
                    {
                        int pages = (tabaddmemo.Length / 49);
                       
                        for (int p = 0; p < pages; p++)
                        {
                            String msg1 = tabaddmemo.Substring((p * 49), 49);
                            WriteTextToField(emulator.CurrentScreenXML.Fields[96], emulator, msg1);
                            Thread.Sleep(50);
                            emulator.SendKey(true, TnKey.Enter, _timeout);
                            emulator.WaitForHostSettle(50, _timeout);
                            Thread.Sleep(50);
                        }
                        String lastPage = tabaddmemo.Substring((pages * 49));
                        WriteTextToField(emulator.CurrentScreenXML.Fields[96], emulator, lastPage);
                        Thread.Sleep(50);
                    }
                    else
                    {
                        WriteTextToField(emulator.CurrentScreenXML.Fields[96], emulator, tabaddmemo);
                    }

                //RET sempre vai ser valor 3 
                WriteTextToField(emulator.CurrentScreenXML.Fields[100], emulator, tabret);

                //action codigo da tabulacao
                WriteTextToField(emulator.CurrentScreenXML.Fields[139], emulator, tabaction);
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);

               // Console.Write(emulator.CurrentScreenXML.Dump());
                emulator.Dispose();
                emulator.Close();
            }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return tabula;

        }

        public List<TabulacaoCanc> GetCanc(string contrato)
        {

            List<TabulacaoCanc> canc = new List<TabulacaoCanc>();

            using (var emulator = ConnectAndLogin(_user, _pass, _ip, _port))
            {
                ResetToMainMenu(emulator);
                emulator.WaitForHostSettle(50, _timeout);

                //Navega até a tela Ocal
                WriteTextToField(emulator.CurrentScreenXML.Fields[3], emulator, "ocal");
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);
                emulator.SendKey(true, TnKey.Enter, _timeout);
                emulator.WaitForHostSettle(50, _timeout);

                //Pesquisa pelo contrato
                WriteTextToField(emulator.CurrentScreenXML.Fields[22], emulator, (contrato));
                Thread.Sleep(50);
                emulator.SendKey(true, TnKey.Enter, _timeout);

                //Acessa canc
                WriteTextToField(emulator.CurrentScreenXML.Fields[2], emulator, "canc");
                Thread.Sleep(50);
                emulator.SendKey(true, TnKey.Enter, _timeout);

                //Pesquisa parcela contrato             
           
                emulator.SendKey(true, TnKey.Enter, _timeout);

                var nrocodigo = emulator.CurrentScreenXML.Fields[72].Text;

                Thread.Sleep(50);
                emulator.SendKey(true, TnKey.F3, _timeout);

                WriteTextToField(emulator.CurrentScreenXML.Fields[2], emulator, "octa");
                Thread.Sleep(50);
                emulator.SendKey(true, TnKey.Enter, _timeout);



            }

            return canc;

        }

        public void CloseTerminal()
        {
            try
            {
                Process.GetProcessesByName("PCSWS")[0].Kill();
                //Process.GetProcessesByName("PCSCM")[0].Kill();
            }
            catch { }
        }
    }
}

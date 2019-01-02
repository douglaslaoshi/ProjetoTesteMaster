
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Santander.Automation.TN3270Lib;
using Santander.Automation.TN3270Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Utils;

namespace WindowsFormsApp1
{
    public partial class TelaRegistro : Form
    { 
        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //public CICS mainframe;
    

        private const int SW_MAXIMIZE = 3;
        private const int SW_MINIMIZE = 6;
        private CultureInfo culture = CultureInfo.InvariantCulture;
        private ChromeDriver driver;

        private string _user, _pass, _ip;
        private int _port;
        public static string Totalparcelas;
        public static string ValorParcela;
        public static string Vencimento;
        public Calculadora calculadora;
        public static string contrato;
        public static string idContrato;
        public static string GCA = "0.0";
        public static string txtgca;
        public static string Xuserr;
        public int Qtdparc;
        public int TotalParcelas;
        

        public TelaRegistro(string user, string pass, string ip, int port)
        {
			InitializeComponent();


			_user = user;
            _pass = pass;
            _ip = ip;
            _port = port;

         

            //this.mainframe = new Santander.Automation.TN3270Lib.CICS(_user, _pass, _ip, _port);

            calculadora = new Calculadora();
            calcula();

            //var cx = TestStack.White.Application.Attach("cobdesk");
            //var siscob = (Control)cx.GetWindows().Select(w => w.Name.Contains("cslog_rr_prod"));
            //siscob.SendToBack();

            Xuser.Text = Form1.UserCICSText;

            //copia contrato no momento da deteccao da chamada
            //var contrato = Clipboard.GetText();20028223758 20027749175 20028154413
            // contrato = "20025946587";//"20027749175";
                                     //idContrato = "95671555";

            contrato = Siscob.Contrato.Trim();
            //idContrato = Siscob.idContrato.Trim();
            //Console.WriteLine("Contrato: " + contrato);

            //informacoes da tela
            var mainframe = new Santander.Automation.TN3270Lib.CICS(_user, _pass, _ip, _port);

            var data = mainframe.GetOcalCalc(contrato, DateTime.Today.AddDays(0));

            //info cliente
            NomeC.Text = data.NomeCliente;
            ContratoCli.Text = data.ContratoCliente;
            EnderecoC.Text = data.Endereco;
            CidadeC.Text = data.Cidade;
            BairroC.Text = data.BairroC;
            CpfC.Text = data.CpfCli;
            Nascimento.Text = data.Nascimento;

            //info veiculo
            MarcaCar.Text = data.Marca;
            TicCar.Text = data.TIC;
            CorCar.Text = data.Cor;

            ////tabulação CTA

            //populaTabulacaoCTA(contrato);

            //historicos CTA 
            populaHistoricoContatosAnt(contrato);
            populaHistoricoPagamentos(contrato);








            //Qtdparcela = data.Parcelas[0].Parcela;
            //ValorParcela = data.Parcelas[0].ValorParcela;
            //Vencimento = data.Parcelas[0].Vencimento;

            //Recupera valores das parcelas do contrato
            List<LaminaContrato> datas = new List<LaminaContrato>();

            var parc = new LaminaContrato();
            var consulta = DateTime.Today;
        
            for (int d = 0; d < 5; d++)
            {

                do
                {
                    parc = mainframe.GetOcalCalc(contrato, consulta);
                    parc.dataConsulta = consulta;
                    consulta = consulta.AddDays(1);                   
                } while (parc.Parcelas.Count() == 0);

                datas.Add(parc);
                
            }

            //Carrega valores nos list views
            List<ListView> listViews = new List<ListView>();
            listViews.Add(listView1);
            listViews.Add(listView2);
            listViews.Add(listView3);
            listViews.Add(listView4);
            listViews.Add(listView5);


            for (int t = 0; t < 5; t++)
            {
                Color cor = Color.LightGray;
                foreach (Santander.Automation.TN3270Lib.Models.ParcelaLaminaContrato p in datas[t].Parcelas)
                {
                    var item = new ListViewItem();
                    item.SubItems.Add(p.Parcela);
                    item.SubItems.Add(p.Vencimento);
                    item.SubItems.Add(p.ValorParcela);
                    item.SubItems.Add(p.JurosDesc);
                    item.SubItems.Add(p.IOF);
                    item.SubItems.Add(p.Gca); //GCA = p.Gca;
                    item.SubItems.Add(p.ValorTotal);
                    listViews[t].Parent.Text = datas[t].dataConsulta.ToString("dd/MM/yyyy");

                    item.BackColor = cor;

                    if (cor == Color.LightGray)
                    {
                        cor = Color.White;
                    }
                    else
                    {
                        cor = Color.LightGray;
                    }

                    listViews[t].Items.Add(item);

                }
            }


            //ShowWindow(this.Handle, SW_MAXIMIZE);
        }



        private static void KillProcess(string process)
        {
            Process[] process1 = Process.GetProcessesByName(process);

            if (process1.Count() > 0)
            {
                process1[0].Kill();
            }

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

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            e.Graphics.DrawLine(Pens.Black, e.Bounds.Left, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom);
        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll1.Checked)
            {
                listView1.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
            }
            else
            {
                listView1.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
            }
        }

        private void selectAll2_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll2.Checked)
            {
                listView2.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
            }
            else
            {
                listView2.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
            }
        }

        private void selectAll3_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll3.Checked)
            {
                listView3.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
            }
            else
            {
                listView3.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
            }
        }

        private void selectAll4_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll4.Checked)
            {
                listView4.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
            }
            else
            {
                listView4.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
            }
        }

        private void selectAll5_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAll5.Checked)
            {
                listView5.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = true);
            }
            else
            {
                listView5.Items.OfType<ListViewItem>().ToList().ForEach(item => item.Checked = false);
            }
        }

        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.listView1.ItemCheck -= this.listView1_ItemCheck;
            List<ListViewItem> parcelas = new List<ListViewItem>();

            if (e.CurrentValue == CheckState.Unchecked)
            {

                listView1.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView1.Items.OfType<ListViewItem>().Where(item => item.Index <= e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);
                calculadora.GCA = 0;
            }
            else
            {
                listView1.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView1.Items.OfType<ListViewItem>().Where(item => item.Index < e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);

            }


            var parcelasVencidas = parcelas.Where(w => (String.IsNullOrEmpty(normalizeValue(w.SubItems[4].Text)) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) > 0).ToList();
            var parcelasVencer = parcelas.Where(w => (String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) <= 0).ToList();

            calculadora.valorParcelasVencidas = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.juros = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[4].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.IOF = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[5].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[5].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.GCA = String.IsNullOrEmpty(GCA) ? 0 : decimal.Parse(GCA.Trim().Replace(".", "").Replace(',', '.'), culture);

            calculadora.valorParcelasVencer = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[7].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[7].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.valorParcelasVencerSemDesconto = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));

            this.listView1.ItemCheck += this.listView1_ItemCheck;

            calcula();
        }

        public string normalizeValue(string valor)
        {
            string result = "";
            if (valor != null)
            {
                string[] valores = valor.Split(',');
                if (String.IsNullOrEmpty(valores[0].Trim()) || valores[0].Trim().Equals("-"))
                {
                    if (valores[0].Trim().Equals("-"))
                    {
                        valores[0] = "-0";
                    }
                    else
                    {
                        valores[0] = "0";
                    }
                    result = String.Join(",", valores);
                }
                else
                {
                    result = valor;
                }
            }

            return result;
        }

        private void listView2_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.listView2.ItemCheck -= this.listView2_ItemCheck;
            List<ListViewItem> parcelas = new List<ListViewItem>();

            if (e.CurrentValue == CheckState.Unchecked)
            {
                listView2.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView2.Items.OfType<ListViewItem>().Where(item => item.Index <= e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);

            }
            else
            {
                listView2.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView2.Items.OfType<ListViewItem>().Where(item => item.Index < e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);
            }

            var parcelasVencidas = parcelas.Where(w => (String.IsNullOrEmpty(normalizeValue(w.SubItems[4].Text)) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) > 0).ToList();
            var parcelasVencer = parcelas.Where(w => (String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) <= 0).ToList();

            calculadora.valorParcelasVencidas = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.juros = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[4].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.IOF = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[5].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[5].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.GCA = String.IsNullOrEmpty(GCA) ? 0 : decimal.Parse(GCA.Trim().Replace(".", "").Replace(',', '.'), culture);

            calculadora.valorParcelasVencer = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[7].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[7].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.valorParcelasVencerSemDesconto = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));


            this.listView2.ItemCheck += this.listView2_ItemCheck;
            calcula();

        }

        private void listView3_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.listView3.ItemCheck -= this.listView3_ItemCheck;
            List<ListViewItem> parcelas = new List<ListViewItem>();

            if (e.CurrentValue == CheckState.Unchecked)
            {
                listView3.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView3.Items.OfType<ListViewItem>().Where(item => item.Index <= e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);

            }
            else
            {
                listView3.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView3.Items.OfType<ListViewItem>().Where(item => item.Index < e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);
            }

            var parcelasVencidas = parcelas.Where(w => (String.IsNullOrEmpty(normalizeValue(w.SubItems[4].Text)) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) > 0).ToList();
            var parcelasVencer = parcelas.Where(w => (String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) <= 0).ToList();

            calculadora.valorParcelasVencidas = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.juros = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[4].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.IOF = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[5].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[5].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.GCA = String.IsNullOrEmpty(GCA) ? 0 : decimal.Parse(GCA.Trim().Replace(".", "").Replace(',', '.'), culture);

            calculadora.valorParcelasVencer = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[7].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[7].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.valorParcelasVencerSemDesconto = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));

            this.listView3.ItemCheck += this.listView3_ItemCheck;
            calcula();

        }

        private void listView4_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.listView4.ItemCheck -= this.listView4_ItemCheck;
            List<ListViewItem> parcelas = new List<ListViewItem>();

            if (e.CurrentValue == CheckState.Unchecked)
            {
                listView4.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView4.Items.OfType<ListViewItem>().Where(item => item.Index <= e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);

            }
            else
            {
                listView4.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView4.Items.OfType<ListViewItem>().Where(item => item.Index < e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);
            }

            var parcelasVencidas = parcelas.Where(w => (String.IsNullOrEmpty(normalizeValue(w.SubItems[4].Text)) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) > 0).ToList();
            var parcelasVencer = parcelas.Where(w => (String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) <= 0).ToList();

            calculadora.valorParcelasVencidas = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.juros = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[4].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.IOF = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[5].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[5].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.GCA = String.IsNullOrEmpty(GCA) ? 0 : decimal.Parse(GCA.Trim().Replace(".", "").Replace(',', '.'), culture);

            calculadora.valorParcelasVencer = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[7].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[7].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.valorParcelasVencerSemDesconto = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));


            this.listView4.ItemCheck += this.listView4_ItemCheck;
            calcula();

        }

        private void listView5_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            this.listView5.ItemCheck -= this.listView5_ItemCheck;
            List<ListViewItem> parcelas = new List<ListViewItem>();

            if (e.CurrentValue == CheckState.Unchecked)
            {
                listView5.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView5.Items.OfType<ListViewItem>().Where(item => item.Index <= e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);

            }
            else
            {
                listView5.Items.OfType<ListViewItem>().Where(item => item.Index >= e.Index).ToList().ForEach(item => item.Checked = false);
                parcelas = listView5.Items.OfType<ListViewItem>().Where(item => item.Index < e.Index).ToList();
                parcelas.ForEach(item => item.Checked = true);
            }

            var parcelasVencidas = parcelas.Where(w => (String.IsNullOrEmpty(normalizeValue(w.SubItems[4].Text)) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) > 0).ToList();
            var parcelasVencer = parcelas.Where(w => (String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[4].Text), culture)) <= 0).ToList();

            calculadora.valorParcelasVencidas = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : Decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.juros = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[4].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[4].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.IOF = parcelasVencidas.Sum(w => String.IsNullOrEmpty(w.SubItems[5].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[5].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.GCA = String.IsNullOrEmpty(GCA) ? 0 : decimal.Parse(GCA.Trim().Replace(".", "").Replace(',', '.'), culture);

            calculadora.valorParcelasVencer = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[7].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[7].Text).Trim().Replace(".", "").Replace(',', '.'), culture));
            calculadora.valorParcelasVencerSemDesconto = parcelasVencer.Sum(w => String.IsNullOrEmpty(w.SubItems[3].Text) ? 0 : decimal.Parse(normalizeValue(w.SubItems[3].Text).Trim().Replace(".", "").Replace(',', '.'), culture));


            this.listView5.ItemCheck += this.listView5_ItemCheck;
            calcula();

        }
        private void populaHistoricoContatosAnt(String contrato)
        {
            //informacoes da tela
            var mainframe = new Santander.Automation.TN3270Lib.CICS(_user, _pass, _ip, _port);
           
            var data = mainframe.GetHistoricoContatosAnt(contrato);

            

            Color cor = Color.LightGray;
            foreach (String hist in data)
            {

                var item = new ListViewItem();
                item.SubItems.Add(hist);

                item.BackColor = cor;

                if (cor == Color.LightGray)
                {
                    cor = Color.White;
                }
                else
                {
                    cor = Color.LightGray;
                }

                lvHistContato.Items.Add(item);

            }

        }

        private void populaHistoricoPagamentos(String contrato)
        {
            //informacoes da tela
            var mainframe = new Santander.Automation.TN3270Lib.CICS(_user, _pass, _ip, _port);

            var data = mainframe.GetHistoricoPagamento(contrato);

            Color cor = Color.LightGray;
            foreach (LaminaHistPagamento hist in data)
            {
                var item = new ListViewItem();
                item.SubItems.Add(hist.prt);
                item.SubItems.Add(hist.dataMotivo);
                item.SubItems.Add(hist.dataOcorrencia);
                item.SubItems.Add(hist.situacao);
                item.SubItems.Add(hist.ageReceb);
                item.SubItems.Add(hist.vlOcorrencia);
                item.SubItems.Add(hist.vlPrestacao);

                item.BackColor = cor;

                if (cor == Color.LightGray)
                {
                    cor = Color.White;
                }
                else
                {
                    cor = Color.LightGray;
                }

                lvHistPagamentos.Items.Add(item);

            }

        }
        public void populaTabulacaoCTA(String contrato)
        {

            var tabaddmemo = ADDDEMO.Text;
            var tabret = "3";
            var action = Tabulacao.Text.Split('|');
            var tabaction = action[1];

            var mainframe = new Santander.Automation.TN3270Lib.CICS(_user, _pass, _ip, _port);

            var data = mainframe.GetTabulacaoCTA(contrato, tabaddmemo, tabret, tabaction);


        }

        public void insereHistoricoSiscob()
        {
            WebServiceSiscob.CallWebService(idContrato, Tabulacao.Text.Split('-')[0], ADDDEMO.Text);
        }

        public void populaTabulacaoCANC(String contrato)
        {


            var mainframe = new Santander.Automation.TN3270Lib.CICS(_user, _pass, _ip, _port);

            var data = mainframe.GetCanc(contrato);


        }

        private void calcula()
        {
            CalcVlparcela.Text = "R$ " + Math.Round(calculadora.valorParcelasVencidas, 2).ToString();
            CalcJuros.Text = "R$ " + Math.Round(calculadora.juros, 2).ToString();
            CalcIOF.Text = "R$ " + Math.Round(calculadora.IOF, 2).ToString();
            CalcGCA.Text = "R$ " + Math.Round(calculadora.GCA, 2).ToString();
            CalcJurosPagar.Text = Math.Round(calculadora.valorJurosPagar, 2).ToString();
            CalcDesconto.Text = NaNTo0(calculadora.pencentualDescontoConcedido.ToString()) + "%";
            CalcDescJuros.Text = "R$ " + Math.Round(calculadora.valorDescontoConcedidoJuros, 2).ToString();
            Comissao.Value = decimal.Parse(calculadora.percentualComissao.ToString());
            CalcComissao.Text = "R$ " + Math.Round(calculadora.valorComissao, 2).ToString();
            CalcVlTotal.Text = Math.Round(calculadora.valorTotalParcelasVencidas, 2).ToString();
            QuitVlparcela.Text = Math.Round(calculadora.valorParcelasVencer, 2).ToString();
            QuitDesconto.Text = Math.Round(calculadora.valorDescontoConcedidoQuitacao, 2).ToString();
            QuitVlQuit.Text = Math.Round(calculadora.valorQuitacao, 2).ToString();
            QuitVlTotal.Text = Math.Round(calculadora.valorTotal, 2).ToString();
            CalcHO.Text = "R$ " + Math.Round(calculadora.valorDescontoConcedidoHO, 2).ToString();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

        }

        private decimal NaNTo0(String str)
        {
            if (str.Equals("NaN (Não é um número)"))
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(str);
            }
        }

        private void CalcJurosPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                calculadora.valorJurosPagar = decimal.Parse(CalcJurosPagar.Text, culture);
                calcula();
            }
        }

        private void Comissao_ValueChanged(object sender, EventArgs e)
        {

            calculadora.percentualComissao = decimal.Parse(Comissao.Value.ToString().Replace(',', '.'), culture);
            calcula();
        }

        private void QuitPremio_TextChanged(object sender, EventArgs e)
        {
            calculadora.percentualComissao = decimal.Parse(Comissao.Value.ToString().Replace(',', '.'), culture);
            calcula();
        }

        private void CalcDesconto_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tabulacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TelaRegistro_Load(object sender, EventArgs e)
        {


        }

        private void Email_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ADDDEMO_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvHistContato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CalcComissao_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalcVlparcela_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            
        }

        private void BtnCanAcordo_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Tabulacao.Text) && String.IsNullOrEmpty(ADDDEMO.Text))
            {
                DialogResult result1 = MessageBox.Show(
                "Preencha todos os campos!!!",
                "Facilita"
                );
                return;
            }
			
			populaTabulacaoCTA(contrato);

            //insereHistoricoSiscob();
            Clipboard.SetText(ADDDEMO.Text);
            this.Close();

			
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TelaRegistro_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void NomeC_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            Qtdparc = listView1.CheckedItems.Count
              | listView2.CheckedItems.Count
              | listView3.CheckedItems.Count
              | listView4.CheckedItems.Count
              | listView5.CheckedItems.Count;

            
            if (Qtdparc > 0 && !String.IsNullOrEmpty(Tabulacao.Text) && !String.IsNullOrEmpty(ADDDEMO.Text) 
                && !String.IsNullOrEmpty(cmbMotivo.Text) && !String.IsNullOrEmpty(cmbMotivo.Text))
            {
                //    MessageBox.Show(
                //    "É necessário selecionar as parcelas para finalizar o acordo!!!",
                //    "Facilita",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Warning
                //    );

                //}
                //else
                //{





                //tabulacao CANC
                //populaTabulacaoCANC(contrato);

                //tabulação CTA - ok
                //populaTabulacaoCTA(contrato);


                DialogResult result1 = MessageBox.Show(
                    "Favor aguardar a finalização do processo automático!!!",
                    "Facilita",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );



                // obj form login
                Form1 FormFacilita = Application.OpenForms["Form1"] as Form1;
                FormFacilita.Focus();
                var CNPJ = FormFacilita.txtCNPJRCB.Text;
                var UserRCB = FormFacilita.txtUserRCB.Text;
                var PassRCB = FormFacilita.txtPassRCB.Text;
                //var txtUserCICS = FormFacilita.txtUserCICS.Text;


                try
                {

                    if (!LoginRCB(CNPJ, UserRCB, PassRCB, ContratoCli.Text, Qtdparc.ToString(), QuitVlTotal.Text, tabControl2.SelectedTab.Text, CalcComissao.Text))
                    {

                        this.Enabled = true;
                        return;
                    }
                    else
                    {


                        //tabulacao CANC
                        //populaTabulacaoCANC(contrato);
                        this.Enabled = true;
                        return;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    this.Enabled = true;
                    return;
                }
            }
            else
            {
                DialogResult result1 = MessageBox.Show(
                    "Preencha todos os campos e selecione as parcelas antes de continuar!!!",
                    "Facilita"
                    );

				
				
			
            }

            bool LoginRCB(string Cnpj, string UserRcb, string PassRcb, string Contrato, string QtdParcela, string ValorParc, string DataPagamento, string comissao, bool onlyLogin = false)
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

                try
                {
                    //erro usuario ou senha
                    wait5.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("_id70:_id95")));
                    IWebElement btok = driver.FindElement(By.Name("_id70:_id95"));
                    Thread.Sleep(200);
                    driver.Close();
                    Logger.LoginRCBError();

                    DialogResult result2 = MessageBox.Show("ERRO SENHA NÃO CONFERE.", "Facilita", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    //Thread.Sleep(500);
                    return false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    //inclusão acordo contrato valor e parcelas

                    var acordos = wait5.Until(ExpectedConditions.ElementExists(By.Id("mnu1:_id52")));
                    //IWebElement acordos = driver.FindElement(By.Id("mnu1:_id52"));
                    acordos.Click();

                    var inclusao = wait5.Until(ExpectedConditions.ElementExists(By.Id("mnu1:_id55")));
                    //IWebElement inclusao = driver.FindElement(By.Id("mnu1:_id55"));
                    inclusao.Click();
                    Thread.Sleep(200);

                    // pendente cta valores no mockup
                    var contrato = wait.Until(ExpectedConditions.ElementExists(By.Id("form:num_contrato")));
                    //driver.FindElement(By.Id("form:num_contrato")).SendKeys(Contrato);
                    contrato.SendKeys(Contrato);
                    Thread.Sleep(200);

                    var parcelas = wait.Until(ExpectedConditions.ElementExists(By.Id("form:qtd_parcelas_acordo")));
                    //driver.FindElement(By.Id("form:qtd_parcelas_acordo")).SendKeys(QtdParcela);
                    parcelas.SendKeys("1");
                    Thread.Sleep(200);

                    bool recalc = false;

                    do
                    {

                        recalc = false;

                        // pendente cta valores no mockup
                        var valor = wait.Until(ExpectedConditions.ElementExists(By.Name("form:valor_acordo")));
                        //driver.FindElement(By.Name("form:valor_acordo")).SendKeys(QuitVlTotal.Text);
                        valor.Clear();
                        valor.SendKeys(QuitVlTotal.Text);
                        Thread.Sleep(200);

                        var rdoAss = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:origem_acordo:_1")));
                        //IWebElement Rbtnass = driver.FindElement(By.Id("form:origem_acordo:_1"));
                        rdoAss.Click();
                        Thread.Sleep(200);

                        String tipoAcordo = cmbTipoAcordo.Text.Trim();

                        String idTipoAcordo = "form:tipo_acordo:_1";

                        if (tipoAcordo.Equals("Quitação"))
                        {
                            idTipoAcordo = "form:tipo_acordo:_1";
                        }
                        else if (tipoAcordo.Equals("Atualização"))
                        {
                            idTipoAcordo = "form:tipo_acordo:_2";
                        }
                        else if (tipoAcordo.Equals("Eventual"))
                        {
                            idTipoAcordo = "form:tipo_acordo:_3";
                        }

                        var rdoAtu = wait5.Until(ExpectedConditions.ElementExists(By.Id(idTipoAcordo)));
                        //IWebElement Rbtnatu = driver.FindElement(By.Id("form:tipo_acordo:_2"));
                        rdoAtu.Click();
                        Thread.Sleep(200);

                        var rdoOut = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:tipo_carteira:_3")));
                        //IWebElement Rbtnout = driver.FindElement(By.Id("form:tipo_carteira:_3"));
                        rdoOut.Click();
                        Thread.Sleep(200);

                        if (calculadora.pencentualDescontoConcedido == 0)
                        {
                            var rdoExcecao = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:ic_excecao:_2")));
                            //IWebElement Rbtnexcecao = driver.FindElement(By.Id("form:ic_excecao:_2"));
                            rdoExcecao.Click();
                            Thread.Sleep(200);
                        }
                        else
                        {
                            var rdoExcecao = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:ic_excecao:_1")));
                            //IWebElement Rbtnexcecao = driver.FindElement(By.Id("form:ic_excecao:_2"));
                            rdoExcecao.Click();
                            Thread.Sleep(200);
                        }

                        var btnContinuar = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:checkAuthBtn_Continuar")));
                        //IWebElement btncont = driver.FindElement(By.Id("form:checkAuthBtn_Continuar"));
                        btnContinuar.Click();

                        // contrato ajuizado sempre não

                        var rdoAjuizado = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id110:_2")));
                        //IWebElement Rbtnnao = driver.FindElement(By.Id("form:_id110:_2"));
                        rdoAjuizado.Click();
                        Thread.Sleep(200);

                        WebDriverExtensions.WaitForPageLoad(driver);

                        //Valida GCA

                        var txtGCA = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id131")));
                        var valorGCAWeb = decimal.Parse(txtGCA.Text);
                        txtgca = txtGCA.Text; //para formgcadivergente
                        if (calculadora.GCA != valorGCAWeb)
                        {
                            driver.Manage().Window.Minimize();
                            GCADivergente gca = new GCADivergente();
                            var autorizacao = gca.ShowDialog();
                            gca.BringToFront();

                            if (autorizacao == DialogResult.OK)
                            {
                                calculadora.GCA = valorGCAWeb;
                                calcula();

                                var btnVoltar = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id162")));
                                btnVoltar.Click();
                                Thread.Sleep(200);

                                recalc = true;
                            }

                        }

                    } while (recalc);

                    driver.Manage().Window.Maximize();
                    Thread.Sleep(200);

                    //data pagamento vencimento 
                    var txtDataPagamento = wait.Until(ExpectedConditions.ElementExists(By.Id("form:dataPagamento")));
                    txtDataPagamento.SendKeys(DataPagamento);
                    Thread.Sleep(200);

                    //qtd total parcelas 
                    for (int p = 0; p < Qtdparc; p++)
                    {
                        var chkParcela = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id139:" + p + ":_id141")));
                        //IWebElement Rbtnparcela = driver.FindElement(By.Id("form:_id139:0:_id141"));
                        chkParcela.Click();
                    }

                    Thread.Sleep(200);
                    var Rbtnnegociar = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:checkAuthBtn_Negociar")));
                    //IWebElement Rbtnnegociar = driver.FindElement(By.Id("form:checkAuthBtn_Negociar"));
                    Rbtnnegociar.Click();


                    // motivo 
                    Thread.Sleep(200);
                    wait.Until(ExpectedConditions.ElementExists(By.Id("form:numeroMotivo")));

                    String motivo = cmbMotivo.Text.Trim();
                     
                    driver.FindElement(By.Id("form:numeroMotivo")).SendKeys(motivo);

                    
                    // valor comissao
                    Thread.Sleep(200);
                    wait.Until(ExpectedConditions.ElementExists(By.Id("form:valorComissaoEscob")));
                    driver.FindElement(By.Id("form:valorComissaoEscob")).SendKeys(comissao);

                    //btn gravar acordo
                    Thread.Sleep(200);
                    var Rbtngravar = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:checkAuthBtn_Gravar")));
                    //IWebElement Rbtngravar = driver.FindElement(By.Id("form:checkAuthBtn_Gravar"));
                    Rbtngravar.Click();

                    Thread.Sleep(200);

                    IWebElement element = (IWebElement)
                    ((IJavaScriptExecutor)driver).ExecuteScript("javascript:window.scrollBy(0,document.body.scrollHeight-150)");

         
                    //btn confirmar acordo
                    Thread.Sleep(200);
                    var btnConf = wait5.Until(ExpectedConditions.ElementExists(By.Id("_id224:_id244")));
                    btnConf.Click();

                    //tabulação CTA - ok
                    populaTabulacaoCTA(Contrato);
                    //insereHistoricoSiscob();

                    String txtNumAcordo = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id154"))).Text;
                    String txtLinhaDigitalvel = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id157"))).Text;

                    if (!txtLinhaDigitalvel.Equals("00000000000000000000000000000000000000000000000"))
                    {

                        WebDriverExtensions.KillDriversAndBrowsers();

                        //driver.Manage().Window.Minimize();
                        LinhaDigitavel formAcord = new LinhaDigitavel();
                        formAcord.Barcode.Text = txtLinhaDigitalvel;
                        formAcord.ShowDialog();
                        formAcord.Activate();
						
                    }
                    else
                    {

                        //driver.Manage().Window.Minimize();
                        //AcordoRealizado acordRealizado = new AcordoRealizado();
                        //acordRealizado.Show();
                        //acordRealizado.Activate();

                        //driver.Manage().Window.Maximize();

                        //driver.ExecuteScript("var form=formOf(this);form['mnu1:_idcl'].value='mnu1:_id68';return iceSubmit(form,this,event);");

                        var lamina = wait5.Until(ExpectedConditions.ElementExists(By.Id("mnu1:_id66")));
                        //IWebElement acordos = driver.FindElement(By.Id("mnu1:_id52"));
                        lamina.Click();

                        var consulta = wait5.Until(ExpectedConditions.ElementExists(By.Id("mnu1:_id68")));
                        //IWebElement inclusao = driver.FindElement(By.Id("mnu1:_id55"));
                        consulta.Click();
                        Thread.Sleep(200);

                        //Insere num contrato no campo de busca
                        var txtNumContrato = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:num_contrato")));
                        txtNumContrato.Clear();
                        txtNumContrato.SendKeys(Contrato);

                        //Clica botão consultar
                        wait5.Until(ExpectedConditions.ElementExists(By.Id("form:checkAuthBtn_Consultar"))).Click();

                        WebDriverExtensions.WaitForPageLoad(driver);

                        var rows = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id136"))).FindElements(By.CssSelector("tr"));

                        foreach (var row in rows)
                        {
                            if (row.Text.Contains(txtNumAcordo))
                            {
                                var cols = row.FindElements(By.CssSelector("td"));
                                cols[0].Click();
                            }

                        }

                        IWebElement btnOk = null;

                        do
                        {
                            btnOk = null;

                            Thread.Sleep(3000);

                            wait5.Until(ExpectedConditions.ElementExists(By.Id("form:checkAuthBtn_ConsultaLamina"))).Click();

                            WebDriverExtensions.WaitForPageLoad(driver);

                           
                            try
                            {
                                btnOk = wait5.Until(ExpectedConditions.ElementExists(By.Id("_id170:_id195")));
                               
                            }
                            catch(Exception)
                            {
                              
                            }

                            if (btnOk != null)
                            {
                                btnOk.Click();
                            }

                        } while (btnOk != null);


                        //WebDriverExtensions.WaitForPageLoad(driver);

                      
                        String txtLinhaDigitalvel2 = wait5.Until(ExpectedConditions.ElementExists(By.Id("form:_id127"))).Text;

                        WebDriverExtensions.KillDriversAndBrowsers();

                        //driver.Manage().Window.Minimize();

                        LinhaDigitavel formAcord = new LinhaDigitavel();
                        formAcord.Barcode.Text = txtLinhaDigitalvel2;
                        formAcord.ShowDialog();
                        formAcord.Activate();

                    }

                    //driver.Manage().Window.Maximize();
                    

                    DialogResult dialogFinal = MessageBox.Show("Finalize o Atendimento no SISCOB", "Facilita", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (dialogFinal == DialogResult.OK)
                    {
                        //this.Dispose();
                    }

					//driver.Close();
					SiscobFocus();

					//Siscob.RetornarLigacao();


				}
                return true;
            }

        }

        public void SiscobFocus()
        {
            var app2 = TestStack.White.Application.Attach("cobdesk");

            try
            {

                var windows = app2.GetWindows();

                foreach (var wind in windows)
                {
                    if (wind.Name.Contains("cslog_rr_prod"))
                    {
                        wind.Focus();
                        wind.SetForeground();
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
    }

}

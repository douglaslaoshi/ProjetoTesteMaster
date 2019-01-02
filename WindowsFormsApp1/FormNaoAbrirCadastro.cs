using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormNaoAbrirCadastro : Form
    {
        public FormNaoAbrirCadastro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                String contrato = Siscob.Contrato.Trim();
                String msg = ADDDEMONoOpen.Text;
                String codTab = TabNotOpen.Text.Split('|')[1].Trim();
                Clipboard.SetText(msg);
                tabulaCTA(contrato, msg, codTab);
                this.Close();
				
		}

        private void tabulaCTA(String contrato,String msg,String codTab)
        {
            Form1 f1 = Application.OpenForms["Form1"] as Form1;

            var mainframe = new Santander.Automation.TN3270Lib.CICS(f1.txtUserCICS.Text, f1.txtPassCICS.Text, "TCPIP71.santanderbr.corp", 2023);
            var data = mainframe.GetTabulacaoCTA(contrato, msg, "3", codTab);

        }
    }
}

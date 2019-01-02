using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AcordoRealizado : Form
    {
        public AcordoRealizado()
        {
            InitializeComponent();
        }

        private void AcordoRealizado_Load(object sender, EventArgs e)
        {

        }

        private void Ok_Click(object sender, EventArgs e)
        {          
            
            AcordoRealizado a = Application.OpenForms["AcordoRealizado"] as AcordoRealizado;
            a.Close();
            //TelaRegistro t = Application.OpenForms["TelaRegistro"] as TelaRegistro;
            //t.Close();
           


		}

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

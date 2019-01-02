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
    public partial class GCADivergente : Form
    {
        public GCADivergente()
        {
           
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {


           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            if (UserBackoffice.Text.Equals("flexadm") && PassBackoffice.Text.Equals("flexadm"))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Senha ou usuário inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GCADivergente_Load(object sender, EventArgs e)
        {
            VlCta.Text = TelaRegistro.GCA.Trim();
            VlRcb.Text = TelaRegistro.txtgca.Trim();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           

        }

        private void VlCta_Click(object sender, EventArgs e)
        {
           


        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

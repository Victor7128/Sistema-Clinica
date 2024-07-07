using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace CapaPresentacion
{
    public partial class frmHistorial : Form
    {
        EntidadHospitalizacion objent = new EntidadHospitalizacion();
        NegocioHistorial objneg = new NegocioHistorial();

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void BuscarUsuario()
        {
            objent.DNI = Convert.ToInt32(txtDNI.Text);
            DataTable dt = objneg.N_BuscarHistorial(objent);
            dgvHistorial.DataSource = dt;
            dgvHistorial.Refresh();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            txtDNI.Text = "";
            dgvHistorial.DataSource = objneg.N_listarHistorial();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            BuscarUsuario();
            txtDNI.Text = "";
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvHistorial.DataSource = objneg.N_listarHistorial();
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuario();
                e.SuppressKeyPress = true;
                txtDNI.Text = "";
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            if (txtDNI.Text.Length > 8)
            {
                txtDNI.Text = txtDNI.Text.Substring(0, 8);
                txtDNI.SelectionStart = txtDNI.Text.Length;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmConsultas : Form
    {
        EntidadHospitalizacion objent = new EntidadHospitalizacion();
        NegocioHospitalizacion objneg = new NegocioHospitalizacion();

        public frmConsultas()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtNombreBuscar.Text = "";
            txtDniBuscar.Text = "";
            dgvBuscador.DataSource = objneg.N_listar_pacientes_consulta();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Limpiar();
            dgvBuscador.DataSource = objneg.N_listar_pacientes_consulta();
        }

        private void txtNombreBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuarioNOMBRE();
                e.SuppressKeyPress = true;
                txtNombreBuscar.Text = "";
            }
        }

        private void btnListarPacientes_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtDniBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuarioDNI();
                e.SuppressKeyPress = true;
                txtDniBuscar.Text = "";
            }
        }

        private void BuscarUsuarioDNI()
        {
            objent.DNI = Convert.ToInt32(txtDniBuscar.Text);
            DataTable dt = objneg.N_buscar_pacientes(objent);
            dgvBuscador.DataSource = dt;
            dgvBuscador.Refresh();
        }

        private void BuscarUsuarioNOMBRE()
        {
            objent.Nombre = txtNombreBuscar.Text;
            DataTable dt = objneg.N_buscar_pacientes(objent);
            dgvBuscador.DataSource = dt;
            dgvBuscador.Refresh();
        }
    }
}

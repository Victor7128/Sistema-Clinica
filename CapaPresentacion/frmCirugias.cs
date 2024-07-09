using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;
using DocumentFormat.OpenXml.Wordprocessing;

namespace CapaPresentacion
{
    public partial class frmCirugias : Form
    {
        EntidadCirugia objent = new EntidadCirugia();
        EntidadHospitalizacion objenti = new EntidadHospitalizacion();
        NegocioCirugia objneg = new NegocioCirugia();


        public frmCirugias()
        {
            InitializeComponent();
        }

        private void frmCirugias_Load(object sender, EventArgs e)
        {
            CargarMedico();
            CargarSalas();
            ListarCirugias();
            listarPacientes();
            limpiar();

            dgvPacientes.Columns["Paciente"].Width = 200;
        }

        void limpiar()
        {
            cboSala.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now.Date;
            txtHora.Text = "";
            txtBuscar.Text = "";
            txtPaciente.Text = "";
            dgvCirugias.DataSource = objneg.N_listarCirugias();
        }

        void CargarMedico()
        {
            cboMedico.DataSource = objneg.N_buscarMedico();
            cboMedico.DisplayMember = "Nombres";
            cboMedico.ValueMember = "IdUsuario";
        }

        void CargarSalas()
        {
            cboSala.DataSource = objneg.N_listarSala();
            cboSala.DisplayMember = "Nombre";
            cboSala.ValueMember = "IdSala";
        }

        void ListarCirugias()
        {
            dgvCirugias.DataSource = objneg.N_listarCirugias();
        }

        void listarPacientes()
        {
            dgvPacientes.DataSource = objneg.N_listarNombrePacientes();
        }

        void buscarPaciente()
        {
            objenti.Nombre = txtBuscar.Text;
            DataTable dt = objneg.N_buscarPacientesNombre(objenti);
            dgvPacientes.DataSource = dt;
            dgvPacientes.Refresh();            
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            buscarPaciente();
            txtBuscar.Text = "";
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarPaciente();
                e.SuppressKeyPress = true;
                txtBuscar.Text = "";
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvCirugias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCirugias.Rows[e.RowIndex];

                string paciente = fila.Cells["NombrePaciente"].Value?.ToString() ?? string.Empty;
                string medicoAsignado = fila.Cells["MedicoAsignado"].Value?.ToString() ?? string.Empty;
                string descripcionCirugia = fila.Cells["DescripcionCirugia"].Value?.ToString() ?? string.Empty;
                string sala = fila.Cells["Sala"].Value?.ToString() ?? string.Empty;
                DateTime fechaCirugia;
                if (DateTime.TryParse(fila.Cells["FechaCirugia"].Value?.ToString(), out fechaCirugia))
                {
                    dtpFecha.Value = fechaCirugia;
                }
                else
                {
                    dtpFecha.Value = DateTime.Today;
                }
                string horaCirugia = fila.Cells["HoraCirugia"].Value?.ToString() ?? string.Empty;

                txtPaciente.Text = paciente;
                cboMedico.Text = medicoAsignado;
                rtxDescripcion.Text = descripcionCirugia;
                cboSala.Text = sala;
                txtHora.Text = horaCirugia;
            }
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

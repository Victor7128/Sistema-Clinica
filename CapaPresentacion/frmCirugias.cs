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
            dgvPacientes.Columns["IdPaciente"].Visible = false;
            dgvCirugias.Columns["IdPaciente"].Visible = false;
        }

        void crud(string accion)
        {
            try
            {
                objent.IdUsuario = Convert.ToInt32(cboMedico.SelectedValue);
                objent.IdSala = Convert.ToInt32(cboSala.SelectedValue);
                objent.FechaCirugia = dtpFecha.Value.Date;

                if (TimeSpan.TryParse(txtHora.Text, out TimeSpan horaCirugia))
                {
                    objent.HoraCirugia = horaCirugia;
                }
                else
                {
                    MessageBox.Show("Formato de hora inválido. Use HH:mm", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtPaciente.Tag != null)
                {
                    objent.IdPaciente = Convert.ToInt32(txtPaciente.Tag);
                }
                else
                {
                    MessageBox.Show("Seleccione un paciente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                objent.Descripcion = rtxDescripcion.Text;
                objent.accion = accion;

                string mensaje = objneg.N_mantenedorCirugias(objent);
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void limpiar()
        {
            cboMedico.SelectedIndex = -1;
            cboSala.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now.Date;
            txtHora.Text = "";
            txtBuscar.Text = "";
            txtPaciente.Text = "";
            rtxDescripcion.Text = "";
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

        private void dgvCirugias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvCirugias.Columns[e.ColumnIndex];
                if (column.Name == "HoraCirugia" || column.Name == "HoraEntradaSala" || column.Name == "HoraSalidaSala")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (TimeSpan.TryParse(e.Value.ToString(), out TimeSpan hora))
                        {
                            e.Value = hora.ToString(@"hh\:mm");
                            e.FormattingApplied = true;
                        }
                    }
                }
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvPacientes.Columns[e.ColumnIndex].Name == "Paciente")
            {
                DataGridViewRow fila = dgvPacientes.Rows[e.RowIndex];

                string paciente = fila.Cells["Paciente"].Value?.ToString() ?? string.Empty;
                int idPaciente = Convert.ToInt32(fila.Cells["IdPaciente"].Value);

                txtPaciente.Text = paciente;
                txtPaciente.Tag = idPaciente;
            }
        }

        private void dgvCirugias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvCirugias.Rows[e.RowIndex];

                int idPaciente = Convert.ToInt32(fila.Cells["IdPaciente"].Value);
                string paciente = fila.Cells["Paciente"].Value?.ToString() ?? string.Empty;
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

                TimeSpan horaCirugia;
                if (TimeSpan.TryParse(fila.Cells["HoraCirugia"].Value?.ToString(), out horaCirugia))
                {
                    txtHora.Text = horaCirugia.ToString(@"hh\:mm");
                }
                else
                {
                    txtHora.Text = string.Empty;
                }

                txtPaciente.Text = paciente;
                txtPaciente.Tag = idPaciente;
                cboMedico.Text = medicoAsignado;
                rtxDescripcion.Text = descripcionCirugia;
                cboSala.Text = sala;
            }
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crud("1");
            limpiar();
            dgvPacientes.DataSource = objneg.N_listarNombrePacientes();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crud("2");
            limpiar();
            dgvPacientes.DataSource = objneg.N_listarNombrePacientes();
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crud("3");
            limpiar();
            dgvPacientes.DataSource = objneg.N_listarNombrePacientes();
        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crud("4");
            limpiar();
            dgvPacientes.DataSource = objneg.N_listarNombrePacientes();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crud("5");
            limpiar();
            dgvPacientes.DataSource = objneg.N_listarNombrePacientes();
        }        
    }
}

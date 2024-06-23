using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDatos;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmHospitalizacion : Form
    {
        public frmHospitalizacion()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombrePaciente.Text))
                {
                    MessageBox.Show("Ingrese el nombre del paciente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(txtDniPaciente.Text, out int dniPaciente))
                {
                    MessageBox.Show("El DNI debe ser un número entero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(cboEstadia.SelectedValue.ToString(), out int idEstadia))
                {
                    MessageBox.Show("Seleccione una estadía válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(cboTipoHabitacion.SelectedValue.ToString(), out int idTipoHabitacion))
                {
                    MessageBox.Show("Seleccione un tipo de habitación válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(cboHabitacion.SelectedValue.ToString(), out int idHabitacion))
                {
                    MessageBox.Show("Seleccione una habitación válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int? idCamilla = null;
                if (cboCamilla.SelectedValue != null && int.TryParse(cboCamilla.SelectedValue.ToString(), out int camillaValue))
                {
                    idCamilla = camillaValue;
                }
                int idHospitalizacion = CD_Hospitalizacion.RegistrarHospitalizacion(txtNombrePaciente.Text, dniPaciente, idEstadia, idTipoHabitacion, idHabitacion, idCamilla);
                MessageBox.Show($"Hospitalización registrada con éxito. ID: {idHospitalizacion}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarPacientesHospitalizados();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la hospitalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            
        }

        private void CargarComboboxes()
        {
            try
            {
                cboEstadia.DataSource = CD_Hospitalizacion.ObtenerEstadias();
                cboEstadia.DisplayMember = "Nombre";
                cboEstadia.ValueMember = "IdEstadia";

                cboHabitacion.DataSource = CD_Hospitalizacion.ObtenerHabitaciones();
                cboHabitacion.DisplayMember = "Nombre";
                cboHabitacion.ValueMember = "IdHabitacion";

                cboTipoHabitacion.DataSource = CD_Hospitalizacion.ObtenerTipoHabitacion();
                cboTipoHabitacion.DisplayMember = "Nombre";
                cboTipoHabitacion.ValueMember = "IdTipoHabitacion";

                cboCamilla.DataSource = CD_Hospitalizacion.ObtenerCamillas();
                cboCamilla.DisplayMember = "Nombre";
                cboCamilla.ValueMember = "IdCamilla";

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPacientesHospitalizados()
        {
            try
            {
                DataTable dtPacientes = CD_Hospitalizacion.ObtenerPacientesHospitalizados();
                dgvPacientes.DataSource = dtPacientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar pacientes hospitalizados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtNombrePaciente.Clear();
            txtDniPaciente.Clear();
            cboEstadia.SelectedIndex = -1;
            cboHabitacion.SelectedIndex = -1;
            cboTipoHabitacion.SelectedIndex = -1;
            cboCamilla.SelectedIndex = -1;
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {
            CargarPacientesHospitalizados();
            CargarComboboxes();
            timer1.Enabled = true;
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPacientes.Rows[e.RowIndex];

                // Mostrar datos del paciente seleccionado en los controles del formulario
                txtNombrePaciente.Text = row.Cells["NombrePaciente"].Value.ToString();
                txtDniPaciente.Text = row.Cells["DNIPaciente"].Value.ToString();

                // Seleccionar los valores correspondientes en los ComboBoxes
                cboEstadia.SelectedValue = (int)row.Cells["IdEstadia"].Value;
                cboTipoHabitacion.SelectedValue = (int)row.Cells["IdTipoHabitacion"].Value;
                cboHabitacion.SelectedValue = (int)row.Cells["IdHabitacion"].Value;

                // Verificar si hay camilla seleccionada
                if (row.Cells["IdCamilla"].Value != DBNull.Value)
                {
                    cboCamilla.SelectedValue = (int)row.Cells["IdCamilla"].Value;
                }
                else
                {
                    cboCamilla.SelectedIndex = -1;
                }
            }
        }
    }
}

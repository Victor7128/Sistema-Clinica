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
                dgvPacientes.DataSource = null;
                dgvPacientes.Rows.Clear();
                dgvPacientes.Columns.Clear();
                dgvPacientes.DataSource = dtPacientes;
                dgvPacientes.Columns["Nombre_Paciente"].HeaderText = "Nombre_Paciente";
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

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPacientes.Rows[e.RowIndex];

                // Mostrar datos en los TextBox
                txtNombrePaciente.Text = row.Cells["Nombre_Paciente"].Value.ToString();
                txtDniPaciente.Text = row.Cells["Dni_Paciente"].Value.ToString();

                // Seleccionar la estadía correspondiente en el ComboBox cboEstadia
                string estadia = row.Cells["Estadia"].Value.ToString();
                cboEstadia.SelectedItem = cboEstadia.Items.Cast<DataRowView>().FirstOrDefault(item => item["Nombre"].ToString() == estadia);

                // Seleccionar la camilla correspondiente en el ComboBox cboCamilla
                string camilla = row.Cells["Camilla"].Value.ToString();
                cboCamilla.SelectedItem = cboCamilla.Items.Cast<DataRowView>().FirstOrDefault(item => item["Nombre"].ToString() == camilla);

                // Seleccionar el tipo de habitación correspondiente en el ComboBox cboTipoHabitacion
                string tipoHabitacion = row.Cells["Tipo_Habitacion"].Value.ToString();
                cboTipoHabitacion.SelectedItem = cboTipoHabitacion.Items.Cast<DataRowView>().FirstOrDefault(item => item["Nombre"].ToString() == tipoHabitacion);

                // Seleccionar la habitación correspondiente en el ComboBox cboHabitacion
                string habitacion = row.Cells["Habitacion"].Value.ToString();
                cboHabitacion.SelectedItem = cboHabitacion.Items.Cast<DataRowView>().FirstOrDefault(item => item["Nombre"].ToString() == habitacion);
            }
        }

    }
}

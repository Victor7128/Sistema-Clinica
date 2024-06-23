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
            ConfigurarDataGridViewHospitalizacion();
            CargarHospitalizaciones();
            CargarComboboxes();
            timer1.Enabled = true;  // Iniciar el timer al cargar el formulario
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (dgvHospitalizacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una hospitalización para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow row = dgvHospitalizacion.SelectedRows[0];
            int idHospitalizacion = Convert.ToInt32(row.Cells["IdHospitalizacion"].Value);
            string nombre = txtNombrePacienteH.Text.Trim();
            string dni = txtDNI.Text.Trim();
            int idEstadia = ObtenerIdSeleccionado(cboEstadia);
            int idHabitacion = ObtenerIdSeleccionado(cboHabitacion);
            int idCamilla = ObtenerIdSeleccionado(cboCamilla);
            int idMedico = ObtenerIdSeleccionado(cboMedico);

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(dni) || idEstadia == 0 || idHabitacion == 0 || idCamilla == 0 || idMedico == 0)
            {
                MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool resultado = CD_Hospitalizacion.ActualizarHospitalizacion(idHospitalizacion, nombre, dni, idEstadia, idHabitacion, idCamilla, idMedico);
                if (resultado)
                {
                    MessageBox.Show("Hospitalización actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarHospitalizaciones();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la hospitalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar hospitalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (dgvHospitalizacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una hospitalización para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idHospitalizacion = Convert.ToInt32(dgvHospitalizacion.SelectedRows[0].Cells["IdHospitalizacion"].Value);

            try
            {
                bool resultado = CD_Hospitalizacion.EliminarHospitalizacion(idHospitalizacion);
                if (resultado)
                {
                    MessageBox.Show("Hospitalización eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarHospitalizaciones();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la hospitalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar hospitalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePacienteH.Text.Trim();
            string dni = txtDNI.Text.Trim();
            int idEstadia = ObtenerIdSeleccionado(cboEstadia);
            int idHabitacion = ObtenerIdSeleccionado(cboHabitacion);
            int idCamilla = ObtenerIdSeleccionado(cboCamilla);
            int idMedico = ObtenerIdSeleccionado(cboMedico);

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(dni) || idEstadia == 0 || idHabitacion == 0 || idCamilla == 0 || idMedico == 0)
            {
                MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int idHospitalizacionGenerado = CD_Hospitalizacion.RegistrarHospitalizacion(nombre, dni, idEstadia, idHabitacion, idCamilla, idMedico);
                if (idHospitalizacionGenerado > 0)
                {
                    MessageBox.Show("Hospitalización agregada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarHospitalizaciones();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la hospitalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar hospitalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvHospitalizacion_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHospitalizacion.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvHospitalizacion.SelectedRows[0];
                txtNombrePacienteH.Text = row.Cells["Nombre"].Value.ToString();
                txtDNI.Text = row.Cells["DNI"].Value.ToString();
                cboEstadia.SelectedValue = row.Cells["IdEstadia"].Value;
                cboHabitacion.SelectedValue = row.Cells["IdHabitacion"].Value;
                cboCamilla.SelectedValue = row.Cells["IdCamilla"].Value;
                cboMedico.SelectedValue = row.Cells["IdMedico"].Value;
            }
        }

        private void CargarComboboxes()
        {
            try
            {
                // Cargar ComboBox de Estadias con días del 1 al 30
                DataTable dtEstadias = new DataTable();
                dtEstadias.Columns.Add("IdEstadia", typeof(int));
                dtEstadias.Columns.Add("Nombre", typeof(int));

                for (int i = 1; i <= 30; i++)
                {
                    dtEstadias.Rows.Add(i, i);
                }

                cboEstadia.DisplayMember = "Nombre";
                cboEstadia.ValueMember = "IdEstadia";
                cboEstadia.DataSource = dtEstadias;

                // Resto de la carga de ComboBoxes
                cboHabitacion.DataSource = CD_Hospitalizacion.ObtenerHabitaciones();
                cboHabitacion.DisplayMember = "Nombre";
                cboHabitacion.ValueMember = "IdHabitacion";

                cboCamilla.DataSource = CD_Hospitalizacion.ObtenerCamillas();
                cboCamilla.DisplayMember = "Nombre";
                cboCamilla.ValueMember = "IdCamilla";

                cboMedico.DataSource = CD_Hospitalizacion.ObtenerMedicos();
                cboMedico.DisplayMember = "Nombres";
                cboMedico.ValueMember = "IdUsuario";

                LimpiarComboboxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarComboboxes()
        {
            cboEstadia.SelectedIndex = -1;
            cboHabitacion.SelectedIndex = -1;
            cboCamilla.SelectedIndex = -1;
            cboMedico.SelectedIndex = -1;
        }

        private int ObtenerIdSeleccionado(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is DataRowView drv)
            {
                return Convert.ToInt32(drv[comboBox.ValueMember]);
            }
            return 0;
        }

        private void LimpiarCampos()
        {
            txtNombrePacienteH.Clear();
            txtDNI.Clear();
            LimpiarComboboxes();
        }

        private void CargarHospitalizaciones()
        {
            try
            {
                dgvHospitalizacion.DataSource = CD_Hospitalizacion.ObtenerHospitalizaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar hospitalizaciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridViewHospitalizacion()
        {
            dgvHospitalizacion.AutoGenerateColumns = false;
            dgvHospitalizacion.Columns.Clear();

            dgvHospitalizacion.Columns.AddRange(
                new DataGridViewTextBoxColumn { DataPropertyName = "IdHospitalizacion", HeaderText = "IdHospitalizacion", Name = "IdHospitalizacion", Width = 50, ReadOnly = true },
                new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre", Name = "Nombre", Width = 200, ReadOnly = true },
                new DataGridViewTextBoxColumn { DataPropertyName = "DNI", HeaderText = "DNI", Name = "DNI", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { DataPropertyName = "Estadia", HeaderText = "Estadia", Name = "Estadia", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { DataPropertyName = "Habitacion", HeaderText = "Habitacion", Name = "Habitacion", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { DataPropertyName = "Camilla", HeaderText = "Camilla", Name = "Camilla", Width = 100, ReadOnly = true },
                new DataGridViewTextBoxColumn { DataPropertyName = "Medico", HeaderText = "Medico", Name = "Medico", Width = 200, ReadOnly = true }
            );

            dgvHospitalizacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHospitalizacion.MultiSelect = false;
            dgvHospitalizacion.ReadOnly = true;

            dgvHospitalizacion.SelectionChanged += dgvHospitalizacion_SelectionChanged;
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {

        }
    }
}

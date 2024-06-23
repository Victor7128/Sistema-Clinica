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
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            //int idPaciente = 1; // Se necesita obtener el IdPaciente desde la base de datos basado en el DNI
            //int idEstadia = ObtenerIdSeleccionado(cboEstadia);
            //int idHabitacion = ObtenerIdSeleccionado(cboHabitacion);
            //int idCamilla = ObtenerIdSeleccionado(cboCamilla);
            //int idMedico = ObtenerIdSeleccionado(cboMedico);

            //if (idEstadia == 0 || idHabitacion == 0 || idCamilla == 0 || idMedico == 0)
            //{
            //    MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //DateTime fechaIngreso = DateTime.Now.Date;
            //TimeSpan horaIngreso = DateTime.Now.TimeOfDay;

            //try
            //{
            //    int idHospitalizacionGenerado = CD_Hospitalizacion.RegistrarHospitalizacion(idPaciente, idEstadia, idHabitacion, idCamilla, idMedico, fechaIngreso, horaIngreso);
            //    if (idHospitalizacionGenerado > 0)
            //    {
            //        MessageBox.Show("Hospitalización agregada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        LimpiarCampos();
            //        CargarHospitalizaciones();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo agregar la hospitalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al agregar hospitalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            //if (dgvHospitalizacion.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("Seleccione una hospitalización para actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //DataGridViewRow row = dgvHospitalizacion.SelectedRows[0];
            //int idHospitalizacion = Convert.ToInt32(row.Cells["IdHospitalizacion"].Value);
            //int idEstadia = ObtenerIdSeleccionado(cboEstadia);
            //int idHabitacion = ObtenerIdSeleccionado(cboHabitacion);
            //int idCamilla = ObtenerIdSeleccionado(cboCamilla);
            //int idMedico = ObtenerIdSeleccionado(cboMedico);

            //if (idEstadia == 0 || idHabitacion == 0 || idCamilla == 0 || idMedico == 0)
            //{
            //    MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //try
            //{
            //    bool resultado = CD_Hospitalizacion.ActualizarHospitalizacion(idHospitalizacion, null, null);
            //    if (resultado)
            //    {
            //        MessageBox.Show("Hospitalización actualizada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        LimpiarCampos();
            //        CargarHospitalizaciones();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo actualizar la hospitalización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al actualizar hospitalización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            //if (dgvHospitalizacion.SelectedRows.Count == 0)
            //{
            //    MessageBox.Show("Seleccione una hospitalización para registrar salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //DataGridViewRow row = dgvHospitalizacion.SelectedRows[0];
            //int idHospitalizacion = Convert.ToInt32(row.Cells["IdHospitalizacion"].Value);

            //DateTime fechaSalida = DateTime.Now.Date;
            //TimeSpan horaSalida = DateTime.Now.TimeOfDay;

            //try
            //{
            //    bool resultado = CD_Hospitalizacion.ActualizarHospitalizacion(idHospitalizacion, fechaSalida, horaSalida);
            //    if (resultado)
            //    {
            //        MessageBox.Show("Salida registrada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        LimpiarCampos();
            //        CargarHospitalizaciones();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo registrar la salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al registrar salida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dgvHospitalizacion_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvHospitalizacion.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow row = dgvHospitalizacion.SelectedRows[0];
            //    cboEstadia.SelectedValue = row.Cells["IdEstadia"].Value;
            //    cboHabitacion.SelectedValue = row.Cells["IdHabitacion"].Value;
            //    cboCamilla.SelectedValue = row.Cells["IdCamilla"].Value;
            //    cboMedico.SelectedValue = row.Cells["IdMedico"].Value;
            //}
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
            dgvHospitalizacion.DataSource = CD_Hospitalizacion.ObtenerHospitalizaciones();
        }

        private void ConfigurarDataGridViewHospitalizacion()
        {
            dgvHospitalizacion.AutoGenerateColumns = false;
            dgvHospitalizacion.Columns.Clear();

            DataGridViewTextBoxColumn colIdHospitalizacion = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdHospitalizacion",
                HeaderText = "ID",
                Name = "IdHospitalizacion",
                Width = 50,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nombre",
                HeaderText = "Nombre",
                Name = "Nombre",
                Width = 200,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colDNI = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DNI",
                HeaderText = "DNI",
                Name = "DNI",
                Width = 100,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colFechaIngreso = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaIngreso",
                HeaderText = "Fecha de Ingreso",
                Name = "FechaIngreso",
                Width = 100,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colHoraIngreso = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoraIngreso",
                HeaderText = "Hora de Ingreso",
                Name = "HoraIngreso",
                Width = 100,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colFechaSalida = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaSalida",
                HeaderText = "Fecha de Salida",
                Name = "FechaSalida",
                Width = 100,
                ReadOnly = true
            };

            DataGridViewTextBoxColumn colHoraSalida = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HoraSalida",
                HeaderText = "Hora de Salida",
                Name = "HoraSalida",
                Width = 100,
                ReadOnly = true
            };

            dgvHospitalizacion.Columns.AddRange(new DataGridViewColumn[]
            {
        colIdHospitalizacion, colNombre, colDNI, colFechaIngreso, colHoraIngreso, colFechaSalida, colHoraSalida
            });
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {
            dgvHospitalizacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHospitalizacion.MultiSelect = false;
        }
    }
}

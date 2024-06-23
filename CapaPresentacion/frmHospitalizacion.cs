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

            // Recopilar los datos del formulario
            string nombrePaciente = txtNombrePaciente.Text;

            // Validar y convertir el DNI
            if (!int.TryParse(txtDniPaciente.Text, out int dniPaciente))
            {
                MessageBox.Show("El DNI debe ser un número entero.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener los valores seleccionados de los ComboBox
            if (!int.TryParse(cboEstadia.SelectedValue.ToString(), out int idEstadia))
            {
                MessageBox.Show("Seleccione una estadía válida.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Obtener el ID del médico seleccionado
            if (cboMedico.SelectedValue == null || !int.TryParse(cboMedico.SelectedValue.ToString(), out int idUsuarioMedico))
            {
                MessageBox.Show("Seleccione un médico válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registrar la hospitalización con los datos recopilados
            int idHospitalizacion = CD_Hospitalizacion.RegistrarHospitalizacion(nombrePaciente, dniPaciente, idEstadia, idHabitacion, idCamilla, idUsuarioMedico);

            // Mostrar mensaje de éxito
            MessageBox.Show("Hospitalización registrada con éxito. ID: " + idHospitalizacion, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar campos después del registro
            LimpiarCampos();
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    // Mostrar mensaje de error
            //    MessageBox.Show("Error al registrar la hospitalización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

                cboMedico.DataSource = CD_Hospitalizacion.ObtenerMedicos();
                cboMedico.DisplayMember = "Nombres"; // Nombre de la columna que quieres mostrar (por ejemplo, Nombres)
                cboMedico.ValueMember = "IdUsuario";

                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cboMedico.SelectedIndex = -1;
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {

        }
    }
}

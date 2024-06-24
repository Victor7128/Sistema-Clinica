using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmHospitalizacion : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();

        public frmHospitalizacion()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        void mantenedor(String accion)
        {
            // Asignación de valores desde controles al objeto entidad
            objent.Codigo = txtCodigo.Text;
            objent.Nombre = txtNombre.Text;
            objent.DNI = Convert.ToInt32(txtDni.Text);
            objent.IdEstadia = Convert.ToInt32(cboEstadia.SelectedValue); // Corregido: usar SelectedValue para obtener el valor seleccionado del ComboBox
            objent.IdCamilla = Convert.ToInt32(cboCamilla.SelectedValue); // Corregido: usar SelectedValue para obtener el valor seleccionado del ComboBox
            objent.IdHabitacion = Convert.ToInt32(cboHabitacion.SelectedValue); // Corregido: usar SelectedValue para obtener el valor seleccionado del ComboBox
            objent.IdTipoHabitacion = Convert.ToInt32(cboTipoHabitacion.SelectedValue); // Corregido: usar SelectedValue para obtener el valor seleccionado del ComboBox
            objent.FechaIngreso = DateTime.Now.Date; // Ejemplo: fecha actual
            objent.HoraIngreso = DateTime.Now.TimeOfDay; // Ejemplo: hora actual
            objent.accion = accion;

            // Llamar al método de negocio para el mantenimiento de pacientes
            string mensaje = objneg.N_mantenedor_paciente(objent);

            // Mostrar mensaje de resultado
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Limpiar()
        {
            txtNombre.Text = "";
            txtDni.Text = "";
            cboEstadia.SelectedIndex = -1;
            cboHabitacion.SelectedIndex = -1;
            cboTipoHabitacion.SelectedIndex = -1;
            cboCamilla.SelectedIndex = -1;
            dgvPacientes.DataSource = objneg.N_listar_pacientes();
        }

        void CargarComboboxes()
        {
            try
            {
                cboEstadia.DataSource = objneg.N_listar_estadias();
                cboEstadia.DisplayMember = "Nombre";
                cboEstadia.ValueMember = "IdEstadia";

                cboHabitacion.DataSource = objneg.N_listar_habitaciones();
                cboHabitacion.DisplayMember = "Nombre";
                cboHabitacion.ValueMember = "IdHabitacion";

                cboTipoHabitacion.DataSource = objneg.N_listar_tipo_habitacion();
                cboTipoHabitacion.DisplayMember = "Nombre";
                cboTipoHabitacion.ValueMember = "IdTipoHabitacion";

                cboCamilla.DataSource = objneg.N_listar_camillas();
                cboCamilla.DisplayMember = "Nombre";
                cboCamilla.ValueMember = "IdCamilla";

                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar combos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {
            CargarComboboxes();
            timer1.Enabled = true;
            dgvPacientes.DataSource = objneg.N_listar_pacientes();
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dgvPacientes.CurrentCell.RowIndex;
            txtCodigo.Text = dgvPacientes[0, fila].Value.ToString();
            txtNombre.Text = dgvPacientes[1, fila].Value.ToString();
            txtDni.Text = dgvPacientes[2,fila].Value.ToString();
            cboEstadia.SelectedItem = dgvPacientes[3, fila].Value.ToString();
            cboCamilla.SelectedItem = dgvPacientes[4,fila].Value.ToString();            
            cboHabitacion.SelectedItem = dgvPacientes[5,fila].Value.ToString();
            cboTipoHabitacion.SelectedItem = dgvPacientes[6, fila].Value.ToString();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                objent.Nombre = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_pacientes(objent);
                dgvPacientes.DataSource = dt;
            }
            else
            {
                dgvPacientes.DataSource = objneg.N_listar_pacientes();
            }
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text == "")
            {
                if(MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?","Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("1");
                    Limpiar();
                }
            }            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("2");
                    Limpiar();
                }
            }
        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas registrar salida a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("3");
                    Limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("");
                    Limpiar();
                }
            }
        }
    }
}

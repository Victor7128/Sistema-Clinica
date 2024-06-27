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

namespace CapaPresentacion
{
    public partial class frmHospitalizacion : Form
    {
        EntidadHospitalizacion objent = new EntidadHospitalizacion();
        NegocioHospitalizacion objneg = new NegocioHospitalizacion();

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
            objent.Codigo = txtCodigo.Text;
            objent.Nombre = txtNombre.Text;
            objent.DNI = Convert.ToInt32(txtDni.Text);
            objent.FechaNacimiento = dtpFechaNacimiento.Value.Date;
            objent.Telefono = Convert.ToInt32(txtCelular.Text);
            objent.Direccion = txtDireccion.Text;
            objent.IdGenero = Convert.ToInt32(cboGenero.SelectedValue);
            objent.IdEstadia = Convert.ToInt32(cboEstadia.SelectedValue);
            objent.IdCamilla = Convert.ToInt32(cboCamilla.SelectedValue);
            objent.IdHabitacion = Convert.ToInt32(cboHabitacion.SelectedValue);
            objent.IdTipoHabitacion = Convert.ToInt32(cboTipoHabitacion.SelectedValue);
            objent.FechaIngreso = DateTime.Now.Date;
            objent.HoraIngreso = DateTime.Now.TimeOfDay;
            objent.accion = accion;
            string men = objneg.N_mantenedor_paciente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            txtDireccion.Text = "";
            txtCelular.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now.Date;
            cboGenero.SelectedIndex = -1;
            cboEstadia.SelectedIndex = -1;
            cboHabitacion.SelectedIndex = -1;
            cboTipoHabitacion.SelectedIndex = -1;
            cboCamilla.SelectedIndex = -1;
            dgvPacientes.DataSource = objneg.N_listar_pacientes();
        }

        void CargarComboboxes()
        {
            //Cargar datos en cboGenero
            cboGenero.DataSource = objneg.N_listar_genero();
            cboGenero.DisplayMember = "Nombre";
            cboGenero.ValueMember = "IdGenero";

            // Cargar datos en cboEstadia
            cboEstadia.DataSource = objneg.N_listar_estadias();
            cboEstadia.DisplayMember = "Nombre";
            cboEstadia.ValueMember = "IdEstadia";

            // Cargar datos en cboHabitacion
            cboHabitacion.DataSource = objneg.N_listar_habitaciones();
            cboHabitacion.DisplayMember = "Nombre";
            cboHabitacion.ValueMember = "IdHabitacion";

            // Cargar datos en cboTipoHabitacion
            cboTipoHabitacion.DataSource = objneg.N_listar_tipo_habitacion();
            cboTipoHabitacion.DisplayMember = "Nombre";
            cboTipoHabitacion.ValueMember = "IdTipoHabitacion";

            // Cargar datos en cboCamilla
            cboCamilla.DataSource = objneg.N_listar_camillas();
            cboCamilla.DisplayMember = "Nombre";
            cboCamilla.ValueMember = "IdCamilla";

            Limpiar();
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            CargarComboboxes();
            Limpiar();
            dgvPacientes.DataSource = objneg.N_listar_pacientes();
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("1");
                    Limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
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
                    mantenedor("4");
                    Limpiar();
                }
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvPacientes.CurrentCell.RowIndex;

            string codigo = dgvPacientes[0, fila].Value?.ToString() ?? string.Empty;
            string nombre = dgvPacientes[1, fila].Value?.ToString() ?? string.Empty;
            string dni = dgvPacientes[2, fila].Value?.ToString() ?? string.Empty;
            string fechaNacimiento = dgvPacientes[3, fila].Value.ToString() ?? string.Empty;
            string telefono = dgvPacientes[4, fila].Value.ToString() ?? string.Empty;
            string direccion = dgvPacientes[5, fila].Value.ToString() ?? string.Empty;
            string genero = dgvPacientes[6, fila].Value.ToString() ?? string.Empty;
            string estadia = dgvPacientes[7, fila].Value.ToString() ?? string.Empty;
            string camilla = dgvPacientes[8, fila].Value.ToString() ?? string.Empty;
            string habitacion = dgvPacientes[9, fila].Value.ToString() ?? string.Empty;
            string tipohabitacion = dgvPacientes[10, fila].Value.ToString() ?? string.Empty;

            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtDni.Text = dni;
            dtpFechaNacimiento.Text = fechaNacimiento;
            txtCelular.Text = telefono;
            txtDireccion.Text = direccion;
            cboGenero.Text = genero;
            cboEstadia.Text = estadia;
            cboCamilla.Text = camilla;
            cboHabitacion.Text = habitacion;
            cboTipoHabitacion.Text = tipohabitacion;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuario();
                e.SuppressKeyPress = true;
                txtBuscar.Text = "";
            }
        }

        private void BuscarUsuario()
        {
            objent.Nombre = txtBuscar.Text;
            DataTable dt = objneg.N_buscar_pacientes(objent);
            dgvPacientes.DataSource = dt;
            dgvPacientes.Refresh();
        }
    }
}


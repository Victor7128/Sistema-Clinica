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
            try
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

                string mensaje = objneg.N_mantenedor_paciente(objent);
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (accion == "1")
                {
                    Alertas.NuevoPacienteRegistrado = true;
                }
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void CargarcboHabitacion(int idTipoHabitacion)
        {
            EntidadHospitalizacion objent = new EntidadHospitalizacion();
            objent.IdTipoHabitacion = idTipoHabitacion;
            cboHabitacion.DataSource = objneg.N_listar_habitaciones(objent);
            cboHabitacion.ValueMember = "IdHabitacion";
            cboHabitacion.DisplayMember = "Nombre";
        }

        public void CargarcboCamillas(int idHabitacion)
        {
            EntidadHospitalizacion objent = new EntidadHospitalizacion();
            objent.IdHabitacion = idHabitacion;
            cboCamilla.DataSource = objneg.N_listar_camillas(objent);
            cboCamilla.ValueMember = "IdCamilla";
            cboCamilla.DisplayMember = "Nombre";
        }

        private void cboTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoHabitacion.SelectedItem != null)
            {
                DataRowView selectedRow = cboTipoHabitacion.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int idTipoHabitacion = Convert.ToInt32(selectedRow["IdTipoHabitacion"]);
                    CargarcboHabitacion(idTipoHabitacion);
                    cboCamilla.DataSource = null;
                }
            }
        }

        private void cboHabitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboHabitacion.SelectedItem != null)
            {
                DataRowView selectedRow = cboHabitacion.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    int idHabitacion = Convert.ToInt32(selectedRow["IdHabitacion"]);
                    CargarcboCamillas(idHabitacion);
                }
            }
        }

        void CargarComboboxes()
        {
            cboGenero.DataSource = objneg.N_listar_genero();
            cboGenero.DisplayMember = "Nombre";
            cboGenero.ValueMember = "IdGenero";

            cboEstadia.DataSource = objneg.N_listar_estadias();
            cboEstadia.ValueMember = "IdEstadia";
            cboEstadia.DisplayMember = "Nombre";
            
            cboTipoHabitacion.DataSource = objneg.N_listar_tipo_habitacion();
            cboTipoHabitacion.DisplayMember = "Nombre";
            cboTipoHabitacion.ValueMember = "IdTipoHabitacion";
            Limpiar();
        }

        private bool CamposCompletos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDni.Text) ||
                cboGenero.SelectedIndex == -1 ||
                dtpFechaNacimiento.Value == null ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCelular.Text) ||
                cboEstadia.SelectedIndex == -1 ||
                cboTipoHabitacion.SelectedIndex == -1 ||
                cboHabitacion.SelectedIndex == -1 ||
                cboCamilla.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void BuscarUsuario()
        {
            objent.Nombre = txtBuscar.Text;
            DataTable dt = objneg.N_buscar_pacientes(objent);
            dgvPacientes.DataSource = dt;
            dgvPacientes.Refresh();
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            CargarComboboxes();
            Limpiar();

            dgvPacientes.Columns["Paciente"].Width = 250;
            dgvPacientes.Columns["Direccion"].Width = 280;
            dgvPacientes.Columns["TipoHabitacion"].Width = 230;
            dgvPacientes.CellFormatting += dgvPacientes_CellFormatting;
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CamposCompletos())
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("1");
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos para registrar al paciente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string tipohabitacion = dgvPacientes[7, fila].Value.ToString() ?? string.Empty;
            string habitacion = dgvPacientes[8, fila].Value.ToString() ?? string.Empty;
            string camilla = dgvPacientes[9, fila].Value.ToString() ?? string.Empty;
            string estadia = dgvPacientes[10, fila].Value.ToString() ?? string.Empty;

            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtDni.Text = dni;
            dtpFechaNacimiento.Text = fechaNacimiento;
            txtCelular.Text = telefono;
            txtDireccion.Text = direccion;
            cboGenero.Text = genero;
            cboTipoHabitacion.Text = tipohabitacion;
            cboHabitacion.Text = habitacion;
            cboCamilla.Text = camilla;
            cboEstadia.Text = estadia;           
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

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDni.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (txtDni.Text.Length > 8)
            {
                txtDni.Text = txtDni.Text.Substring(0, 8);
                txtDni.SelectionStart = txtDni.Text.Length;
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCelular.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            if (txtCelular.Text.Length > 9)
            {
                txtCelular.Text = txtCelular.Text.Substring(0, 9);
                txtCelular.SelectionStart = txtCelular.Text.Length;
            }
        }

        private void dgvPacientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvPacientes.Columns[e.ColumnIndex];
                if (column.Name == "HoraIngreso" || column.Name == "HoraSalida")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (e.Value is TimeSpan)
                        {
                            TimeSpan hora = (TimeSpan)e.Value;
                            e.Value = hora.ToString(@"hh\:mm");
                        }
                    }
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvPacientes.DataSource = objneg.N_listar_pacientes();

            dgvPacientes.Columns["Paciente"].Width = 250;
            dgvPacientes.Columns["Direccion"].Width = 280;
            dgvPacientes.Columns["TipoHabitacion"].Width = 230;
            dgvPacientes.CellFormatting += dgvPacientes_CellFormatting;
        }
    }
}


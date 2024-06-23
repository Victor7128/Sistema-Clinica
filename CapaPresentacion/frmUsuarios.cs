using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaDatos;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombres = txtNombreUsuario.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();
            int idRol = ObtenerIdRolSeleccionado();

            // Validación básica
            if (string.IsNullOrEmpty(nombres) || string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(clave) || idRol == 0)
            {
                MessageBox.Show("Todos los campos son requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Crear una instancia de CD_Usuario
                CD_Usuario usuarioDatos = new CD_Usuario();

                // Llamar al método de CapaDatos para agregar usuario
                int idUsuarioGenerado = usuarioDatos.RegistrarUsuario(nombres, usuario, clave, idRol);
                if (idUsuarioGenerado > 0)
                {
                    MessageBox.Show("Usuario agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    CargarUsuarios(); // Recargar los usuarios después de agregar uno nuevo
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            try
            {
                DataTable dtRoles = CD_Usuario.ObtenerRoles();
                cboRol.DisplayMember = "Nombre";
                cboRol.ValueMember = "IdRol";
                cboRol.DataSource = dtRoles;
                cboRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerIdRolSeleccionado()
        {
            if (cboRol.SelectedItem != null)
            {
                DataRowView drv = cboRol.SelectedItem as DataRowView;
                if (drv != null)
                {
                    return Convert.ToInt32(drv["IdRol"]);
                }
            }
            return 0;
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtIdUsuario.Clear();
            cboRol.SelectedIndex = -1;
        }

        private void CargarUsuarios()
        {
            try
            {
                DataTable dtUsuarios = CD_Usuario.ObtenerUsuariosConRoles();

                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.Columns.Clear();
                DataGridViewTextBoxColumn colIdUsuario = new DataGridViewTextBoxColumn { DataPropertyName = "IdUsuario", HeaderText = "IdUsuario", Name = "IdUsuario", Width = 50 };
                DataGridViewTextBoxColumn colNombres = new DataGridViewTextBoxColumn { DataPropertyName = "Nombres", HeaderText = "Nombres", Name = "Nombres", Width = 200 };
                DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn { DataPropertyName = "Usuario", HeaderText = "Usuario", Name = "Usuario", Width = 150 };
                DataGridViewTextBoxColumn colClave = new DataGridViewTextBoxColumn { DataPropertyName = "Clave", HeaderText = "Clave", Name = "Clave", Width = 150 };
                DataGridViewTextBoxColumn colRol = new DataGridViewTextBoxColumn { DataPropertyName = "Rol", HeaderText = "Rol", Name = "Rol", Width = 150 };
                dgvUsuarios.Columns.Add(colIdUsuario);
                dgvUsuarios.Columns.Add(colNombres);
                dgvUsuarios.Columns.Add(colUsuario);
                dgvUsuarios.Columns.Add(colClave);
                dgvUsuarios.Columns.Add(colRol);
                dgvUsuarios.DataSource = dtUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerRoles()
        {
            try
            {
                return CD_Usuario.ObtenerRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable(); // Retornar un DataTable vacío en caso de error
            }
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdUsuario.Text, out int idUsuario))
            {
                try
                {
                    CD_Usuario usuarioDatos = new CD_Usuario();
                    bool eliminado = usuarioDatos.EliminarUsuario(idUsuario);

                    if (eliminado)
                    {
                        MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LimpiarCampos();
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Usuario eliminado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                        CargarUsuarios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un IdUsuario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarUsuarios_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdUsuario.Text, out int idUsuario))
            {
                string nombres = txtNombreUsuario.Text.Trim();
                string usuario = txtUsuario.Text.Trim();
                string clave = txtClave.Text.Trim();
                int idRol = ObtenerIdRolSeleccionado();

                try
                {
                    // Validar que los datos sean correctos antes de intentar actualizar
                    if (idUsuario > 0 && !string.IsNullOrEmpty(nombres) && !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(clave) && idRol > 0)
                    {
                        CD_Usuario.ActualizarUsuario(idUsuario, nombres, usuario, clave, idRol);
                        MessageBox.Show("Usuario actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos(); // Limpiar campos después de la actualización si es necesario
                        CargarUsuarios(); // Recargar la lista de usuarios después de la actualización
                    }
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message ?? "No se pudo obtener el mensaje de error específico.";
                    MessageBox.Show($"Error al actualizar usuario: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("IdUsuario no es un valor numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];

                // Mostrar los datos en los TextBox
                txtIdUsuario.Text = row.Cells["IdUsuario"].Value.ToString();
                txtNombreUsuario.Text = row.Cells["Nombres"].Value.ToString();
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtClave.Text = row.Cells["Clave"].Value.ToString();

                // Seleccionar el rol correspondiente en el ComboBox u otro control
                string rol = row.Cells["Rol"].Value.ToString();
                cboRol.SelectedItem = cboRol.Items.Cast<DataRowView>().FirstOrDefault(item => item["Nombre"].ToString() == rol);
            }
        }
    }
}

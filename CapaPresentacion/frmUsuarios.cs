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

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmUsuarios : Form
    {
        EntidadUsuarios objent = new EntidadUsuarios();
        NegocioUsuarios objneg = new NegocioUsuarios();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        void mantenedor(string accion)
        {
            objent.Nombres = txtNombreUsuario.Text;
            objent.IdRol = Convert.ToInt32(cboRol.SelectedValue);
            objent.Usuario = txtUsuario.Text;
            objent.Clave = txtClave.Text;
            objent.accion = accion;
            string mensaje = objneg.N_mantenedor_usuario(objent);
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Limpiar()
        {
            txtNombreUsuario.Text = "";
            cboRol.SelectedIndex = -1;
            txtUsuario.Text = "";
            txtClave.Text = "";
            CargarUsuarios();
        }

        void CargarCombobox()
        {
            cboRol.DataSource = objneg.N_ObtenerRoles();
            cboRol.DisplayMember = "Nombre";
            cboRol.ValueMember = "IdRol";
        }

        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = objneg.N_ObtenerUsuariosConRoles();
            dgvUsuarios.Refresh();
        }

        private void añadirUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas registrar a " + txtNombreUsuario.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                mantenedor("1");
                Limpiar();
            }
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas modificar a " + txtNombreUsuario.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                mantenedor("2");
                Limpiar();
            }
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas eliminar a " + txtNombreUsuario.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                mantenedor("3");
                Limpiar();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvUsuarios.CurrentCell.RowIndex;

            string nombre = dgvUsuarios[0, fila].Value?.ToString() ?? string.Empty;
            string Usuario = dgvUsuarios[1, fila].Value?.ToString() ?? string.Empty;
            string Clave = dgvUsuarios[2, fila].Value.ToString() ?? string.Empty;
            string Rol = dgvUsuarios[3, fila].Value.ToString() ?? string.Empty;

            txtNombreUsuario.Text = nombre;
            cboRol.Text = Rol;
            txtUsuario.Text = Usuario;
            txtClave.Text = Clave;
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombobox();
            CargarUsuarios();
            Limpiar();

            dgvUsuarios.Columns["Nombres"].Width = 200;
            dgvUsuarios.Columns["Usuario"].Width = 150;
            dgvUsuarios.Columns["Clave"].Width = 150;
            dgvUsuarios.Columns["Rol"].Width = 250;
        }

        private void txtBuscarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuario();
                e.SuppressKeyPress = true;
                txtBuscarUsuario.Text = "";
            }
        }

        private void BuscarUsuario()
        {
            objent.Nombres = txtBuscarUsuario.Text;
            DataTable dt = objneg.N_BuscarUsuarios(objent);
            dgvUsuarios.DataSource = dt;
            dgvUsuarios.Refresh();
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBuscarUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

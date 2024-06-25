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
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtNombreUsuario.Text = "";
            cboRol.SelectedIndex = -1;
            txtUsuario.Text = "";
            txtClave.Text = "";
            txtBuscarUsuario.Text = "";
            dgvUsuarios.DataSource = objneg.N_ObtenerUsuariosConRoles();
        }

        void RellenarRol()
        {
            cboRol.DataSource = objneg.N_ObtenerRoles();
            cboRol.DisplayMember = "Nombre";
            cboRol.ValueMember = "IdRol";
        }

        private void añadirUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
        {

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
    }
}

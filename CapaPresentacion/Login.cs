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
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtClave.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int idusuario_esperado = CD_Usuario.Loguear(txtUsuario.Text, txtClave.Text);

            if (idusuario_esperado != 0)
            {
                this.Hide();
                Menu mdi = new Menu(idusuario_esperado);
                mdi.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private void pbMostrar_Click(object sender, EventArgs e)
        {
            pbOcultar.BringToFront();
            txtClave.PasswordChar = '*';
        }

        private void pbOcultar_Click(object sender, EventArgs e)
        {
            pbMostrar.BringToFront();
            txtClave.PasswordChar = '\0';
        }
    }
}
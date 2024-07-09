using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        EntidadLogin objent = new EntidadLogin();
        NegocioLogin objneg = new NegocioLogin();
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public Login()
        {
            InitializeComponent();
            txtClave.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int idusuario_esperado = objneg.N_Loguear(txtUsuario.Text, txtClave.Text);
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

        private void limpiar()
        {
            txtUsuario.Text = "";
            txtClave.Text = "";
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            int idusuario_esperado = objneg.N_Loguear(txtUsuario.Text, txtClave.Text);

            if (e.KeyCode == Keys.Enter)
            {
                if (idusuario_esperado != 0)
                {
                    this.Hide();
                    Menu mdi = new Menu(idusuario_esperado);
                    mdi.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    limpiar();
                    txtUsuario.Focus();
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
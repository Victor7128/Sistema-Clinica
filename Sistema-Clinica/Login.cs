﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Sistema_Clinica.CapaDatos;
using System.Sistema_Clinica.CapaEntidad;

namespace Sistema_Clinica
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            int idUsuarioEsperado = CD_Usuario.Loguear("usuario", "contraseña");
        }
    }
}

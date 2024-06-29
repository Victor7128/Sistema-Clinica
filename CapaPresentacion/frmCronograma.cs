using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCronograma : Form
    {
        public frmCronograma()
        {
            InitializeComponent();
        }

        private void frmCronograma_Load(object sender, EventArgs e)
        {
            if (Alertas.NuevoPacienteRegistrado)
            {
                MessageBox.Show("Nuevo paciente registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Alertas.NuevoPacienteRegistrado = false; // Resetear la alerta
            }
        }
    }
}

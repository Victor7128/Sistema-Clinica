using CapaDatos;
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
    public partial class frmCirugias : Form
    {
        EntidadCirugia objent = new EntidadCirugia();
        NegocioCirugia objneg = new NegocioCirugia();

        public frmCirugias()
        {
            InitializeComponent();
        }
        private void CargarSalas()
        {
            
        }
        private void CargarDatos()
        {
            
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegCirugC_Click(object sender, EventArgs e)
        {
            
        }
        private void ActualizarListaCirugias()
        {
            
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }
        private void btnMostListCirugC_Click(object sender, EventArgs e)
        {
            ActualizarListaCirugias();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnBuscarPaciente_Click_1(object sender, EventArgs e)
        {
            
        }

        private void LlenarComboBoxMedicos()
        {
            
        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmCirugias_Load(object sender, EventArgs e)
        {
            
        }

        public string nombreMedico { set { nombreMedico = txtMedico.Text; } }
    }
}

using CapaDatos;
using CapaEntidad;
using CapaNegocio;
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
    public partial class frmProgramacion : Form
    {
        EntidadCirugia objent = new EntidadCirugia();
        NegocioCirugia objneg = new NegocioCirugia();

        public frmProgramacion()
        {
            InitializeComponent();
        }

        private void BuscarCirugias()
        {
            objent.FechaCirugia = dtpFecha.Value;
            DataTable dt = objneg.N_buscarCirugiasDisponibles(objent);
            dgvCirugias.DataSource = dt;
            dgvCirugias.Refresh();
        }

        private void frmCronograma_Load(object sender, EventArgs e)
        {
            if (Alertas.NuevoPacienteRegistrado)
            {
                MessageBox.Show("Nuevo paciente registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Alertas.NuevoPacienteRegistrado = false;
            }
            BuscarCirugias();
        }

        private void btnBuscarCirugias_Click(object sender, EventArgs e)
        {
            BuscarCirugias();
        }
    }
}

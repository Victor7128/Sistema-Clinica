using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos; // Asegúrate de tener la referencia a la capa de datos
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmListaCirugias : Form
    {
        public frmListaCirugias()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.frmListaCirugias_Load);
            comboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltro_SelectedIndexChanged);
        }
        private void frmListaCirugias_Load(object sender, EventArgs e)
        {
            comboBoxFiltro.Items.Add("Todos");
            comboBoxFiltro.Items.Add("Activo");
            comboBoxFiltro.Items.Add("Pendiente");
            comboBoxFiltro.Items.Add("Finalizada");
            comboBoxFiltro.SelectedIndex = 0;

            CargarCirugias();
        }

        private void CargarCirugias()
        {
            DataTable dtCirugias = CD_Cirugia.ObtenerCirugiasConEstado();

            dataGridView1.DataSource = dtCirugias;
        }

        private void comboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboBoxFiltro.SelectedItem.ToString();
            DataTable dtCirugias = CD_Cirugia.ObtenerCirugiasConEstado();

            if (filtro != "Todos")
            {
                DataView dv = dtCirugias.DefaultView;
                dv.RowFilter = $"Estado = '{filtro}'";
                dataGridView1.DataSource = dv.ToTable();
            }
            else
            {
                dataGridView1.DataSource = dtCirugias;
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int idCirugia = Convert.ToInt32(row.Cells["IdCirugia"].Value);
                string tipoCirugia = row.Cells["TipoCirugia"].Value.ToString();
                string sala = row.Cells["Sala"].Value.ToString();
                DateTime fechaCirugia = Convert.ToDateTime(row.Cells["FechaCirugia"].Value);

                CD_Cirugia.ActualizarCirugia(idCirugia, tipoCirugia, sala, fechaCirugia);
            }

            MessageBox.Show("Cambios guardados exitosamente.", "Guardar Cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarCirugias();
        }
    }
}

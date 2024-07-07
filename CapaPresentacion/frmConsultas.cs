using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmConsultas : Form
    {
        EntidadHospitalizacion objent = new EntidadHospitalizacion();
        NegocioHospitalizacion objneg = new NegocioHospitalizacion();

        public frmConsultas()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtNombreBuscar.Text = "";
            dgvBuscador.DataSource = objneg.N_listar_pacientes_consulta();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Limpiar();
            dgvBuscador.DataSource = objneg.N_listar_pacientes_consulta();

            dgvBuscador.Columns["Nombre"].Width = 230;
            dgvBuscador.CellFormatting += dgvBuscador_CellFormatting;
        }

        private void txtNombreBuscar_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuarioNOMBRE();
                e.SuppressKeyPress = true;
                txtNombreBuscar.Text = "";
            }
        }

        private void btnListarPacientes_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BuscarUsuarioNOMBRE()
        {
            objent.Nombre = txtNombreBuscar.Text;
            DataTable dt = objneg.N_BuscarPacientesConsulta(objent);
            dgvBuscador.DataSource = dt;
            dgvBuscador.Refresh();
        }

        private void txtNombreBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarioNOMBRE();
            txtNombreBuscar.Text = "";
        }

        private void dgvBuscador_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvBuscador.Columns[e.ColumnIndex];
                if (column.Name == "HoraIngreso" || column.Name == "HoraSalida")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (e.Value is TimeSpan)
                        {
                            TimeSpan hora = (TimeSpan)e.Value;
                            e.Value = hora.ToString(@"hh\:mm");
                        }
                    }
                }
            }
        }
    }
}

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
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            Conexion_2.Conectar();
            MessageBox.Show("conexion exitosa");
            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion_2.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Reportes";
            SqlCommand cmd = new SqlCommand(consulta,Conexion_2.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion_2.Conectar();
            string insertar = "INSERT INTO Reportes (reporte,area,turno,fecha) VALUES (@reporte,@area,@turno,@fecha) ";
            SqlCommand cmd1 = new SqlCommand(insertar,Conexion_2.Conectar());
            cmd1.Parameters.AddWithValue("@reporte",txtReporte.Text);
            cmd1.Parameters.AddWithValue("@area", txtArea.Text);
            cmd1.Parameters.AddWithValue("@turno", txtTurno.Text);
            cmd1.Parameters.AddWithValue("@fecha",  dateTimePicker1.Value);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("datos agregados correctamenter");
            dataGridView1.DataSource= llenar_grid();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha = dateTimePicker1.Value;
        }
    }
}

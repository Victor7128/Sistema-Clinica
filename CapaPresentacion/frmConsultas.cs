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
    public partial class frmConsultas : Form
    {
        public static string cn = @"Data Source=DESKTOP-175P6I3\SQLEXPRESS;Initial Catalog=Clinica;Integrated Security=True";
        public frmConsultas()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmConsultas_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            string nombreABuscar = txtApellidoBuscar.Text.Trim();
            string dniBuscar = txtDNIBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(nombreABuscar))
            {
                BuscarPorNombre(nombreABuscar);
                txtApellidoBuscar.Clear();
            }
            else if (!string.IsNullOrEmpty(dniBuscar))
            {
                BuscarPorDNI(dniBuscar);
                txtDNIBuscar.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un nombre o DNI para buscar.");
            }
        }

        private void BuscarPorNombre(string nombre)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cn))
                {
                    string query = @"
                        SELECT 
                            p.Nombre AS NombrePaciente,
                            p.DNI,
                            h.Nombre AS NombreHabitacion,
                            c.Nombre AS NombreCamilla
                        FROM 
                            Pacientes p
                            INNER JOIN Habitaciones h ON p.IdPaciente = h.IdHabitacion
                            INNER JOIN Camillas c ON h.IdHabitacion = c.IdCamilla
                        WHERE 
                            p.Nombre LIKE @Nombre";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontró ningún paciente con ese nombre.");
                    }

                    dgvPaciente.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en la base de datos: " + ex.Message);
            }
        }

        private void BuscarPorDNI(string dni)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cn))
                {
                    string query = @"
                        SELECT 
                            p.Nombre AS NombrePaciente,
                            p.DNI,
                            h.Nombre AS NombreHabitacion,
                            c.Nombre AS NombreCamilla
                        FROM 
                            Pacientes p
                            INNER JOIN Habitaciones h ON p.IdPaciente = h.IdHabitacion
                            INNER JOIN Camillas c ON h.IdHabitacion = c.IdCamilla
                        WHERE 
                            p.DNI = @DNI";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DNI", dni);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontró ningún paciente con ese DNI.");
                    }

                    dgvPaciente.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar en la base de datos: " + ex.Message);
            }
        }
    }
}

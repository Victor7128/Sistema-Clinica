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
using System.Data.SqlClient;

namespace CapaPresentacion
{
    public partial class frmCirugias : Form
    {
        EntidadCirugia objent = new EntidadCirugia();
        NegocioCirugia objneg = new NegocioCirugia();

        public frmCirugias()
        {
            InitializeComponent();
            CargarSalas();
            CargarDatos();
            this.Load += new System.EventHandler(this.frmCirugia_Load);
            ActualizarDataGridView();
        }
        private void CargarSalas()
        {
            try
            {
                // Obtener las salas desde la base de datos usando un método en CapaDatos
                DataTable dtSalas = DatosSala.ObtenerSalas(); // Suponiendo que tienes un método en CapaDatos para obtener las salas
                comboBox1.DataSource = dtSalas;
                comboBox1.DisplayMember = "Nombre"; // Nombre del campo que quieres mostrar en el ComboBox
                comboBox1.ValueMember = "IdSala"; // Nombre del campo que es el valor de cada item en el ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las salas: {ex.Message}");
            }
        }
        private void CargarDatos()
        {
            // Cargar pacientes al DataGridView1
            dataGridView1.DataSource = DatosCirugia.ObtenerPacientes(txtApellidoBuscar.Text);
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=Clinica;Integrated Security=True;Encrypt=False";

        private void EjecutarProcedimiento(string accion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_mantenedorCirugias", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombrePaciente", txtPacSelecC.Text);
                    cmd.Parameters.AddWithValue("@descripcionCirugia", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@fechaCirugia", dateTimePicker2.Value.Date);
                    cmd.Parameters.AddWithValue("@horaCirugia", TimeSpan.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@salaCirugia", Convert.ToInt32(comboBox1.SelectedValue));

                    SqlParameter accionParam = new SqlParameter("@accion", SqlDbType.VarChar, 50)
                    {
                        Direction = ParameterDirection.InputOutput,
                        Value = accion
                    };
                    cmd.Parameters.Add(accionParam);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show(accionParam.Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string nombrePaciente = row.Cells["Nombre"].Value.ToString();
                txtPacSelecC.Text = nombrePaciente;
            }
        }

        private void btnBuscarPaciente_Click_1(object sender, EventArgs e)
        {
            string apellidoBuscar = txtApellidoBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(apellidoBuscar))
            {
                try
                {
                    DataTable dtPacientes = DatosPaciente.ObtenerPacientesPorApellido(apellidoBuscar);
                    dataGridView1.DataSource = dtPacientes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar pacientes: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre de un paciente a buscar.");
            }
        }

        private void frmCirugia_Load(object sender, EventArgs e)
        {
            txtMedicoAsignado.Text = UsuarioLogueado.NombreUsuario;
        }

        private void ActualizarDataGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cirugias", con))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarProcedimiento("1");
            ActualizarDataGridView();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarProcedimiento("2");
            ActualizarDataGridView();
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarProcedimiento("3");
            ActualizarDataGridView();
        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarProcedimiento("4");
            ActualizarDataGridView();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarProcedimiento("5");
            ActualizarDataGridView();
        }


        private void frmCirugias_Load(object sender, EventArgs e)
        {
            
        }

        public string nombreMedico { set { nombreMedico = txtMedicoAsignado.Text; } }
    }
}

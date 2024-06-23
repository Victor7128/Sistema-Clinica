using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace CapaPresentacion
{
    public partial class frmHistorial : Form
    {
        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Conexion_2.Conectar();
            MessageBox.Show("conexion exitosa");
            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion_2.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Historial";
            SqlCommand cmd = new SqlCommand(consulta, Conexion_2.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion_2.Conectar();
            string insertar = "INSERT INTO Historial (nombre,genero,telefono,fecha,dni,dirrecion,alergias,enfermedadesc,cirugias,consume,enfermedadesh,estudiosl,resultados) VALUES (@nombre,@genero,@telefono,@fecha,@dni,@dirrecion,@alergias,@enfermedadesc,@cirugias,@consume,@enfermedadesh,@estudiosl,@resultados) ";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion_2.Conectar());
            cmd1.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@genero", txtGenero.Text);
            cmd1.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd1.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            cmd1.Parameters.AddWithValue("@dni", txtDni.Text);
            cmd1.Parameters.AddWithValue("@dirrecion", txtDireccion.Text);
            cmd1.Parameters.AddWithValue("@alergias", txtAlergias.Text);
            cmd1.Parameters.AddWithValue("@enfermedadesc", txtEnfermedadesc.Text);
            cmd1.Parameters.AddWithValue("@cirugias", txtCirugiasPrevias.Text);
            cmd1.Parameters.AddWithValue("@consume", txtConsume.Text);
            cmd1.Parameters.AddWithValue("@enfermedadesh", txtEnfermedadesh.Text);
            cmd1.Parameters.AddWithValue("@estudiosl", txtEstudios.Text);
            cmd1.Parameters.AddWithValue("@resultados", txtResultados.Text);


            cmd1.ExecuteNonQuery();
            MessageBox.Show("datos agregados correctamenter");
            dataGridView1.DataSource = llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion_2.Conectar();
            string actualizar = "UPDATE Historial SET nombre=@nombre,genero=@genero,telefono=@telefono,fecha=@fecha,dni=@dni,dirrecion=@dirrecion,alergias=@alergias,enfermedadesc=@enfermedadesc,cirugias=@cirugias,consume=@consume,enfermedadesh=enfermedadesh,estudiosl=@estudiosl,resultados=@resultados where nombre=@nombre";
            SqlCommand cmd2 = new SqlCommand(actualizar,Conexion_2.Conectar());
            cmd2.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@genero", txtGenero.Text);
            cmd2.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd2.Parameters.AddWithValue("@fecha", dateTimePicker1.Value);
            cmd2.Parameters.AddWithValue("@dni", txtDni.Text);
            cmd2.Parameters.AddWithValue("@dirrecion", txtDireccion.Text);
            cmd2.Parameters.AddWithValue("@alergias", txtAlergias.Text);
            cmd2.Parameters.AddWithValue("@enfermedadesc", txtEnfermedadesc.Text);
            cmd2.Parameters.AddWithValue("@cirugias", txtCirugiasPrevias.Text);
            cmd2.Parameters.AddWithValue("@consume", txtConsume.Text);
            cmd2.Parameters.AddWithValue("@enfermedadesh", txtEnfermedadesh.Text);
            cmd2.Parameters.AddWithValue("@estudiosl", txtEstudios.Text);
            cmd2.Parameters.AddWithValue("@resultados", txtResultados.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("datos actualizados correctamente");
            dataGridView1.DataSource = llenar_grid();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Asegúrate de que hay una fila seleccionada
                if (dataGridView1.CurrentRow != null)
                {
                    txtNombre.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtGenero.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtTelefono.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    // Asegúrate de que el valor de la celda no es nulo y conviértelo a DateTime
                    if (dataGridView1.CurrentRow.Cells[3].Value != null && DateTime.TryParse(dataGridView1.CurrentRow.Cells[3].Value.ToString(), out DateTime fecha))
                    {
                        dateTimePicker1.Value = fecha;
                    }
                    else
                    {
                        // Maneja el caso donde el valor de la celda no es una fecha válida
                        MessageBox.Show("El valor de la fecha no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Resto de los campos
                    txtDni.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    txtDireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    txtAlergias.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    txtEnfermedadesc.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    txtCirugiasPrevias.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    txtConsume.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    txtEnfermedadesh.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    txtEstudios.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    txtResultados.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción que pueda ocurrir
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string buscar = "SELECT * FROM Historial where nombre=@nombre ";
            SqlCommand cmd3 = new SqlCommand(buscar, Conexion_2.Conectar());
            cmd3.Parameters.AddWithValue("@nombre", txtNombre.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd3);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Asignar el DataTable al DataGridView
            dataGridView1.DataSource = dt;
            cmd3.ExecuteNonQuery();
            MessageBox.Show("busqueda correctamente");
    
        }
    }
}
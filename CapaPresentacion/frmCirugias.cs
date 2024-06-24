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

namespace CapaPresentacion
{
    public partial class frmCirugias : Form
    {
        public frmCirugias()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            // Cargar pacientes al DataGridView1
            dataGridView1.DataSource = CD_Cirugia.ObtenerPacientes(txtApellidoBuscar.Text);
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegCirugC_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada
            if (dataGridView1.CurrentRow != null)
            {
                string tipoCirugia = txtTipoCirugC.Text;
                int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdPaciente"].Value);
                string nombrePaciente = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(); // Obtener el nombre del paciente
                string sala = txtSalaC.Text;
                string turno = txtHoraC.Text;
                DateTime fechaCirugia = monthCalendar1.SelectionStart;

                CD_Cirugia.AgregarCirugia(tipoCirugia, idPaciente, nombrePaciente, sala, turno, fechaCirugia);

                ActualizarListaCirugias();
            }
            else
            {
                MessageBox.Show("Seleccione un paciente antes de registrar la cirugía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarListaCirugias()
        {
            dataGridView2.DataSource = CD_Cirugia.ObtenerCirugias();
        }

        private void btnMostListCirugC_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = CD_Cirugia.ObtenerCirugias();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que la celda clickeada no sea el encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Obtener el valor del nombre del paciente desde la fila seleccionada
                string nombrePaciente = row.Cells["Nombre"].Value.ToString();

                // Mostrar el nombre del paciente en el textbox de paciente seleccionado
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
                    DataTable dtPacientes = CD_Paciente.ObtenerPacientesPorApellido(apellidoBuscar);
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
    }
}

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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.ShowUpDown = true;
            CargarSalas();
            LlenarComboBoxMedicos();
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

        private void btnRegCirugC_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridView1.CurrentRow != null)
            {
                string tipoCirugia = txtTipoCirugC.Text;
                int idPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdPaciente"].Value);
                string nombrePaciente = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString(); // Obtener el nombre del paciente
                string sala = comboBox1.SelectedValue.ToString(); // Obtener la sala seleccionada del ComboBox
                TimeSpan horaCirugia = dateTimePicker1.Value.TimeOfDay;
                DateTime fechaCirugia = monthCalendar1.SelectionStart;

                try
                {
                    DatosCirugia.AgregarCirugia(tipoCirugia, idPaciente, nombrePaciente, sala, horaCirugia, fechaCirugia);
                    MessageBox.Show("Cirugía agregada exitosamente.");
                    ActualizarListaCirugias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al agregar cirugía: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un paciente antes de registrar la cirugía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ActualizarListaCirugias()
        {
            dataGridView2.DataSource = DatosCirugia.ObtenerCirugias();

            // Formatear la columna de HoraCirugia para mostrar solo hora y minutos
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells["HoraCirugia"].Value != null)
                {
                    TimeSpan hora = (TimeSpan)row.Cells["HoraCirugia"].Value;
                    row.Cells["HoraCirugia"].Value = hora.ToString(@"hh\:mm"); // Formato para mostrar solo hora y minutos
                }
            }
        }
        // Agrega este método a tu formulario frmCirugias
        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView2.Columns[e.ColumnIndex];

                // Verificar si la columna es la columna de HoraCirugia
                if (column.Name == "HoraCirugia")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (e.Value is TimeSpan)
                        {
                            TimeSpan hora = (TimeSpan)e.Value;
                            // Formato para mostrar solo hora y minutos
                            e.Value = hora.ToString(@"hh\:mm");
                            e.FormattingApplied = true; // Indica que se aplicó el formato
                        }
                    }
                }
            }
        }
        private void btnMostListCirugC_Click(object sender, EventArgs e)
        {
            ActualizarListaCirugias();
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
        private void LlenarComboBoxMedicos()
        {
            try
            {
                // Obtener los médicos desde la base de datos usando el método en CapaDatos
                DataTable dtMedicos = DatosCirugia.ObtenerMedicos();

                // Asignar los datos al ComboBox
                comboBox2.DataSource = dtMedicos;
                comboBox2.DisplayMember = "Nombres";
                comboBox2.ValueMember = "IdUsuario";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los médicos: {ex.Message}");
            }
        }

    }
}

﻿using System;
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
    public partial class frmHospitalizacion : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();

        public frmHospitalizacion()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        void mantenedor(String accion)
        {
            objent.Codigo = txtCodigo.Text;
            objent.Nombre = txtNombre.Text;
            objent.DNI = Convert.ToInt32(txtDni.Text);
            objent.IdEstadia = Convert.ToInt32(cboEstadia.SelectedValue);
            objent.IdCamilla = Convert.ToInt32(cboCamilla.SelectedValue);
            objent.IdHabitacion = Convert.ToInt32(cboHabitacion.SelectedValue);
            objent.IdTipoHabitacion = Convert.ToInt32(cboTipoHabitacion.SelectedValue);
            objent.FechaIngreso = DateTime.Now.Date;
            objent.HoraIngreso = DateTime.Now.TimeOfDay;
            objent.accion = accion;
            string men = objneg.N_mantenedor_paciente(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDni.Text = "";
            cboEstadia.SelectedIndex = -1;
            cboHabitacion.SelectedIndex = -1;
            cboTipoHabitacion.SelectedIndex = -1;
            cboCamilla.SelectedIndex = -1;
            dgvPacientes.DataSource = objneg.N_listar_pacientes();
        }

        void CargarComboboxes()
        {
            // Cargar datos en cboEstadia
            cboEstadia.DataSource = objneg.N_listar_estadias();
            cboEstadia.DisplayMember = "Nombre";
            cboEstadia.ValueMember = "IdEstadia";

            // Cargar datos en cboHabitacion
            cboHabitacion.DataSource = objneg.N_listar_habitaciones();
            cboHabitacion.DisplayMember = "Nombre";
            cboHabitacion.ValueMember = "IdHabitacion";

            // Cargar datos en cboTipoHabitacion
            cboTipoHabitacion.DataSource = objneg.N_listar_tipo_habitacion();
            cboTipoHabitacion.DisplayMember = "Nombre";
            cboTipoHabitacion.ValueMember = "IdTipoHabitacion";

            // Cargar datos en cboCamilla
            cboCamilla.DataSource = objneg.N_listar_camillas();
            cboCamilla.DisplayMember = "Nombre";
            cboCamilla.ValueMember = "IdCamilla";

            Limpiar();
        }

        private void frmHospitalizacion_Load(object sender, EventArgs e)
        {            
            timer1.Enabled = true;
            CargarComboboxes();
            dgvPacientes.DataSource = objneg.N_listar_pacientes();
        }

        private void registrarEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas registrar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("1");
                    Limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("2");
                    Limpiar();
                }
            }
        }

        private void registrarSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas registrar salida a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("3");
                    Limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar a " + txtNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenedor("4");
                    Limpiar();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                objent.Nombre = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_pacientes(objent);
                dgvPacientes.DataSource = dt;
            }
            else
            {
                dgvPacientes.DataSource = objneg.N_listar_pacientes();
            }
        }

        private void dgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvPacientes.CurrentCell.RowIndex;

            string codigo = dgvPacientes[0, fila].Value?.ToString() ?? string.Empty;
            string nombre = dgvPacientes[1, fila].Value?.ToString() ?? string.Empty;
            string dni = dgvPacientes[2, fila].Value?.ToString() ?? string.Empty;
            string estadia = dgvPacientes[3, fila].Value.ToString() ?? string.Empty;
            string camilla = dgvPacientes[4, fila].Value.ToString() ?? string.Empty;
            string habitacion = dgvPacientes[5, fila].Value.ToString() ?? string.Empty;
            string tipohabitacion = dgvPacientes[6, fila].Value.ToString() ?? string.Empty;

            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtDni.Text = dni;
            cboEstadia.Text = estadia;
            cboCamilla.Text = camilla;
            cboHabitacion.Text = habitacion;
            cboTipoHabitacion.Text = tipohabitacion;
        }
    }
}


using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPermisos : Form
    {
        EntidadPermisos objent = new EntidadPermisos();
        NegocioPermisos objneg = new NegocioPermisos();

        public frmPermisos()
        {
            InitializeComponent();
        }

        private void CargarComboBox()
        {
            DataTable roles = objneg.N_listar_roles();
            cboRol.DataSource = roles;
            cboRol.DisplayMember = "Nombre";
            cboRol.ValueMember = "IdRol";
        }

        private void CargardgvMenu()
        {
            var selectedValue = cboRol.SelectedValue;
            int idRol;
            bool parseResult = int.TryParse(selectedValue.ToString(), out idRol);
            objent.IdRol = idRol;
            dgvMenu.DataSource = objneg.N_buscar_rol(objent);
        }

        public void GuardarCambios()
        {
            foreach (DataGridViewRow row in dgvMenu.Rows)
            {
                if (row.Cells["IdMenu"].Value != null && row.Cells["Permiso"].Value != null)
                {
                    objent.IdRol = Convert.ToInt32(cboRol.SelectedValue);
                    objent.IdMenu = Convert.ToInt32(row.Cells["IdMenu"].Value);
                    objent.NuevoPermiso = Convert.ToBoolean(row.Cells["Permiso"].Value);

                    objneg.N_modificar_permiso(objent);
                }
            }            
            MessageBox.Show("Cambios guardados correctamente.");            
        }

        private void cboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargardgvMenu();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void frmPermisos_Load(object sender, EventArgs e)
        {
            dgvMenu.AutoGenerateColumns = false;
            dgvMenu.Columns.Clear();

            DataGridViewTextBoxColumn idMenuColumn = new DataGridViewTextBoxColumn();
            idMenuColumn.Name = "IdMenu";
            idMenuColumn.HeaderText = "IdMenu";
            idMenuColumn.DataPropertyName = "IdMenu";
            idMenuColumn.Visible = false;
            idMenuColumn.ReadOnly = true;
            dgvMenu.Columns.Add(idMenuColumn);

            DataGridViewTextBoxColumn menuColumn = new DataGridViewTextBoxColumn();
            menuColumn.Name = "Menu";
            menuColumn.HeaderText = "Menu";
            menuColumn.DataPropertyName = "Menu";
            menuColumn.ReadOnly = true;
            dgvMenu.Columns.Add(menuColumn);

            DataGridViewCheckBoxColumn permisoColumn = new DataGridViewCheckBoxColumn();
            permisoColumn.Name = "Permiso";
            permisoColumn.HeaderText = "Permiso";
            permisoColumn.DataPropertyName = "Permiso";
            dgvMenu.Columns.Add(permisoColumn);

            CargarComboBox();
            CargardgvMenu();

            dgvMenu.Columns["Menu"].Width = 180;
        }
    }
}

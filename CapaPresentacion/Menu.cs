using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Menu : Form
    {
        EntidadLogin objent = new EntidadLogin();
        NegocioLogin objneg = new NegocioLogin();
        public MenuStrip menuStrip;
        private int idusuario;        

        public Menu(int idusuario_esperado = 0)
        {
            InitializeComponent();
            idusuario = idusuario_esperado;
            this.FormClosing += new FormClosingEventHandler(cerrarPrograma);
        }

        public void Menu_Load(object sender, EventArgs e)
        {
            InicializarMenuStrip();
            //Panel panelContainer = new Panel();
            //panelContainer.Name = "PanelContainer";
            //panelContainer.Dock = DockStyle.Fill;
            //Controls.Add(panelContainer);
            //Controls.SetChildIndex(menuStrip, 0);

            AbrirFormulario(new Inicio());
        }

        private void click_en_menu(object sender, EventArgs e)
        {
            ToolStripMenuItem menuSeleccionado = (ToolStripMenuItem)sender;
            Assembly asm = Assembly.GetExecutingAssembly();
            Type elemento = asm.GetType(asm.GetName().Name + "." + menuSeleccionado.Name);
            if (elemento == null)
            {
                MessageBox.Show("Página no encontrada");
            }
            else
            {
                Panel panelContainer = this.Controls.Find("PanelContainer", true).FirstOrDefault() as Panel;
                if (panelContainer != null)
                {
                    foreach (Control ctrl in panelContainer.Controls)
                    {
                        if (ctrl is Form)
                        {
                            ((Form)ctrl).Close();
                        }
                    }
                    panelContainer.Controls.Clear();

                    Form formularioCreado = (Form)Activator.CreateInstance(elemento);
                    formularioCreado.TopLevel = false;
                    formularioCreado.Dock = DockStyle.Fill;
                    panelContainer.Controls.Add(formularioCreado);
                    formularioCreado.Show();
                }
            }
        }

        private void AbrirFormulario(Form formulario)
        {
            Panel panelContainer = this.Controls.Find("PanelContainer", true).FirstOrDefault() as Panel;
            if (panelContainer != null)
            {
                foreach (Control ctrl in panelContainer.Controls)
                {
                    if (ctrl is Form)
                    {
                        ((Form)ctrl).Close();
                    }
                }
                panelContainer.Controls.Clear();

                formulario.TopLevel = false;
                formulario.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(formulario);
                formulario.Show();
            }
        }

        private void cerrarPrograma(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void InicializarMenuStrip()
        {
            List<CapaEntidad.EntidadLogin> permisos_esperados = objneg.N_ObtenerPermisos(idusuario);

            menuStrip = new MenuStrip();

            foreach (CapaEntidad.EntidadLogin objMenu in permisos_esperados)
            {
                ToolStripMenuItem menuPadre = new ToolStripMenuItem(objMenu.Nombre, null, click_en_menu, objMenu.NombreFormulario);
                menuPadre.Tag = objMenu;
                menuStrip.Items.Add(menuPadre);
            }

            this.MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }
    }
}
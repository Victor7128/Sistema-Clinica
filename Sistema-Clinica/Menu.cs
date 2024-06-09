using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Clinica
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void abrir_form(object hijo)
        {
            if (this.Panel_content.Controls.Count>0)
            {
                this.Panel_content.Controls.RemoveAt(0);
            }
            Form formh = hijo as Form;
            formh.TopLevel = false;
            formh.Dock = DockStyle.Fill;
            this.Panel_content.Controls.Add(formh);
            this.Panel_content.Tag = formh;
            formh.Show();
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            abrir_form(new Consultas());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrir_form(new Inicio());
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            btnInicio_Click(null, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            abrir_form(new MANTENIMIENTO());
        }
    }
}

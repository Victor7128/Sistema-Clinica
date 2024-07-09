namespace CapaPresentacion
{
    partial class frmCirugias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvPacientes = new System.Windows.Forms.DataGridView();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSala = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxDescripcion = new System.Windows.Forms.RichTextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.dgvCirugias = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarEntradaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarSalidaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCirugias)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 39);
            this.label1.TabIndex = 42;
            this.label1.Text = "REGISTRAR CIRUGÍAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(22, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 21);
            this.label5.TabIndex = 73;
            this.label5.Text = "MEDICO ASIGNADO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(22, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 21);
            this.label6.TabIndex = 75;
            this.label6.Text = "Paciente Seleccionado";
            // 
            // dgvPacientes
            // 
            this.dgvPacientes.AllowUserToAddRows = false;
            this.dgvPacientes.AllowUserToDeleteRows = false;
            this.dgvPacientes.BackgroundColor = System.Drawing.Color.White;
            this.dgvPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPacientes.Location = new System.Drawing.Point(26, 281);
            this.dgvPacientes.Name = "dgvPacientes";
            this.dgvPacientes.ReadOnly = true;
            this.dgvPacientes.RowHeadersWidth = 51;
            this.dgvPacientes.Size = new System.Drawing.Size(283, 67);
            this.dgvPacientes.TabIndex = 79;
            this.dgvPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPacientes_CellContentClick);
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPaciente.Location = new System.Drawing.Point(223, 236);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(86, 30);
            this.btnBuscarPaciente.TabIndex = 81;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(391, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 21);
            this.label3.TabIndex = 83;
            this.label3.Text = "Sala";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(540, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 21);
            this.label4.TabIndex = 85;
            this.label4.Text = "Hora";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(26, 237);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(186, 27);
            this.txtBuscar.TabIndex = 91;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(22, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 21);
            this.label7.TabIndex = 90;
            this.label7.Text = "Buscar Paciente";
            // 
            // cboSala
            // 
            this.cboSala.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSala.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSala.FormattingEnabled = true;
            this.cboSala.Location = new System.Drawing.Point(395, 104);
            this.cboSala.Margin = new System.Windows.Forms.Padding(2);
            this.cboSala.Name = "cboSala";
            this.cboSala.Size = new System.Drawing.Size(116, 29);
            this.cboSala.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(391, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 21);
            this.label2.TabIndex = 77;
            this.label2.Text = "Descripción de cirugía";
            // 
            // rtxDescripcion
            // 
            this.rtxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtxDescripcion.Location = new System.Drawing.Point(395, 236);
            this.rtxDescripcion.Name = "rtxDescripcion";
            this.rtxDescripcion.Size = new System.Drawing.Size(378, 80);
            this.rtxDescripcion.TabIndex = 98;
            this.rtxDescripcion.Text = "";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(395, 170);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(391, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 21);
            this.label8.TabIndex = 100;
            this.label8.Text = "Fecha";
            // 
            // txtHora
            // 
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHora.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.Location = new System.Drawing.Point(544, 106);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(110, 27);
            this.txtHora.TabIndex = 101;
            // 
            // dgvCirugias
            // 
            this.dgvCirugias.AllowUserToAddRows = false;
            this.dgvCirugias.AllowUserToDeleteRows = false;
            this.dgvCirugias.BackgroundColor = System.Drawing.Color.White;
            this.dgvCirugias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCirugias.Location = new System.Drawing.Point(26, 367);
            this.dgvCirugias.Name = "dgvCirugias";
            this.dgvCirugias.ReadOnly = true;
            this.dgvCirugias.RowHeadersWidth = 51;
            this.dgvCirugias.Size = new System.Drawing.Size(747, 194);
            this.dgvCirugias.TabIndex = 103;
            this.dgvCirugias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCirugias_CellContentClick);
            this.dgvCirugias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCirugias_CellFormatting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.registrarEntradaToolStripMenuItem,
            this.registrarSalidaToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(395, 324);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(406, 24);
            this.menuStrip1.TabIndex = 104;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registrarToolStripMenuItem
            // 
            this.registrarToolStripMenuItem.Name = "registrarToolStripMenuItem";
            this.registrarToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.registrarToolStripMenuItem.Text = "Registrar";
            this.registrarToolStripMenuItem.Click += new System.EventHandler(this.registrarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // registrarEntradaToolStripMenuItem
            // 
            this.registrarEntradaToolStripMenuItem.Name = "registrarEntradaToolStripMenuItem";
            this.registrarEntradaToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.registrarEntradaToolStripMenuItem.Text = "RegistrarEntrada";
            this.registrarEntradaToolStripMenuItem.Click += new System.EventHandler(this.registrarEntradaToolStripMenuItem_Click);
            // 
            // registrarSalidaToolStripMenuItem
            // 
            this.registrarSalidaToolStripMenuItem.Name = "registrarSalidaToolStripMenuItem";
            this.registrarSalidaToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.registrarSalidaToolStripMenuItem.Text = "RegistrarSalida";
            this.registrarSalidaToolStripMenuItem.Click += new System.EventHandler(this.registrarSalidaToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // cboMedico
            // 
            this.cboMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMedico.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(26, 105);
            this.cboMedico.Margin = new System.Windows.Forms.Padding(2);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(283, 29);
            this.cboMedico.TabIndex = 105;
            // 
            // txtPaciente
            // 
            this.txtPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaciente.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.Location = new System.Drawing.Point(26, 170);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(283, 27);
            this.txtPaciente.TabIndex = 106;
            // 
            // frmCirugias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 573);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.cboMedico);
            this.Controls.Add(this.dgvCirugias);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.rtxDescripcion);
            this.Controls.Add(this.cboSala);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.dgvPacientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCirugias";
            this.Text = "Cirugias";
            this.Load += new System.EventHandler(this.frmCirugias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCirugias)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPacientes;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSala;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxDescripcion;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.DataGridView dgvCirugias;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem registrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarEntradaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarSalidaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.TextBox txtPaciente;
    }
}
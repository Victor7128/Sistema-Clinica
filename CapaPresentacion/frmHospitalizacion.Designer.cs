﻿namespace CapaPresentacion
{
    partial class frmHospitalizacion
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
            this.components = new System.ComponentModel.Container();
            this.dgvHospitalizacion = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnRegistrarEntrada = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboEstadia = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboCamilla = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboHabitacion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.cboMedico = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombrePacienteH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitalizacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHospitalizacion
            // 
            this.dgvHospitalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitalizacion.Location = new System.Drawing.Point(12, 317);
            this.dgvHospitalizacion.Name = "dgvHospitalizacion";
            this.dgvHospitalizacion.Size = new System.Drawing.Size(803, 253);
            this.dgvHospitalizacion.TabIndex = 36;
            this.dgvHospitalizacion.SelectionChanged += new System.EventHandler(this.dgvHospitalizacion_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 39);
            this.label1.TabIndex = 41;
            this.label1.Text = "HOSPITALIZACIÓN";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.lblHora.Location = new System.Drawing.Point(731, 38);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(64, 23);
            this.lblHora.TabIndex = 44;
            this.lblHora.Text = "HORA";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.lblFecha.Location = new System.Drawing.Point(422, 39);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(72, 22);
            this.lblFecha.TabIndex = 45;
            this.lblFecha.Text = "FECHA";
            // 
            // btnRegistrarEntrada
            // 
            this.btnRegistrarEntrada.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRegistrarEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarEntrada.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarEntrada.ForeColor = System.Drawing.Color.Black;
            this.btnRegistrarEntrada.Location = new System.Drawing.Point(590, 91);
            this.btnRegistrarEntrada.Name = "btnRegistrarEntrada";
            this.btnRegistrarEntrada.Size = new System.Drawing.Size(170, 41);
            this.btnRegistrarEntrada.TabIndex = 55;
            this.btnRegistrarEntrada.Text = "Registrar Entrada";
            this.btnRegistrarEntrada.UseVisualStyleBackColor = false;
            this.btnRegistrarEntrada.Click += new System.EventHandler(this.btnRegistrarEntrada_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(978, 455);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 21);
            this.label9.TabIndex = 61;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(919, 455);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 21);
            this.label10.TabIndex = 60;
            this.label10.Text = "Total:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRegistrarSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSalida.ForeColor = System.Drawing.Color.Black;
            this.btnRegistrarSalida.Location = new System.Drawing.Point(590, 185);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(170, 41);
            this.btnRegistrarSalida.TabIndex = 67;
            this.btnRegistrarSalida.Text = "Registrar Salida";
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnGuardarCambios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarCambios.Location = new System.Drawing.Point(590, 138);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(170, 41);
            this.btnGuardarCambios.TabIndex = 66;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboEstadia);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cboCamilla);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnRegistrarSalida);
            this.groupBox1.Controls.Add(this.cboHabitacion);
            this.groupBox1.Controls.Add(this.btnGuardarCambios);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.btnRegistrarEntrada);
            this.groupBox1.Controls.Add(this.cboMedico);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombrePacienteH);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(803, 235);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrar Paciente";
            // 
            // cboEstadia
            // 
            this.cboEstadia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstadia.FormattingEnabled = true;
            this.cboEstadia.Location = new System.Drawing.Point(442, 56);
            this.cboEstadia.Name = "cboEstadia";
            this.cboEstadia.Size = new System.Drawing.Size(88, 29);
            this.cboEstadia.TabIndex = 81;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label14.Location = new System.Drawing.Point(438, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 21);
            this.label14.TabIndex = 80;
            this.label14.Text = "Estadía";
            // 
            // cboCamilla
            // 
            this.cboCamilla.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCamilla.FormattingEnabled = true;
            this.cboCamilla.Location = new System.Drawing.Point(437, 125);
            this.cboCamilla.Name = "cboCamilla";
            this.cboCamilla.Size = new System.Drawing.Size(88, 29);
            this.cboCamilla.TabIndex = 79;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label8.Location = new System.Drawing.Point(433, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 21);
            this.label8.TabIndex = 78;
            this.label8.Text = "Camilla";
            // 
            // cboHabitacion
            // 
            this.cboHabitacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboHabitacion.FormattingEnabled = true;
            this.cboHabitacion.Location = new System.Drawing.Point(565, 56);
            this.cboHabitacion.Name = "cboHabitacion";
            this.cboHabitacion.Size = new System.Drawing.Size(218, 29);
            this.cboHabitacion.TabIndex = 77;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(561, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 21);
            this.label7.TabIndex = 76;
            this.label7.Text = "Tipo de habitación";
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(307, 126);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(116, 29);
            this.comboBox3.TabIndex = 75;
            // 
            // cboMedico
            // 
            this.cboMedico.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMedico.FormattingEnabled = true;
            this.cboMedico.Location = new System.Drawing.Point(17, 125);
            this.cboMedico.Name = "cboMedico";
            this.cboMedico.Size = new System.Drawing.Size(253, 29);
            this.cboMedico.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(13, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 71;
            this.label5.Text = "Medico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(304, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 21);
            this.label4.TabIndex = 70;
            this.label4.Text = "Habitación";
            // 
            // txtDNI
            // 
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNI.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Location = new System.Drawing.Point(306, 55);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(115, 27);
            this.txtDNI.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(302, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 21);
            this.label3.TabIndex = 68;
            this.label3.Text = "Dni";
            // 
            // txtNombrePacienteH
            // 
            this.txtNombrePacienteH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombrePacienteH.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePacienteH.Location = new System.Drawing.Point(17, 56);
            this.txtNombrePacienteH.Name = "txtNombrePacienteH";
            this.txtNombrePacienteH.Size = new System.Drawing.Size(253, 27);
            this.txtNombrePacienteH.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(13, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 66;
            this.label2.Text = "Nombre";
            // 
            // frmHospitalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 573);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHospitalizacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHospitalizacion";
            this.Text = "Registros";
            this.Load += new System.EventHandler(this.frmHospitalizacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitalizacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHospitalizacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnRegistrarEntrada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboEstadia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCamilla;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboHabitacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox cboMedico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombrePacienteH;
        private System.Windows.Forms.Label label2;
    }
}
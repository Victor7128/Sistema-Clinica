namespace CapaPresentacion
{
    partial class frmUsuarios
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBuscarUsuario = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnGuardarUsuarios = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Administrar Usuarios";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboRol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtClave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.btnAgregarUsuario);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNombreUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.groupBox1.Location = new System.Drawing.Point(19, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 174);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información del Usuario";
            // 
            // cboRol
            // 
            this.cboRol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRol.FormattingEnabled = true;
            this.cboRol.Location = new System.Drawing.Point(23, 118);
            this.cboRol.Name = "cboRol";
            this.cboRol.Size = new System.Drawing.Size(170, 29);
            this.cboRol.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rol en la Clinica:";
            // 
            // txtClave
            // 
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClave.Location = new System.Drawing.Point(325, 120);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(153, 27);
            this.txtClave.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(321, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(325, 51);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(153, 27);
            this.txtUsuario.TabIndex = 15;
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnAgregarUsuario.Location = new System.Drawing.Point(495, 51);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(94, 96);
            this.btnAgregarUsuario.TabIndex = 25;
            this.btnAgregarUsuario.Text = "Nuevo";
            this.btnAgregarUsuario.UseVisualStyleBackColor = false;
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(321, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Usuario:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(23, 51);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(277, 27);
            this.txtNombreUsuario.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombres y Apellidos:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBuscarUsuario);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgvUsuarios);
            this.groupBox2.Controls.Add(this.btnGuardarUsuarios);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.groupBox2.Location = new System.Drawing.Point(19, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(796, 321);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista de Usuarios";
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(306, 22);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(132, 30);
            this.btnBuscarUsuario.TabIndex = 29;
            this.btnBuscarUsuario.Text = "Buscar";
            this.btnBuscarUsuario.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(90, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 27);
            this.textBox1.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Buscar:";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 58);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(784, 257);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUsuarios_CellFormatting);
            this.dgvUsuarios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellValueChanged);
            // 
            // btnGuardarUsuarios
            // 
            this.btnGuardarUsuarios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardarUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarUsuarios.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarUsuarios.Location = new System.Drawing.Point(603, 22);
            this.btnGuardarUsuarios.Name = "btnGuardarUsuarios";
            this.btnGuardarUsuarios.Size = new System.Drawing.Size(175, 30);
            this.btnGuardarUsuarios.TabIndex = 28;
            this.btnGuardarUsuarios.Text = "Guardar Cambios";
            this.btnGuardarUsuarios.UseVisualStyleBackColor = false;
            this.btnGuardarUsuarios.Click += new System.EventHandler(this.btnGuardarUsuarios_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtIdUsuario);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnEliminarUsuario);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.groupBox3.Location = new System.Drawing.Point(630, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(185, 174);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eliminar Usuario";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.Location = new System.Drawing.Point(14, 60);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(153, 27);
            this.txtIdUsuario.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 21);
            this.label12.TabIndex = 28;
            this.label12.Text = "Id Usuario:";
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuario.ForeColor = System.Drawing.Color.Black;
            this.btnEliminarUsuario.Location = new System.Drawing.Point(14, 100);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(132, 30);
            this.btnEliminarUsuario.TabIndex = 30;
            this.btnEliminarUsuario.Text = "Eliminar";
            this.btnEliminarUsuario.UseVisualStyleBackColor = false;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnGuardarUsuarios;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnBuscarUsuario;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
    }
}
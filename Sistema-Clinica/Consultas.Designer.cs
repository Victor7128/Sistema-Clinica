namespace Sistema_Clinica
{
    partial class Consultas
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
            this.dgvPaciente = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellidoBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDNIBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "BUSCAR PACIENTE";
            // 
            // dgvPaciente
            // 
            this.dgvPaciente.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.dgvPaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaciente.Location = new System.Drawing.Point(19, 156);
            this.dgvPaciente.Name = "dgvPaciente";
            this.dgvPaciente.Size = new System.Drawing.Size(615, 315);
            this.dgvPaciente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "APELLIDO";
            // 
            // txtApellidoBuscar
            // 
            this.txtApellidoBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoBuscar.Location = new System.Drawing.Point(19, 101);
            this.txtApellidoBuscar.Name = "txtApellidoBuscar";
            this.txtApellidoBuscar.Size = new System.Drawing.Size(190, 20);
            this.txtApellidoBuscar.TabIndex = 3;
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.Location = new System.Drawing.Point(502, 77);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(132, 44);
            this.btnBuscarPaciente.TabIndex = 4;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(68)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(239, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "DNI";
            // 
            // txtDNIBuscar
            // 
            this.txtDNIBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDNIBuscar.Location = new System.Drawing.Point(243, 100);
            this.txtDNIBuscar.Name = "txtDNIBuscar";
            this.txtDNIBuscar.Size = new System.Drawing.Size(190, 20);
            this.txtDNIBuscar.TabIndex = 6;
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 504);
            this.Controls.Add(this.txtDNIBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscarPaciente);
            this.Controls.Add(this.txtApellidoBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPaciente);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Consultas";
            this.Text = "Consultas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellidoBuscar;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDNIBuscar;
    }
}
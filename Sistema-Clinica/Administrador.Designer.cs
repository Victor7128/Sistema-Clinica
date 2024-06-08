namespace Sistema_Clinica
{
    partial class Administrador
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
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAgnCita = new System.Windows.Forms.Button();
            this.btnRegistrarPac = new System.Windows.Forms.Button();
            this.btnHabitaciones = new System.Windows.Forms.Button();
            this.btnOperaciones = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vista General";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 136);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(541, 258);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnAgnCita
            // 
            this.btnAgnCita.Location = new System.Drawing.Point(41, 71);
            this.btnAgnCita.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgnCita.Name = "btnAgnCita";
            this.btnAgnCita.Size = new System.Drawing.Size(118, 32);
            this.btnAgnCita.TabIndex = 3;
            this.btnAgnCita.Text = "Agendar Cita";
            this.btnAgnCita.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarPac
            // 
            this.btnRegistrarPac.Location = new System.Drawing.Point(197, 71);
            this.btnRegistrarPac.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrarPac.Name = "btnRegistrarPac";
            this.btnRegistrarPac.Size = new System.Drawing.Size(118, 32);
            this.btnRegistrarPac.TabIndex = 4;
            this.btnRegistrarPac.Text = "Registrar Paciente";
            this.btnRegistrarPac.UseVisualStyleBackColor = true;
            // 
            // btnHabitaciones
            // 
            this.btnHabitaciones.Location = new System.Drawing.Point(346, 71);
            this.btnHabitaciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnHabitaciones.Name = "btnHabitaciones";
            this.btnHabitaciones.Size = new System.Drawing.Size(118, 32);
            this.btnHabitaciones.TabIndex = 5;
            this.btnHabitaciones.Text = "Habitaciones";
            this.btnHabitaciones.UseVisualStyleBackColor = true;
            // 
            // btnOperaciones
            // 
            this.btnOperaciones.Location = new System.Drawing.Point(41, 431);
            this.btnOperaciones.Margin = new System.Windows.Forms.Padding(2);
            this.btnOperaciones.Name = "btnOperaciones";
            this.btnOperaciones.Size = new System.Drawing.Size(118, 32);
            this.btnOperaciones.TabIndex = 6;
            this.btnOperaciones.Text = "Ir a Operaciones";
            this.btnOperaciones.UseVisualStyleBackColor = true;
            // 
            // Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 504);
            this.Controls.Add(this.btnOperaciones);
            this.Controls.Add(this.btnHabitaciones);
            this.Controls.Add(this.btnRegistrarPac);
            this.Controls.Add(this.btnAgnCita);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Administrador";
            this.Text = "Administrador";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgnCita;
        private System.Windows.Forms.Button btnRegistrarPac;
        private System.Windows.Forms.Button btnHabitaciones;
        private System.Windows.Forms.Button btnOperaciones;
    }
}
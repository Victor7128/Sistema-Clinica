namespace CapaPresentacion
{
    partial class frmReportes
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
            this.dgvHospitalizacion = new System.Windows.Forms.DataGridView();
            this.btnHospitalizacion = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCirugias = new System.Windows.Forms.DataGridView();
            this.btnCirugias = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitalizacion)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCirugias)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORTES";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHospitalizacion);
            this.groupBox1.Controls.Add(this.btnHospitalizacion);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(19, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(788, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generar Reporte Hospitalizacion";
            // 
            // dgvHospitalizacion
            // 
            this.dgvHospitalizacion.AllowUserToAddRows = false;
            this.dgvHospitalizacion.AllowUserToDeleteRows = false;
            this.dgvHospitalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitalizacion.Location = new System.Drawing.Point(10, 25);
            this.dgvHospitalizacion.Name = "dgvHospitalizacion";
            this.dgvHospitalizacion.ReadOnly = true;
            this.dgvHospitalizacion.Size = new System.Drawing.Size(585, 95);
            this.dgvHospitalizacion.TabIndex = 9;
            this.dgvHospitalizacion.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHospitalizacion_CellFormatting);
            // 
            // btnHospitalizacion
            // 
            this.btnHospitalizacion.BackColor = System.Drawing.Color.Blue;
            this.btnHospitalizacion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHospitalizacion.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnHospitalizacion.Location = new System.Drawing.Point(628, 43);
            this.btnHospitalizacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnHospitalizacion.Name = "btnHospitalizacion";
            this.btnHospitalizacion.Size = new System.Drawing.Size(135, 45);
            this.btnHospitalizacion.TabIndex = 8;
            this.btnHospitalizacion.Text = "Generar";
            this.btnHospitalizacion.UseVisualStyleBackColor = false;
            this.btnHospitalizacion.Click += new System.EventHandler(this.btnHospitalizacion_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCirugias);
            this.groupBox2.Controls.Add(this.btnCirugias);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(19, 235);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(788, 144);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generar Reporte Cirugias";
            // 
            // dgvCirugias
            // 
            this.dgvCirugias.AllowUserToAddRows = false;
            this.dgvCirugias.AllowUserToDeleteRows = false;
            this.dgvCirugias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCirugias.Location = new System.Drawing.Point(10, 25);
            this.dgvCirugias.Name = "dgvCirugias";
            this.dgvCirugias.ReadOnly = true;
            this.dgvCirugias.Size = new System.Drawing.Size(585, 95);
            this.dgvCirugias.TabIndex = 9;
            this.dgvCirugias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCirugias_CellFormatting);
            // 
            // btnCirugias
            // 
            this.btnCirugias.BackColor = System.Drawing.Color.Blue;
            this.btnCirugias.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCirugias.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnCirugias.Location = new System.Drawing.Point(628, 46);
            this.btnCirugias.Margin = new System.Windows.Forms.Padding(2);
            this.btnCirugias.Name = "btnCirugias";
            this.btnCirugias.Size = new System.Drawing.Size(135, 45);
            this.btnCirugias.TabIndex = 8;
            this.btnCirugias.Text = "Generar";
            this.btnCirugias.UseVisualStyleBackColor = false;
            this.btnCirugias.Click += new System.EventHandler(this.btnCirugias_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvHistorial);
            this.groupBox3.Controls.Add(this.btnHistorial);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(19, 398);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(788, 151);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generar Reporte Historial";
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(10, 25);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.Size = new System.Drawing.Size(585, 107);
            this.dgvHistorial.TabIndex = 9;
            this.dgvHistorial.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHistorial_CellFormatting);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.Blue;
            this.btnHistorial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.GhostWhite;
            this.btnHistorial.Location = new System.Drawing.Point(628, 56);
            this.btnHistorial.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(135, 45);
            this.btnHistorial.TabIndex = 8;
            this.btnHistorial.Text = "Generar";
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 573);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitalizacion)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCirugias)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHospitalizacion;
        private System.Windows.Forms.DataGridView dgvHospitalizacion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCirugias;
        private System.Windows.Forms.Button btnCirugias;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnHistorial;
    }
}
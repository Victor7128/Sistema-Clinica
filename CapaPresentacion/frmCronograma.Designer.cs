namespace CapaPresentacion
{
    partial class frmCronograma
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
            this.dgvCirugias = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarCirugias = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCirugias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(30, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cronograma";
            // 
            // dgvCirugias
            // 
            this.dgvCirugias.AllowUserToAddRows = false;
            this.dgvCirugias.AllowUserToDeleteRows = false;
            this.dgvCirugias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCirugias.Location = new System.Drawing.Point(256, 213);
            this.dgvCirugias.Name = "dgvCirugias";
            this.dgvCirugias.ReadOnly = true;
            this.dgvCirugias.RowHeadersWidth = 51;
            this.dgvCirugias.Size = new System.Drawing.Size(354, 323);
            this.dgvCirugias.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "yyyy-MM-dd";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(256, 88);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(177, 20);
            this.dtpFecha.TabIndex = 3;
            this.dtpFecha.Value = new System.DateTime(2024, 7, 7, 0, 0, 0, 0);
            // 
            // btnBuscarCirugias
            // 
            this.btnBuscarCirugias.Location = new System.Drawing.Point(487, 88);
            this.btnBuscarCirugias.Name = "btnBuscarCirugias";
            this.btnBuscarCirugias.Size = new System.Drawing.Size(123, 65);
            this.btnBuscarCirugias.TabIndex = 4;
            this.btnBuscarCirugias.Text = "Cirugias Disponibles";
            this.btnBuscarCirugias.UseVisualStyleBackColor = true;
            this.btnBuscarCirugias.Click += new System.EventHandler(this.btnBuscarCirugias_Click);
            // 
            // frmCronograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 573);
            this.Controls.Add(this.btnBuscarCirugias);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.dgvCirugias);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCronograma";
            this.Text = "Cronograma";
            this.Load += new System.EventHandler(this.frmCronograma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCirugias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCirugias;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnBuscarCirugias;
    }
}
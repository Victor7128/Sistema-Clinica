using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ExcelDataReader;
using System.Runtime.Remoting;
using SpreadsheetLight;

using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmReportes : Form
    {
        EntidadHospitalizacion objent = new EntidadHospitalizacion();
        EntidadCirugia objenti = new EntidadCirugia();
        NegocioHospitalizacion objneg = new NegocioHospitalizacion();
        NegocioCirugia objnego = new NegocioCirugia();
        NegocioHistorial objnegoci = new NegocioHistorial();

        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            dgvHospitalizacion.DataSource = objneg.N_listar_pacientes();

            dgvHospitalizacion.Columns["Paciente"].Width = 250;
            dgvHospitalizacion.Columns["Direccion"].Width = 280;
            dgvHospitalizacion.Columns["TipoHabitacion"].Width = 230;
            dgvHospitalizacion.CellFormatting += dgvHospitalizacion_CellFormatting;

            dgvCirugias.DataSource = objnego.N_listarCirugias();

            dgvCirugias.Columns["Paciente"].Width = 250;
            dgvCirugias.Columns["MedicoAsignado"].Width = 250;
            dgvCirugias.Columns["DescripcionCirugia"].Width = 280;
            dgvCirugias.CellFormatting += dgvCirugias_CellFormatting;

            dgvHistorial.DataSource = objnegoci.N_listarHistorial();

            dgvHistorial.Columns["Paciente"].Width = 250;
            dgvHistorial.Columns["Direccion"].Width = 280;
            dgvHistorial.Columns["MedicoAsignado"].Width = 250;
            dgvHistorial.Columns["Cirugia"].Width = 280;
            dgvHistorial.CellFormatting += dgvHistorial_CellFormatting;
        }

        private void btnHospitalizacion_Click(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.FontSize = 18;

            int iC = 1;
            int iR = 1;
            foreach (DataGridViewColumn column in dgvHospitalizacion.Columns)
            {
                sl.SetCellValue(iR, iC, column.HeaderText);
                sl.SetCellStyle(iR, iC, style);
                iC++;
            }

            iR = 2;
            foreach (DataGridViewRow row in dgvHospitalizacion.Rows)
            {
                iC = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    object cellValue = cell.Value;

                    if (cellValue is DateTime dateTimeValue)
                    {
                        if (dateTimeValue.TimeOfDay.TotalSeconds == 0)
                        {
                            sl.SetCellValue(iR, iC, dateTimeValue.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            sl.SetCellValue(iR, iC, dateTimeValue.ToString("HH:mm"));
                        }
                    }
                    else if (cellValue is TimeSpan timeSpanValue)
                    {
                        sl.SetCellValue(iR, iC, timeSpanValue.ToString(@"hh\:mm"));
                    }
                    else if (double.TryParse(cellValue?.ToString(), out double numericValue))
                    {
                        sl.SetCellValue(iR, iC, numericValue);
                    }
                    else
                    {
                        sl.SetCellValue(iR, iC, cellValue?.ToString() ?? string.Empty);
                    }

                    iC++;
                }
                iR++;
            }

            for (int col = 1; col <= dgvHospitalizacion.Columns.Count; col++)
            {
                sl.AutoFitColumn(col);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel Files|*.xlsx";
            saveFileDialog1.FileName = "ReporteHospitalizaciones.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sl.SaveAs(saveFileDialog1.FileName);
                    MessageBox.Show("Archivo generado con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCirugias_Click(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.FontSize = 18;

            int iC = 1;
            int iR = 1;
            foreach (DataGridViewColumn column in dgvCirugias.Columns)
            {
                sl.SetCellValue(iR, iC, column.HeaderText);
                sl.SetCellStyle(iR, iC, style);
                iC++;
            }

            iR = 2;
            foreach (DataGridViewRow row in dgvCirugias.Rows)
            {
                iC = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    object cellValue = cell.Value;

                    if (cellValue is DateTime dateTimeValue)
                    {
                        if (dateTimeValue.TimeOfDay.TotalSeconds == 0)
                        {
                            sl.SetCellValue(iR, iC, dateTimeValue.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            sl.SetCellValue(iR, iC, dateTimeValue.ToString("HH:mm"));
                        }
                    }
                    else if (cellValue is TimeSpan timeSpanValue)
                    {
                        sl.SetCellValue(iR, iC, timeSpanValue.ToString(@"hh\:mm"));
                    }
                    else if (double.TryParse(cellValue?.ToString(), out double numericValue))
                    {
                        sl.SetCellValue(iR, iC, numericValue);
                    }
                    else
                    {
                        sl.SetCellValue(iR, iC, cellValue?.ToString() ?? string.Empty);
                    }

                    iC++;
                }
                iR++;
            }

            for (int col = 1; col <= dgvCirugias.Columns.Count; col++)
            {
                sl.AutoFitColumn(col);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel Files|*.xlsx";
            saveFileDialog1.FileName = "ReporteCirugias.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sl.SaveAs(saveFileDialog1.FileName);
                    MessageBox.Show("Archivo generado con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            SLDocument sl = new SLDocument();
            SLStyle style = new SLStyle();
            style.Font.FontSize = 18;

            int iC = 1;
            int iR = 1;
            foreach (DataGridViewColumn column in dgvHistorial.Columns)
            {
                sl.SetCellValue(iR, iC, column.HeaderText);
                sl.SetCellStyle(iR, iC, style);
                iC++;
            }

            iR = 2;
            foreach (DataGridViewRow row in dgvHistorial.Rows)
            {
                iC = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    object cellValue = cell.Value;

                    if (cellValue is DateTime dateTimeValue)
                    {
                        if (dateTimeValue.TimeOfDay.TotalSeconds == 0)
                        {
                            sl.SetCellValue(iR, iC, dateTimeValue.ToString("dd/MM/yyyy"));
                        }
                        else
                        {
                            sl.SetCellValue(iR, iC, dateTimeValue.ToString("HH:mm"));
                        }
                    }
                    else if (cellValue is TimeSpan timeSpanValue)
                    {
                        sl.SetCellValue(iR, iC, timeSpanValue.ToString(@"hh\:mm"));
                    }
                    else if (double.TryParse(cellValue?.ToString(), out double numericValue))
                    {
                        sl.SetCellValue(iR, iC, numericValue);
                    }
                    else
                    {
                        sl.SetCellValue(iR, iC, cellValue?.ToString() ?? string.Empty);
                    }

                    iC++;
                }
                iR++;
            }

            for (int col = 1; col <= dgvHistorial.Columns.Count; col++)
            {
                sl.AutoFitColumn(col);
            }

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel Files|*.xlsx";
            saveFileDialog1.FileName = "ReporteHistorial.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sl.SaveAs(saveFileDialog1.FileName);
                    MessageBox.Show("Archivo generado con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvHospitalizacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvHospitalizacion.Columns[e.ColumnIndex];
                if (column.Name == "HoraIngreso" || column.Name == "HoraSalida")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (e.Value is TimeSpan)
                        {
                            TimeSpan hora = (TimeSpan)e.Value;
                            e.Value = hora.ToString(@"hh\:mm");
                        }
                    }
                }
            }
        }

        private void dgvCirugias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvCirugias.Columns[e.ColumnIndex];
                if (column.Name == "HoraCirugia" || column.Name == "HoraEntradaSala" || column.Name == "HoraSalidaSala")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (e.Value is TimeSpan)
                        {
                            TimeSpan hora = (TimeSpan)e.Value;
                            e.Value = hora.ToString(@"hh\:mm");
                        }
                    }
                }
            }
        }

        private void dgvHistorial_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridViewColumn column = dgvHistorial.Columns[e.ColumnIndex];
                if (column.Name == "HoraCirugia" || column.Name == "CirugiaEntrada" || column.Name == "CirugiaSalida" || column.Name == "HoraEntradaHospitalizacion" || column.Name == "HoraSalidaHospitalizacion")
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if (e.Value is TimeSpan)
                        {
                            TimeSpan hora = (TimeSpan)e.Value;
                            e.Value = hora.ToString(@"hh\:mm");
                        }
                    }
                }
            }
        }
    }
}

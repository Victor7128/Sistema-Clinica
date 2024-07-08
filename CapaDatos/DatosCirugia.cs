﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CapaEntidad;
using System.Xml.Linq;
using System.Xml;

namespace CapaDatos
{
    public class DatosCirugia
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public static DataTable ObtenerPacientes(string apellido)
        {
            DataTable dtPacientes = new DataTable();
            using (SqlConnection cn = new SqlConnection(Conexion.cn))
            {
                string query = "SELECT IdPaciente, Nombre, DNI FROM Pacientes WHERE Nombre LIKE @Nombre + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, cn);
                adapter.SelectCommand.Parameters.AddWithValue("@Nombre", apellido);

                try
                {
                    cn.Open();
                    adapter.Fill(dtPacientes);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener pacientes.", ex);
                }
            }
            return dtPacientes;
        }
    }
}

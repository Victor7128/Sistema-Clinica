using System;
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
    public class DatosHospitalizacion        
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_pacientes()
        {
            SqlCommand cmd = new SqlCommand("sp_ListarPacientesHospitalizados", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;            
        }

        public DataTable D_listar_estadias()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_estadias", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_tipo_habitacion()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_tipo_habitacion", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_habitaciones(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_habitaciones", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdTipoHabitacion", obje.IdTipoHabitacion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_camillas(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_camillas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("IdHabitacion", obje.IdHabitacion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_genero()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_genero", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listarCamillasTodas(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_listar_camillas_todas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdHabitacion", obje.IdHabitacion);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_buscar_pacientes(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_BuscarPacientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;           
        }

        public string D_Registrar_pacientes(EntidadHospitalizacion obje)
        {           
            string accion = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_paciente_hospitalizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
                cmd.Parameters.AddWithValue("@DNI", obje.DNI);
                cmd.Parameters.AddWithValue("@FechaNacimiento", obje.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Telefono", obje.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", obje.Direccion);
                cmd.Parameters.AddWithValue("@Genero", obje.IdGenero);
                cmd.Parameters.AddWithValue("@TipoHabitacion", obje.IdTipoHabitacion);
                cmd.Parameters.AddWithValue("@Habitacion", obje.IdHabitacion);
                cmd.Parameters.AddWithValue("@Camilla", obje.IdCamilla);
                cmd.Parameters.AddWithValue("@Estadia", obje.IdEstadia);
                SqlParameter accionParam = new SqlParameter("@accion", SqlDbType.VarChar, 50);
                accionParam.Direction = ParameterDirection.InputOutput;
                accionParam.Value = obje.accion;
                cmd.Parameters.Add(accionParam);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();
                cn.Close();
                if (accion == "DNI_EXISTE")
                {
                    throw new Exception("El DNI ingresado ya está registrado.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return accion;
        }

        public string D_Modificar_pacientes(EntidadHospitalizacion obje)
        {
            string accion = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_modificar_paciente_hospitalizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", obje.Codigo);
                cmd.Parameters.AddWithValue("@nombre", obje.Nombre);
                cmd.Parameters.AddWithValue("@DNI", obje.DNI);
                cmd.Parameters.AddWithValue("@FechaNacimiento", obje.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Telefono", obje.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", obje.Direccion);
                cmd.Parameters.AddWithValue("@Genero", obje.IdGenero);
                cmd.Parameters.AddWithValue("@TipoHabitacion", obje.IdTipoHabitacion);
                cmd.Parameters.AddWithValue("@Habitacion", obje.IdHabitacion);
                cmd.Parameters.AddWithValue("@Camilla", obje.IdCamilla);
                cmd.Parameters.AddWithValue("@Estadia", obje.IdEstadia);
                SqlParameter accionParam = new SqlParameter("@accion", SqlDbType.VarChar, 50);
                accionParam.Direction = ParameterDirection.InputOutput;
                accionParam.Value = obje.accion;
                cmd.Parameters.Add(accionParam);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();
                cn.Close();
                if (accion == "DNI_EXISTE")
                {
                    throw new Exception("El DNI ingresado ya está registrado.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return accion;
        }

        public string D_Salida_pacientes(EntidadHospitalizacion obje)
        {
            string accion = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_registrar_salida_hospitalizacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", obje.Codigo);
                SqlParameter accionParam = new SqlParameter("@accion", SqlDbType.VarChar, 50);
                accionParam.Direction = ParameterDirection.InputOutput;
                accionParam.Value = obje.accion;
                cmd.Parameters.Add(accionParam);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();
                cn.Close();
                if (accion == "DNI_EXISTE")
                {
                    throw new Exception("El DNI ingresado ya está registrado.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return accion;
        }

        public string D_Eliminar_pacientes(EntidadHospitalizacion obje)
        {
            string accion = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_eliminar_paciente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", obje.Codigo);
                SqlParameter accionParam = new SqlParameter("@accion", SqlDbType.VarChar, 50);
                accionParam.Direction = ParameterDirection.InputOutput;
                accionParam.Value = obje.accion;
                cmd.Parameters.Add(accionParam);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();
                cn.Close();
                if (accion == "DNI_EXISTE")
                {
                    throw new Exception("El DNI ingresado ya está registrado.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            return accion;
        }

        public DataTable D_BuscarPacientesConsulta(EntidadHospitalizacion obje)
        {
            SqlCommand cmd = new SqlCommand("sp_BuscarPacientesConsulta", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable D_listar_pacientes_consulta()
        {
            SqlCommand cmd = new SqlCommand("sp_listar_pacientes_consultas", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}

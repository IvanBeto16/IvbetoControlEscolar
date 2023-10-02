using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetAll";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Uso de DataAdapter
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tablaAlumno = new DataTable();
                    adapter.Fill(tablaAlumno);

                    if (tablaAlumno.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (DataRow row in tablaAlumno.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();

                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros de alumnos";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoAdd";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[3];
                    param[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    param[0].Value = alumno.Nombre.ToString();
                    param[1] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    param[1].Value = alumno.ApellidoPaterno.ToString();
                    param[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    param[2].Value = alumno.ApellidoMaterno.ToString();

                    cmd.Parameters.AddRange(param);
                    cmd.Connection.Open();

                    int insersiones = cmd.ExecuteNonQuery();
                    if(insersiones > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch(Exception ex)
            {
                result.Correct =false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoUpdate";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[4];
                    param[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    param[0].Value = alumno.IdAlumno.ToString();
                    param[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    param[1].Value = alumno.Nombre.ToString();
                    param[2] = new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar);
                    param[2].Value = alumno.ApellidoPaterno.ToString();
                    param[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    param[3].Value = alumno.ApellidoMaterno.ToString();

                    cmd.Parameters.AddRange(param);
                    cmd.Connection.Open();

                    int actualizaciones = cmd.ExecuteNonQuery();
                    if(actualizaciones > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el alumno";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoDelete";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    param[0].Value = alumno.IdAlumno;

                    cmd.Parameters.AddRange(param);
                    cmd.Connection.Open();

                    int eliminaciones = cmd.ExecuteNonQuery();
                    if(eliminaciones > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar el alumno";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AlumnoGetById";
                    SqlCommand cmd = new SqlCommand(query, context);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    param[0].Value = idAlumno;
                    cmd.Parameters.AddRange(param);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tablaAlumno = new DataTable();
                    adapter.Fill(tablaAlumno);

                    if (tablaAlumno.Rows.Count > 0)
                    {
                        result.Object = new object();
                        foreach (DataRow row in tablaAlumno.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();

                            result.Object = alumno;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró al alumno";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result; ;
        }
    }
}

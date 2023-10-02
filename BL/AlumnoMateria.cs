using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {

        public static ML.Result Add(int idAlumno, int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.AlumnoMateriaAdd(idAlumno, idMateria, filasInsertadas);
                    if((int)filasInsertadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int idAlumno, int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.AlumnoMateriaDelete(idAlumno,idMateria,filasEliminadas);
                    if((int)filasEliminadas.Value > 0)
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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetMateriaAsignada(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    ML.AlumnoMateria alumn = new ML.AlumnoMateria();
                    alumn.Alumno = new ML.Alumno();
                    alumn.Alumno.IdAlumno = idAlumno;
                    var query = context.GetMateriaAsignada(alumn.Alumno.IdAlumno);
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.AlumnoMateria auxiliar = new ML.AlumnoMateria();
                            auxiliar.Materia = new ML.Materia();

                            auxiliar.Materia.IdMateria = item.IdMateria;
                            auxiliar.Materia.Nombre = item.Nombre;
                            auxiliar.Materia.Costo = Convert.ToDouble(item.Costo);

                            result.Objects.Add(auxiliar);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No tiene materias este alumno";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result GetMateriaNoAsignada(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    var query = context.GetMateriaNoAsignada(idAlumno);
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.AlumnoMateria alumn = new ML.AlumnoMateria();
                            alumn.Materia = new ML.Materia();

                            alumn.Materia.IdMateria = item.IdMateria;
                            alumn.Materia.Nombre = item.Nombre;
                            alumn.Materia.Costo = Convert.ToDouble(item.Costo);

                            result.Objects.Add(alumn);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}

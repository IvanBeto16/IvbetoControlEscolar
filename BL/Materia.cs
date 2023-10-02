using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
            {
                var query = context.MateriaGetAll();
                if(query != null)
                {
                    result.Objects = new List<object>();
                    foreach(var obj in query)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = obj.IdMateria;
                        materia.Nombre = obj.Nombre;
                        materia.Costo = Double.Parse(obj.Costo.ToString());

                        result.Objects.Add(materia);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron materias registradas";
                }
            }
            return result;
        }

        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
            {
                var query = context.MateriaGetById(idMateria);
                if(query != null)
                {
                    result.Object = new object();
                    foreach(var obj in query)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = obj.IdMateria;
                        materia.Nombre = obj.Nombre.ToString();
                        materia.Costo = Double.Parse(obj.Costo.ToString());

                        result.Object = materia;
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontró la materia";
                }
                return result;
            }
        }


        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.MateriaAdd(materia.Nombre, materia.Costo, filasInsertadas);

                    if ((int)filasInsertadas.Value > 0)
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

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.MateriaUpdate(materia.IdMateria, materia.Nombre, materia.Costo, filasActualizadas);

                    if((int)filasActualizadas.Value > 0)
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

        public static ML.Result Delete(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoControlEscolarEntities context = new DL.IvbetoControlEscolarEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.MateriaDelete(idMateria, filasEliminadas);

                    if((int)filasEliminadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch( Exception ex) 
            { 
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}

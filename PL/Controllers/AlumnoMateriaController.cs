using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        // GET: AlumnoMateria
        public ActionResult MateriasAsignadas(int idAlumno)
        {
            ML.AlumnoMateria aux = new ML.AlumnoMateria();
            aux.Alumno = new ML.Alumno();
            aux.Alumno.IdAlumno = idAlumno;
            aux.Materia = new ML.Materia();
            aux.Materia.Materias = new List<object>();

            ML.Result result = BL.AlumnoMateria.GetMateriaAsignada(aux.Alumno.IdAlumno.Value);
            if (result.Correct)
            {
                aux.Materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Message = "No se han cargado las materias";
            }
            return View(aux);
        }


        [HttpPost]
        public ActionResult MateriasAsignadas(ML.AlumnoMateria aux)
        {
            aux.Alumno = new ML.Alumno();
            ML.Result result = BL.AlumnoMateria.GetMateriaAsignada(aux.Alumno.IdAlumno.Value);
            if (result.Correct)
            {
                aux.Materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Message = "No se han cargado las materias";
            }
            return View(aux);
        }

        [HttpGet]
        public ActionResult MateriasNoAsignadas(int idAlumno)
        {
            ML.AlumnoMateria aux = new ML.AlumnoMateria();
            aux.Alumno = new ML.Alumno();
            aux.Alumno.IdAlumno = idAlumno;
            aux.Materia = new ML.Materia();
            aux.Materia.Materias = new List<object>();

            ML.Result result = BL.AlumnoMateria.GetMateriaNoAsignada(aux.Alumno.IdAlumno.Value);
            if(result.Correct)
            {
                aux.Materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Message = "No se han cargado las materias";
            }
            return View(aux);
        }

        [HttpPost]
        public ActionResult MateriasNoAsignadas(ML.AlumnoMateria aux)
        {
            aux.Alumno = new ML.Alumno();
            aux.Materia = new ML.Materia();
            aux.Materia.Materias = new List<object>();

            ML.Result result = BL.AlumnoMateria.GetMateriaNoAsignada(aux.Alumno.IdAlumno.Value);
            if (result.Correct)
            {
                aux.Materia.Materias = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = "No se han cargado las materias";
            }
            return View(aux);
        }

        public ActionResult InscribirMaterias(int? idAlumno, List<int> idMaterias)
        {
            ML.AlumnoMateria aux = new ML.AlumnoMateria();
            aux.Alumno = new ML.Alumno();
            aux.Alumno.IdAlumno = idAlumno;
            
            foreach(int idmateria in  idMaterias)
            {
                aux.Materia.IdMateria = idmateria;
                ML.Result result = BL.AlumnoMateria.Add(aux.Alumno.IdAlumno.Value, aux.Materia.IdMateria);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha inscrito correctamente la materia al alumno";
                    ViewBag.idAlumno = aux.Alumno.IdAlumno;
                }
                else
                {
                    ViewBag.Message = "No se pudo inscribir la materia, ocurrió un error " + result.ErrorMessage;
                    ViewBag.idAlumno = aux.Alumno.IdAlumno;
                }
            }
            return PartialView("Modal");
        }
    }
}
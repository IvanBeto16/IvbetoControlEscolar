using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        [HttpGet]
        public ActionResult GetAllMateria()
        {
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(materia);
        }

        [HttpPost]
        public ActionResult GetAllMateria(ML.Materia materia)
        {
            materia.Materias = new List<object>();
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                materia.Materias = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(materia);
        }

        [HttpGet]
        public ActionResult Delete(int idMateria)
        {
            ML.Materia materia = new ML.Materia();
            materia.IdMateria = idMateria;
            ML.Result result = BL.Materia.Delete(materia.IdMateria);
            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el alumno seleccionado";
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el alumno" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Form(int? idMateria)
        {
            ML.Materia materia = new ML.Materia();
            if (idMateria != null) //Update
            {
                ML.Result result = BL.Alumno.GetById(idMateria.Value);
                if (result.Correct)
                {
                    materia = (ML.Materia)result.Object;
                    return View(materia);
                }
            }
            return View(materia);
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (materia.IdMateria == 0)
            {
                ML.Result result = BL.Materia.Add(materia);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha agregado exitosamente el alumno nuevo";
                }
                else
                {
                    ViewBag.Message = "No se ha podido agregar el alumno" + result.ErrorMessage;
                }
            }
            else
            {
                ML.Result result = BL.Materia.Update(materia);
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha actualizado exitosamente el alumno nuevo";
                }
                else
                {
                    ViewBag.Message = "No se ha podido actualizar el alumno" + result.ErrorMessage;
                }
            }
            return PartialView("Modal");
        }
    }
}
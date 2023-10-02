using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        [HttpGet]
        public ActionResult GetAllAlumno()
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = new List<object>();

            //Usaremos el Servicio web SOAP para llamar al metodo
            ServiceReferenceAlumno.AlumnoServiceClient service = new ServiceReferenceAlumno.AlumnoServiceClient();
            var result = service.GetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(alumno);
        }

        [HttpPost]
        public ActionResult GetAllAlumno(ML.Alumno alumno)
        {
            alumno.Alumnos = new List<object>();
            //ML.Result result = BL.Alumno.GetAll();

            //Servicio SOAP
            ServiceReferenceAlumno.AlumnoServiceClient service = new ServiceReferenceAlumno.AlumnoServiceClient();
            var result = service.GetAll();
            if(result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Delete(int idAlumno)
        {
            //ML.Alumno alumno = new ML.Alumno();
            //alumno.IdAlumno = idAlumno;
            //ML.Result result = BL.Alumno.Delete(alumno);

            ServiceReferenceAlumno.AlumnoServiceClient service = new ServiceReferenceAlumno.AlumnoServiceClient();
            var result = service.Delete(idAlumno);
            if(result.Correct)
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
        public ActionResult Form(int? idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            if(idAlumno != null) //Update
            {
                //ML.Result result = BL.Alumno.GetById(idAlumno.Value);

                ServiceReferenceAlumno.AlumnoServiceClient service = new ServiceReferenceAlumno.AlumnoServiceClient();
                var result = service.GetById(idAlumno.Value);
                if(result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    return View(alumno);
                }
            }
            return View(alumno);
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if(alumno.IdAlumno == 0 || alumno.IdAlumno == null)
            {
                //ML.Result result = BL.Alumno.Add(alumno);

                ServiceReferenceAlumno.AlumnoServiceClient service = new ServiceReferenceAlumno.AlumnoServiceClient();
                var result = service.Add(alumno);
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
                //ML.Result result = BL.Alumno.Update(alumno);

                ServiceReferenceAlumno.AlumnoServiceClient service = new ServiceReferenceAlumno.AlumnoServiceClient();
                var result = service.Update(alumno);
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

        [HttpGet]
        public ActionResult AsignarMateria()
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = new List<object>();
            ML.Result result = BL.Alumno.GetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(alumno);
        }

        [HttpPost]
        public ActionResult AsignarMateria(ML.Alumno alumno)
        {
            alumno.Alumnos = new List<object>();
            ML.Result result = BL.Alumno.GetAll();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(alumno);
        }
    }
}
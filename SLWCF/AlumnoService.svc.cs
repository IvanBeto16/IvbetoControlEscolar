using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.ModelBinding;

namespace SLWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AlumnoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AlumnoService.svc o AlumnoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AlumnoService : IAlumnoService
    {
        public SLWCF.Result Add(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Add(alumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage
            };
        }
        
        public SLWCF.Result Update(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.Update(alumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage
            };
        }

        public SLWCF.Result Delete(int idAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();
            alumno.IdAlumno = idAlumno;
            ML.Result result = BL.Alumno.Delete(alumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage
            };
        }

        public SLWCF.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Objects = result.Objects,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage
            };
        }

        public SLWCF.Result GetById(int idAlumno)
        {
            ML.Result result = BL.Alumno.GetById(idAlumno);
            return new SLWCF.Result
            {
                Correct = result.Correct,
                Object = result.Object,
                Ex = result.Ex,
                ErrorMessage = result.ErrorMessage
            };
        }
    }
}

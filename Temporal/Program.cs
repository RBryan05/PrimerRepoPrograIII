using reactBackend.Models;
using reactBackend.Repository;

namespace Temporal
{
    class Program
    {
        static void Main(string[] args)
        {
            AlumnoDAO alumnoDAO = new AlumnoDAO();
            #region SelectAll
            var alumnos = alumnoDAO.SelectAll();
            foreach (var alum in alumnos)
            {
                //Console.WriteLine(alum.Nombre);
            }
            #endregion

            #region GetByID
            var selectByID = alumnoDAO.GetByID(1);
            //Console.WriteLine(selectByID?.Nombre);
            #endregion

            #region AddAlumno
            var alumno = new Alumno()
            {
                Nombre = "Juan",
                Dni = "12345678",
                Direccion = "Calle 123",
                Correo = "juan2003@gmail.com"
            };
            //var resultado = alumnoDAO.InsertAlumno(alumno);
            //Console.WriteLine(resultado);
            #endregion

            #region UpdateAlumno
            var alumnoUpdate = new Alumno()
            {
                Nombre = "Williams",
                Dni = "12345678",
                Direccion = "Calle 123",
                Correo = "williams00@gmail.com"
            };
            //var resultadoUpdate = alumnoDAO.UpdateAlumno(2, alumnoUpdate);
            //Console.WriteLine(resultadoUpdate);
            #endregion

            #region DeleteAlumno
            //var resultadoDelete = alumnoDAO.DeleteAlumno(11);
            //Console.WriteLine("Se elimino " + resultadoDelete);
            #endregion

            #region AlumnoAsignatura desde un JOIN
            var alumnoAsignatura = alumnoDAO.GetAlumnoAsignatura();
            foreach (var item in alumnoAsignatura)
            {
                Console.WriteLine(item.nombreAlumno + " | Asignatura que cursa => " + item.nombreAsignatura);
            }
            #endregion
        }
    }
}
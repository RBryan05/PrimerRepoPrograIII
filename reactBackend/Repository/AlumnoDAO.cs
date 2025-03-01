using reactBackend.Context;
using reactBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reactBackend.Repository
{
    public class AlumnoDAO
    {
        #region Context
        public RegistroAlumnosContext contecxto = new RegistroAlumnosContext();
        #endregion

        #region SelectAll
        public List<Alumno> SelectAll()
        {
            var alumno = contecxto.Alumnos.ToList<Alumno>();
            return alumno;
        }
        #endregion

        #region GetByID
        public Alumno GetByID(int id)
        {
            var alumno = contecxto.Alumnos.Where(x => x.Id == id).FirstOrDefault();
            return alumno == null ? null : alumno;
        }
        #endregion

        #region InsertAlumno
        public bool InsertAlumno(Alumno alumno)
        {
            try
            {
                var alum = new Alumno()
                {
                    Nombre = alumno.Nombre,
                    Dni = alumno.Dni,
                    Direccion = alumno.Direccion,
                    Correo = alumno.Correo
                };

                contecxto.Alumnos.Add(alum);
                contecxto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region UpdateAlumno
        public bool UpdateAlumno(int id, Alumno alumno)
        {
            try
            {
                var alumnoUpdate = GetByID(id);
                if (alumnoUpdate == null)
                {
                    return false;
                }

                alumnoUpdate.Nombre = alumno.Nombre;
                alumnoUpdate.Dni = alumno.Dni;
                alumnoUpdate.Direccion = alumno.Direccion;
                alumnoUpdate.Correo = alumno.Correo;
                contecxto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }
        #endregion

        #region DeleteAlumno
        public bool DeleteAlumno(int id)
        {
            try
            {
                var alumno = GetByID(id);
                if (alumno == null)
                {
                    return false;
                }

                contecxto.Alumnos.Remove(alumno);
                contecxto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                return false;
            }
        }
        #endregion

        #region LeftJoin
        public List<AlumnoAsignatura> GetAlumnoAsignatura()
        {
            var query = from a in contecxto.Alumnos
                        join m in contecxto.Matriculas on a.Id equals m.AlumnoId
                        join asig in contecxto.Asignaturas on m.AsignaturaId equals asig.Id
                        select new AlumnoAsignatura
                        {
                            nombreAlumno = a.Nombre,
                            nombreAsignatura = asig.Nombre
                        };

            return query.ToList();
        }
        #endregion
    }
}

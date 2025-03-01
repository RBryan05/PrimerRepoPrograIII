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
    }
}

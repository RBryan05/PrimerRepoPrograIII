using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO _alDAO = new AlumnoDAO();

        [HttpGet("alumnoProfesor")]

        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _alDAO.AlumnoProfesors(usuario);
        }
    }
}

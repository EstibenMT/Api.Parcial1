using System.Collections.Generic;
using System.Web.Http;
using WebServicesParcial1.Classes;
using WebServicesParcial1.Models;

namespace WebServicesParcial1.Controllers
{
    [RoutePrefix("api/Student")]
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Student> ConsultarTodos()
        {
            clsStudent st = new clsStudent();
            return st.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarXDocumento")]
        public Student ConsultarXDocumento(string Documento)
        {
            clsStudent st = new clsStudent();
            return st.Consultar(Documento);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Student student)
        {
            clsStudent st= new clsStudent();
            st._student = student;
            return st.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Student student)
        {
            clsStudent st = new clsStudent();
            st._student = student;
            return st.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Student student)
        {
            clsStudent st = new clsStudent();
            st._student = student;
            return st.Eliminar();
        }
        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(string Documento)
        {
            clsStudent st = new clsStudent();
            return st.Eliminar(Documento);
        }
    }
}
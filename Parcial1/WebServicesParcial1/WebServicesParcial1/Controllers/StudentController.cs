using System.Collections.Generic;
using System.Web.Http;
using WebServicesParcial1.Classes;
using WebServicesParcial1.Models;

namespace WebServicesParcial1.Controllers
{
    [RoutePrefix("api/Computador")]
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<object> ConsultarTodos()
        {
            clsComputador comp = new clsComputador();
            return comp.ConsultarTodos();
        }
        [HttpGet]
        [Route("ConsultarXId")]
        public object ConsultarXId(int id)
        {
            clsComputador comp = new clsComputador();
            return comp.ConsultarXId(id);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Computador computador)
        {
            clsComputador comp = new clsComputador();
            comp._computador = computador;
            return comp.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Computador computador)
        {
            clsComputador comp = new clsComputador();
            comp._computador = computador;
            return comp.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Computador computador)
        {
            clsComputador comp = new clsComputador();
            comp._computador = computador;
            return comp.Eliminar();
        }
        [HttpDelete]
        [Route("EliminarXId")]
        public string EliminarXId(int id)
        {
            clsComputador comp = new clsComputador();
            return comp.Eliminar(id);
        }
    }
}
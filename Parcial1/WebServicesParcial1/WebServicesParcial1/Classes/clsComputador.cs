using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebServicesParcial1.Models;

namespace WebServicesParcial1.Classes
{
	public class clsComputador
    {
        private BDExamen1Entities db = new BDExamen1Entities();
        public Computador _computador { get; set; }
        public string Insertar()
        {
            try
            {
                db.Computadors.Add(_computador);
                db.SaveChanges();
                return "Computador insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el Computador: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {

                Computador Computador = Consultar(_computador.id_computador);
                if (Computador == null)
                {
                    return $"El Computador con el codigo {_computador.id_computador} ingresado no existe, por lo tanto no se puede actualizar";
                }

                db.Computadors.AddOrUpdate(_computador); 
                db.SaveChanges();
                return "Se actualizó el Computador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el Computador: " + ex.Message;
            }
        }
        public List<object> ConsultarTodos()
        {
            var query = from p in db.Computadors
                        join t in db.TipoComputadors on p.id_tipo equals t.id_tipo
                        select new
                        {
                            id_computad = p.id_computador,
                            num_procesadores = p.num_procesadores,
                            marca_procesador = p.marca_procesador,
                            tam_disco = p.tam_disco,
                            tam_memoria = p.tam_memoria,
                            componentes = p.componentes,
                            TipoComputador = t
                        };

            return query.ToList<object>(); 
        }
        public object ConsultarXId(int id)
        {
            var query = (from p in db.Computadors
                        join t in db.TipoComputadors on p.id_tipo equals t.id_tipo
                        where p.id_computador == id
                        select new
                        {
                            id_computad = p.id_computador,
                            num_procesadores = p.num_procesadores,
                            marca_procesador = p.marca_procesador,
                            tam_disco = p.tam_disco,
                            tam_memoria = p.tam_memoria,
                            componentes = p.componentes,
                            TipoComputador = t
                        }).FirstOrDefault();
            if (query == null)
            {
                return $"No se encontro computador con el codigo {id}";
            }
            return query;
        }
        public string Eliminar()
        {
            try
            {
                Computador Computador = Consultar(_computador.id_computador);
                if (Computador == null)
                {
                    return $"El Computador con el codigo {_computador.id_computador} ingresado no existe, por lo tanto no se puede eliminar";
                }
                db.Computadors.Remove(Computador);
                db.SaveChanges();
                return "Se eliminó el Computador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el Computador: " + ex.Message;
            }
        }
        public string Eliminar(int id)
        {
            try
            {
                Computador Computador = Consultar(id);
                if (Computador == null)
                {
                    return "El Computador con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                db.Computadors.Remove(Computador);
                db.SaveChanges();
                return "Se eliminó el Computador correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el Computador: " + ex.Message;
            }
        }

        private Computador Consultar(int id)
        {
            return db.Computadors.FirstOrDefault(c => c.id_computador == id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebServicesParcial1.Models;

namespace WebServicesParcial1.Classes
{
	public class clsStudent
	{
        private dbParcial1Entities db = new dbParcial1Entities();
        public Student _student { get; set; }
        public string Insertar()
        {
            try
            {
                db.Students.Add(_student);
                db.SaveChanges();
                return "Estudiante insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el Estudienate: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {

                Student student = Consultar(_student.Document);
                if (student == null)
                {
                    return "El estudiante con el documento ingresado no existe, por lo tanto no se puede actualizar";
                }

                db.Students.AddOrUpdate(_student); 
                db.SaveChanges();
                return "Se actualizó el estudiante correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el empleado: " + ex.Message;
            }
        }
        public List<Student> ConsultarTodos()
        {
            return db.Students
                .OrderBy(e => e.LastName)
                .ToList();
        }
        public Student Consultar(string document)
        {
            return db.Students.FirstOrDefault(s => s.Document == document);
        }
        public string Eliminar()
        {
            try
            {
                Student student = Consultar(_student.Document);
                if (student == null)
                {
                    return "El estudiante con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                db.Students.Remove(student);
                db.SaveChanges();
                return "Se eliminó el estudiante correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el estudienate: " + ex.Message;
            }
        }
        public string Eliminar(string Documento)
        {
            try
            {
                Student estudent = Consultar(Documento);
                if (estudent == null)
                {
                    return "El estudienate con el documento ingresado no existe, por lo tanto no se puede eliminar";
                }
                db.Students.Remove(estudent);
                db.SaveChanges();
                return "Se eliminó el estudienate correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el estudiente: " + ex.Message;
            }
        }
    }
}
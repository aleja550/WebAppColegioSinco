using Data;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Logic
{
    public class GetBusinessLogic
    {
        public Usuario LoginUser(string username, string password)
        {
            try
            {
                JObject jsonUser = JObject.Parse(new UsuarioDA().LogIn(username, password));
                Usuario usuario = new Usuario
                {
                    Username = jsonUser.GetValue("username").ToString(),
                    Contraseña = jsonUser.GetValue("contraseña").ToString(),
                    TipoUser = Convert.ToInt32(jsonUser.GetValue("tipoUser")),
                    Avatar = jsonUser.GetValue("avatar").ToString(),
                    FKCodigoTemplate = Convert.ToInt32(jsonUser.GetValue("fkCodigoTemplate")),
                };

                return usuario;
            }
            catch(Exception ex)
            {
                return null;
            }                     
        }  
        
        public List<EstiloTemplate> GetTemplatesList()
        {
            List<EstiloTemplate> estiloTemplates = null;
            try
            {              
                estiloTemplates = JsonConvert.DeserializeObject<List<EstiloTemplate>>(new EstiloTemplateDA().GetTemplates());                  
            }
            catch (Exception ex)
            {
                return null;
            }
            return estiloTemplates;
        }

        public List<Materia> GetAssignaturesList()
        {
            List<Materia> assignaturesList = null;
            try
            {
                assignaturesList = JsonConvert.DeserializeObject<List<Materia>>(new MateriaDA().GetAssignatures());
            }
            catch (Exception ex)
            {
                return null;
            }
            return assignaturesList;
        }

        public List<Materia> GetAssignaturesByTeacher(string username)
        {
            List<Materia> assignaturesList = null;
            try
            {
                assignaturesList = JsonConvert.DeserializeObject<List<Materia>>(new MateriaDA().GetAssignaturesByTeacher(username));
            }
            catch (Exception ex)
            {
                return null;
            }
            return assignaturesList;
        }

        public Usuario GetUser(string username)
        {
            try
            {
                JObject jsonUser = JObject.Parse(new UsuarioDA().GetUserByUsername(username));
                int template = jsonUser.GetValue("fkCodigoTemplate") == null ? 0 : Convert.ToInt32(jsonUser.GetValue("fkCodigoTemplate"));
                Usuario usuario = new Usuario
                {
                    Username = jsonUser.GetValue("username").ToString(),
                    Contraseña = jsonUser.GetValue("contraseña").ToString(),
                    TipoUser = Convert.ToInt32(jsonUser.GetValue("tipoUser")),
                    Avatar = jsonUser.GetValue("avatar").ToString(),
                    FKCodigoTemplate = template
                };

                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Profesor GetTeacher(long cedula)
        {
            try
            {
                JObject jsonUser = JObject.Parse(new ProfesorDA().GetTeacherByCedula(cedula));
                Profesor teacher = new Profesor
                {
                    Cedula = Convert.ToInt64(jsonUser.GetValue("cedula")),
                    Nombres = jsonUser.GetValue("nombres").ToString(),
                    Apellidos = jsonUser.GetValue("apellidos").ToString(),
                    FKUsuario = Convert.ToInt32(jsonUser.GetValue("fkUsuario")),
                    FkIdMateria = Convert.ToInt32(jsonUser.GetValue("fkIdMateria"))
                };

                return teacher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Materia GetMateriaByName(string materia)
        {
            try
            {
                JObject jsonMateria = JObject.Parse(new MateriaDA().GetAssignatureByName(materia));
                Materia usuario = new Materia
                {
                    IdMateria = Convert.ToInt32(jsonMateria.GetValue("IdMateria")),
                    NombreMateria = jsonMateria.GetValue("NombreMateria").ToString()
                };

                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Estudiante> GetStudents()
        {
            List<Estudiante> studentsList = null;
            try
            {
                string students  = new EstudianteDA().GetStudents();
                studentsList = JsonConvert.DeserializeObject<List<Estudiante>>(students);
                
            }
            catch (Exception ex)
            {
                return null;
            }

            return studentsList;
        }

        public List<Profesor> GetTeachers()
        {
            List<Profesor> teachersList = null;
            try
            {
                string teachers = new ProfesorDA().GetTeachers();
                teachersList = JsonConvert.DeserializeObject<List<Profesor>>(teachers);
            }
            catch (Exception ex)
            {
                return null;
            }

            return teachersList;
        }

        public Estudiante GetStudent(int id)
        {
            try
            {
                JObject jsonStudent = JObject.Parse(new EstudianteDA().GetStudent(id));
                Estudiante estudiante = new Estudiante
                {
                    IdEstudiante = Convert.ToInt32(jsonStudent.GetValue("IdEstudiante")),
                    Cedula = Convert.ToInt64(jsonStudent.GetValue("cedula")),
                    Nombres = jsonStudent.GetValue("nombres").ToString(),
                    Apellidos = jsonStudent.GetValue("apellidos").ToString(),
                    FKUsuario = Convert.ToInt32(jsonStudent.GetValue("fkUsuario"))
                };

                return estudiante;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Profesor GetTeacher(int id)
        {
            try
            {
                JObject jsonStudent = JObject.Parse(new ProfesorDA().GetTeacher(id));
                Profesor profesor = new Profesor
                {
                    IdProfesor = Convert.ToInt32(jsonStudent.GetValue("IdProfesor")),
                    Cedula = Convert.ToInt64(jsonStudent.GetValue("cedula")),
                    Nombres = jsonStudent.GetValue("nombres").ToString(),
                    Apellidos = jsonStudent.GetValue("apellidos").ToString(),
                    FKUsuario = Convert.ToInt32(jsonStudent.GetValue("fkUsuario")),
                    FkIdMateria = Convert.ToInt32(jsonStudent.GetValue("FkIdMateria")),
                };

                return profesor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Calificacion> GetNotesWithStudents(int id)
        {
            List<Calificacion> listNotes = null;
            try
            {
                string noteString = new NotasDA().GetNoteswithNames(id);
                listNotes = JsonConvert.DeserializeObject<List<Calificacion>>(noteString);
                return listNotes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Reporte> GetReport(string username)
        {
            List<Reporte> listReport = null;
            try
            {
                string reportString = new EstudianteDA().GetReporte(username);
                listReport = JsonConvert.DeserializeObject<List<Reporte>>(reportString);
                return listReport;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

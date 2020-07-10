using Data;
using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
    }
}

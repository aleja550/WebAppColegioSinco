using Data;
using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class CreateBusinessLogic
    {
        public int CreateTeacher(Profesor profesor)
        {
            JObject jsonTeacher = new JObject
            {
                { "Cedula", $"{profesor.Cedula}" },
                { "Nombres", $"{profesor.Nombres}" },
                { "Apellidos", $"{profesor.Apellidos}" },
                { "FKUsuario", $"{profesor.FKUsuario}"},
                { "FkIdMateria", $"{profesor.FkIdMateria}" }
            };
            int result = new ProfesorDA().CreateTeacher(jsonTeacher);
            return result;
        }

        public int CreateUser(Usuario usuario)
         {
            JObject jsonUser = new JObject
            {
                { "Username", $"{usuario.Username}" },
                { "Contraseña", $"{usuario.Contraseña}" },
                { "TipoUser", $"{usuario.TipoUser}" },
                { "Avatar", $"{usuario.Avatar}"},
                { "FKCodigoTemplate", $"{usuario.FKCodigoTemplate}" }
            };
            int result = new UsuarioDA().CreateUser(jsonUser);
            return result;
        }
    }
}

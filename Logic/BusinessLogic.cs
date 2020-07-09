using Data;
using Entities;
using Newtonsoft.Json.Linq;
using System;

namespace Logic
{
    public class BusinessLogic
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
                    TipoUser = Convert.ToInt32(jsonUser.GetValue("tipoUser"))
                };

                return usuario;
            }
            catch(Exception ex)
            {
                return null;
            }                     
        }
    }
}

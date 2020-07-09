using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Contraseña { get; set; }
        public int TipoUser { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Profesor
    {
        public int IdProfesor { get; set; }
        public long Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoUser { get; set; }
        public int FkIdMateria { get; set; }
    }
}

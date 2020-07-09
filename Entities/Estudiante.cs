using System;

namespace Entities
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public long Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoUser { get; set; }
    }
}

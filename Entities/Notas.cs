﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Notas
    {
        public int IdNotas { get; set; }
        public string Nota1 { get; set; }
        public string Nota2 { get; set; }
        public int FKIdMateria { get; set; }
        public int FKIdEstudiante { get; set; }
    }
}

using Data;
using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UpdateBusinessLogic
    {
        public int EditStudent(Estudiante estudiante)
        {
            JObject jsonStudent = new JObject
            {
                { "IdEstudiante", $"{estudiante.IdEstudiante}" },
                { "Cedula", $"{estudiante.Cedula}" },
                { "Nombres", $"{estudiante.Nombres}" },
                { "Apellidos", $"{estudiante.Apellidos}" },
            };
            int result = new EstudianteDA().UpdateStudent(jsonStudent, estudiante.IdEstudiante);
            return result;
        }

        public int EditProfesor(Profesor profesor)
        {
            JObject jsonProfesor = new JObject
            {
                { "IdProfesor", $"{profesor.IdProfesor}" },
                { "Cedula", $"{profesor.Cedula}" },
                { "Nombres", $"{profesor.Nombres}" },
                { "Apellidos", $"{profesor.Apellidos}" },
                { "FKUsuario", $"{profesor.FKUsuario}" },
                { "FKIdMateria", $"{profesor.FkIdMateria}" },
            };
            int result = new ProfesorDA().UpdateTeacher(jsonProfesor, profesor.IdProfesor);
            return result;
        }

        public int EditNotas(Notas notas)
        {
            JObject jsonNotas = new JObject
            {
                { "IdNotas", $"{notas.IdNotas}" },
                { "Nota1", $"{notas.Nota1}" },
                { "Nota2", $"{notas.Nota2}" },
                { "FKIdEstudiante", $"{1}" },
                { "FKIdMateria", $"{1}" },
            };
            int result = new NotasDA().UpdateNotes(jsonNotas, notas.IdNotas);
            return result;
        }
    }
}

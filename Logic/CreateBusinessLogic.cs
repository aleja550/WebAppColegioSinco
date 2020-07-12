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

        public int CreateStudent(Estudiante estudiante)
        {
            JObject jsonStudent = new JObject
            {
                { "Cedula", $"{estudiante.Cedula}" },
                { "Nombres", $"{estudiante.Nombres}" },
                { "Apellidos", $"{estudiante.Apellidos}" },
                { "FKUsuario", $"{estudiante.FKUsuario}"},
            };
            int result = new EstudianteDA().CreateStudent(jsonStudent);
            return result;
        }

        public int CreateAssignature(string materia)
        {
            JObject jsonAssignature = new JObject
            {
                { "NombreMateria", $"{materia}" }
            };
            int result = new MateriaDA().CreateAssignature(jsonAssignature);
            return result;
        }

        public int CreateNotes(Notas notes)
        {
            JObject jsonNotes = new JObject
            {
                { "Nota1", $"{notes.Nota1}" },
                { "Nota2", $"{notes.Nota2}" },
                { "FKIdMateria", $"{notes.FKIdMateria}" },
                { "FKIdEstudiante", $"{notes.FKIdEstudiante}"},
            };
            int result = new NotasDA().CreateNotes(jsonNotes);
            return result;
        }
    }
}

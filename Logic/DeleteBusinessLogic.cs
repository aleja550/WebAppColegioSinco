using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DeleteBusinessLogic
    {
        public int DeleteStudent(int id)
        {
            int resultdelete = 0;
            try
            {
                resultdelete = new EstudianteDA().DeleteStudent(id);
            }
            catch(Exception ex)
            {
                return 0;
            }

            return resultdelete;
        }

        public int DeleteTeacher(int id)
        {
            int resultdelete = 0;
            try
            {
                resultdelete = new ProfesorDA().DeleteProfesor(id);
            }
            catch (Exception ex)
            {
                return 0;
            }

            return resultdelete;
        }
    }
}

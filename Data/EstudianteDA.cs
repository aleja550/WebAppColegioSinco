using Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Data
{
    public class EstudianteDA
    {
        public int CreateStudent(JObject jsonStudent)
        {
            HttpResponseMessage response;
            int resultRequest = 0;
           
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PostAsync("https://localhost:44326/api/Estudiante/CrearEstudiante",
                        new StringContent(jsonStudent.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                    resultRequest = Convert.ToInt32(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return resultRequest;
        }

        public string GetStudents()
        {
            string students = null;
        
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync("https://localhost:44326/api/Estudiante/ObtenerEstudiantes").GetAwaiter().GetResult();
                }
                
                if (response.IsSuccessStatusCode)
                {
                    students = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                return students;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetStudent(int id)
        {
            string student = string.Empty;
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync("https://localhost:44326/api/Estudiante/ObtenerUnEstudiante/" + id).GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                    student = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                return student;
            }

            return student;
        }

        public int UpdateStudent(JObject jsonStudent, int id)
        {
            HttpResponseMessage response;
            int resultRequest = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PutAsync("https://localhost:44326/api/Estudiante/EditarEstudiante/" + id,
                        new StringContent(jsonStudent.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                    resultRequest = 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return resultRequest;
        }

        public int DeleteStudent(int id)
        {
            HttpResponseMessage response;
            int resultRequest = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.DeleteAsync("https://localhost:44326/api/Estudiante/EliminarEstudiante/" + id).GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                    resultRequest = 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

            return resultRequest;
        }

        public string GetReporte(string userName)
        {
            string report = string.Empty;
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync("https://localhost:44326/api/Estudiante/ObtenerReporte/" + userName).GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                    report = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }
            }
            catch (Exception ex)
            {
                return report;
            }

            return report;
        }
    }
}

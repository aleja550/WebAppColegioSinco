using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Data
{
    public class ProfesorDA
    {
        public string GetTeacherByCedula(long cedula)
        {
            try
            {
                string teacher = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/Usuario/ObtenerProfesorCedula/{cedula}") as HttpWebRequest;

                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    teacher = reader.ReadToEnd();
                }

                return teacher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int CreateTeacher(JObject jsonTeacher)
        {
            int resultRequest = 0;
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PostAsync("https://localhost:44326/api/Profesor/CrearProfesor",
                        new StringContent(jsonTeacher.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
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

        public string GetTeachers()
        {
            string teachers = null;

            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync("https://localhost:44326/api/Profesor/ObtenerProfesores").GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                    teachers = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                return teachers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetTeacher(int id)
        {
            string student = string.Empty;
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync("https://localhost:44326/api/Profesor/ObtenerUnProfesor/" + id).GetAwaiter().GetResult();
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

        public int UpdateTeacher(JObject jsonTeacher, int id)
        {
            HttpResponseMessage response;
            int resultRequest = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PutAsync("https://localhost:44326/api/Profesor/EditarProfesor/" + id,
                        new StringContent(jsonTeacher.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
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

        public int DeleteProfesor(int id)
        {
            HttpResponseMessage response;
            int resultRequest = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.DeleteAsync("https://localhost:44326/api/Profesor/EliminarProfesor/" + id).GetAwaiter().GetResult();
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
    }
}

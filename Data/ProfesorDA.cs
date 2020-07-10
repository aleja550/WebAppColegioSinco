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

            }catch(Exception ex)
            {
                return resultRequest;
            }

            return resultRequest;
        }
    }
}

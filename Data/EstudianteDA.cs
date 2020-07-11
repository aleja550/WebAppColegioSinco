using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Data
{
    public class EstudianteDA
    {
        public int CreateStudent(JObject jsonStudent)
        {
            int resultRequest = 0;
            HttpResponseMessage response;
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
    }
}

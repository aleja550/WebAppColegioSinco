using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Data
{
    public class NotasDA
    {
        public int CreateNotes(JObject jsonStudent)
        {
            HttpResponseMessage response;
            int resultRequest = 0;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PostAsync("https://localhost:44326/api/Notas/CrearNotas",
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

        public string GetNoteswithNames(int materia)
        {
            HttpResponseMessage response;
            string notes = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.GetAsync("https://localhost:44326/api/Notas/ObtenerNotasPorMateria/" + materia).GetAwaiter().GetResult();
                }

                if (response.IsSuccessStatusCode)
                {
                     notes = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();                     
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return notes;
        }

        public int UpdateNotes(JObject jsonNotas, int id)
        {
            HttpResponseMessage response;
            int resultRequest = 0;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PutAsync("https://localhost:44326/api/Notas/EditarNotas/" + id,
                        new StringContent(jsonNotas.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
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

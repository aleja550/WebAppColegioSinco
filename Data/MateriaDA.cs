using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Data
{
    public class MateriaDA
    {
        public string GetAssignatures()
        {
            try
            {
                string assignatures = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/Materia/ObtenerMaterias") as HttpWebRequest;

                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    assignatures = reader.ReadToEnd();
                }

                return assignatures;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetAssignatureByName(string materia)
        {
            try
            {
                string assignature = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/Materia/ObtenerMateriaPorNombre/{materia}") as HttpWebRequest;

                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    assignature = reader.ReadToEnd();
                }

                return assignature;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int CreateAssignature(JObject jAssignature)
        {
            int resultRequest = 0;
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PostAsync("https://localhost:44326/api/Materia/CrearMateria",
                        new StringContent(jAssignature.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
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

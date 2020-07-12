using Entities;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Data
{
    public class UsuarioDA
    {
        public string LogIn(string username, string password)
        {
            try
            {
                string user = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/Usuario/ValidateLogin/{username},{password}") as HttpWebRequest;

                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    user = reader.ReadToEnd();
                }

                return user;
            } 
            catch(Exception ex)
            {
                return null;
            }           
        }

        public string GetUserByUsername(string username)
        {
            try
            {
                string user = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/Usuario/ObtenerUnUsuario/{username}") as HttpWebRequest;

                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    user = reader.ReadToEnd();
                }

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public int CreateUser(JObject jObject)
        {
            int resultRequest = 0;
            HttpResponseMessage response;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    response = client.PostAsync("https://localhost:44326/api/Usuario/CrearUsuario",
                        new StringContent(jObject.ToString(), Encoding.UTF8, "application/json")).GetAwaiter().GetResult();
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

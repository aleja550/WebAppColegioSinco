using System;
using System.IO;
using System.Net;

namespace Data
{
    public class UsuarioDA
    {
        public string LogIn(string username, string password)
        {
            try
            {
                string user = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/Usuario/ObtenerUsuarioPorNombre/{username},{password}") as HttpWebRequest;

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
    }
}

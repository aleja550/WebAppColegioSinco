using System;
using System.IO;
using System.Net;

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
    }
}

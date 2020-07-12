using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Data
{
    public class EstiloTemplateDA
    {
        public string GetTemplates()
        {
            try
            {
                string template = string.Empty;
                HttpWebRequest request = WebRequest.Create($"https://localhost:44326/api/EstiloTemplate/ObtenerTemplates") as HttpWebRequest;

                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    template = reader.ReadToEnd();
                }

                return template;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

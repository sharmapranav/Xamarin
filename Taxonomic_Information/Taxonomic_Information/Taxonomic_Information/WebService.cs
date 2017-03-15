using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Taxonomic_Information
{
    public class WebService
    {
        static readonly object locker = new object();
        const string ServerURL = "https://www.itis.gov/ITISWebService/jsonservice/";
        static HttpClient httpClient;
        static WebService webService;

        WebService()
        {
            httpClient = new HttpClient();
            httpClient.MaxResponseContentBufferSize = 256000;
        }

        public static WebService Instance
        {
            get
            {
                lock (locker)
                {
                    if (webService == null)
                    {
                        webService = new WebService();
                    }
                    return webService;
                }
            }
        }

        public async Task<string> GetContent(string path)
        {
            string content = null;
            try
            {
                var uri = new Uri(ServerURL + path);

                var response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Debug.WriteLine($"Failed: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
            
            return content;
        }
    }
}

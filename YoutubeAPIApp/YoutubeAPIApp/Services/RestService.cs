using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoutubeAPIApp.Services
{
    public class RestService
    {
        public string Response { get; set; }

        public async Task<T> MakeGetRequestHttpClient<T>(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url);
                    return JsonConvert.DeserializeObject<T>(response);
                }
                catch (System.Exception ex)
                {                    
                    return JsonConvert.DeserializeObject<T>("");
                }
                
            }
        }

        public async Task<T> MakePostRequestHttpClient<T>(string url, Dictionary<string, string> parameters = null)
        {
            using (var client = new HttpClient())
            {
                var builder = new StringBuilder();
                HttpResponseMessage response = null;
                if (parameters == null || !parameters.Any())
                {
                    response = await client.PostAsync(url, new StringContent("", Encoding.UTF8));
                }
                else
                {
                    MultipartFormDataContent formData = new MultipartFormDataContent();
                    foreach (var item in parameters)
                    {
                        formData.Add(new StringContent(string.IsNullOrWhiteSpace(item.Value) ? "" : item.Value), item.Key);
                    }
                    response = await client.PostAsync(url, formData);
                }

                
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public async Task<T> MakePostRequestFile<T>(string url, string fileName, string contentType, MemoryStream stream)
        {
            using (var client = new HttpClient())
            {
                var form = new MultipartFormDataContent();
                var attachment = new ByteArrayContent(stream.ToArray(), 0, stream.ToArray().Length);
                attachment.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                form.Add(attachment, contentType.Split('/')[0], fileName);

                var response = await client.PostAsync(url, form);
                return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Core
{
    public class MapServerApiReader : IMapServerReader
    {
        public async Task<T> ReadApiAsync<T>(string url) where T : new()
        {
            var instance = new T();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();

                    instance = JsonConvert.DeserializeObject<T>(responseString);
                }
                else {
                    throw new MapServerException(response.ReasonPhrase);
                }
            }
            return instance;
        }
    }
}
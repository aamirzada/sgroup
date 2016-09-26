using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class SubLayer
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}

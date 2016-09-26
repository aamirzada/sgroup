using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class SpatialReference 
    {
        [JsonProperty("wkid")]
        public int Wkid { get; set; }
    }

}

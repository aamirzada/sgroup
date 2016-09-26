using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class MapImage
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("extent")]
        public Extent Extent { get; set; }

        [JsonProperty("scale")]
        public double Scale { get; set; }
    }

}

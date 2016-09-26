using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class Outline
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("color")]
        public int[] Color { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }
    }

}

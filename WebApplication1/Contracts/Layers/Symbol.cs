using Newtonsoft.Json;

namespace WebApplication1.Contracts
{

    public class Symbol
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }

        [JsonProperty("color")]
        public int[] Color { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("angle")]
        public int Angle { get; set; }

        [JsonProperty("xoffset")]
        public int Xoffset { get; set; }

        [JsonProperty("yoffset")]
        public int Yoffset { get; set; }

        [JsonProperty("outline")]
        public Outline Outline { get; set; }
    }

}

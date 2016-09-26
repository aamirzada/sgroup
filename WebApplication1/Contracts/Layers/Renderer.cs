using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class Renderer
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("minValue")]
        public int MinValue { get; set; }

        [JsonProperty("classBreakInfos")]
        public ClassBreakInfo[] ClassBreakInfos { get; set; }

        [JsonProperty("symbol")]
        public Symbol Symbol { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

}

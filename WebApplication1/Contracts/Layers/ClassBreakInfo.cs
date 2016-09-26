using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class ClassBreakInfo
    {

        [JsonProperty("classMaxValue")]
        public int ClassMaxValue { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("symbol")]
        public Symbol Symbol { get; set; }
    }

}

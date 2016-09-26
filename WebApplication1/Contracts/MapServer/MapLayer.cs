using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class MapLayer
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parentLayerId")]
        public int ParentLayerId { get; set; }

        [JsonProperty("defaultVisibility")]
        public bool DefaultVisibility { get; set; }

        [JsonProperty("subLayerIds")]
        public int[] SubLayerIds { get; set; }

        [JsonProperty("minScale")]
        public double MinScale { get; set; }

        [JsonProperty("maxScale")]
        public int MaxScale { get; set; }
    }

}

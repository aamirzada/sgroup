using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class DrawingInfo
    {
        [JsonProperty("renderer")]
        public Renderer Renderer { get; set; }

        [JsonProperty("transparency")]
        public int Transparency { get; set; }

        [JsonProperty("labelingInfo")]
        public object LabelingInfo { get; set; }
    }

}

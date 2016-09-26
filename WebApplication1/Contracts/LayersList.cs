using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication1.Contracts
{
    public class LayersList
    {
        [JsonProperty("layers")]
        public List<Layer> Layers { get; set; }

        [JsonProperty("tables")]
        public object[] Tables { get; set; }
    }

}

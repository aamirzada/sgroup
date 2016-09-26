using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
	public class MapServer
	{
        [JsonProperty("currentVersion")]
        public double CurrentVersion { get; set; }

        [JsonProperty("serviceDescription")]
        public string ServiceDescription { get; set; }

        [JsonProperty("mapName")]
        public string MapName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("copyrightText")]
        public string CopyrightText { get; set; }

        [JsonProperty("layers")]
        public MapLayer[] Layers { get; set; }

        [JsonProperty("tables")]
        public object[] Tables { get; set; }

        [JsonProperty("spatialReference")]
        public SpatialReference SpatialReference { get; set; }

        [JsonProperty("singleFusedMapCache")]
        public bool SingleFusedMapCache { get; set; }

        [JsonProperty("initialExtent")]
        public Extent InitialExtent { get; set; }

        [JsonProperty("fullExtent")]
        public Extent FullExtent { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("supportedImageFormatTypes")]
        public string SupportedImageFormatTypes { get; set; }

        [JsonProperty("documentInfo")]
        public DocumentInfo DocumentInfo { get; set; }

        [JsonProperty("capabilities")]
        public string Capabilities { get; set; }
    }
}
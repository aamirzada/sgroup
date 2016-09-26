using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
    public class Layer
    {
        [JsonProperty("currentVersion")]
        public double CurrentVersion { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("definitionExpression")]
        public string DefinitionExpression { get; set; }

        [JsonProperty("geometryType")]
        public string GeometryType { get; set; }

        [JsonProperty("copyrightText")]
        public string CopyrightText { get; set; }

        [JsonProperty("parentLayer")]
        public SubLayer ParentLayer { get; set; }

        [JsonProperty("subLayers")]
        public SubLayer[] SubLayers { get; set; }

        [JsonProperty("minScale")]
        public double MinScale { get; set; }

        [JsonProperty("maxScale")]
        public int MaxScale { get; set; }

        [JsonProperty("defaultVisibility")]
        public bool DefaultVisibility { get; set; }

        [JsonProperty("extent")]
        public Extent Extent { get; set; }

        [JsonProperty("hasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("htmlPopupType")]
        public string HtmlPopupType { get; set; }

        [JsonProperty("drawingInfo")]
        public DrawingInfo DrawingInfo { get; set; }

        [JsonProperty("displayField")]
        public string DisplayField { get; set; }

        [JsonProperty("fields")]
        public Field[] Fields { get; set; }

        [JsonProperty("typeIdField")]
        public object TypeIdField { get; set; }

        [JsonProperty("types")]
        public object Types { get; set; }

        [JsonProperty("relationships")]
        public object[] Relationships { get; set; }

        [JsonProperty("capabilities")]
        public string Capabilities { get; set; }
    }

}

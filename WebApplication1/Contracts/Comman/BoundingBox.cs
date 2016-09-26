using Newtonsoft.Json;

namespace WebApplication1.Contracts
{
	/// <summary>
	/// The extent (bounding box) of the exported image. 
	/// Unless the bboxSR parameter has been specified, 
	/// the bbox is assumed to be in the spatial reference of the map.
	/// </summary>
	public class BoundingBox
	{
        [JsonProperty("xmin")]
        public double Xmin { get; set; }

        [JsonProperty("ymin")]
        public double Ymin { get; set; }

        [JsonProperty("xmax")]
        public double Xmax { get; set; }

        [JsonProperty("ymax")]
        public double Ymax { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication1.Contracts;

namespace WebApplication1.Contracts
{

    public class Extent : BoundingBox
    {
        [JsonProperty("spatialReference")]
        public SpatialReference SpatialReference { get; set; }
    }

}

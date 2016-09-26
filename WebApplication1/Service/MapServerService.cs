using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Interfaces;

namespace WebApplication1.Service
{
    /// <summary>
    /// The url can be make dynamic by creating a method that generate the url base on the 
    /// FolderName ServiceName and other optional values in the url.
    /// </summary>
    public class MapServerService : IMapServerService
    {
        private readonly IMapServerReader _mapServerReader;
        public MapServerService(IMapServerReader mapServerReader)
        {
            _mapServerReader = mapServerReader;
        }
        public async Task<MapServer> GetMapServerInfoAsync()
        {
            string url = "https://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/?f=json";
            return await _mapServerReader.ReadApiAsync<MapServer>(url);
        }
        public async Task<List<Layer>> GetLayersListAsync()
        {
            string url = "https://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/layers?f=json&pretty=true";
            var layerTableList = await _mapServerReader.ReadApiAsync<LayersList>(url);
            return layerTableList.Layers;            

        }

        public async Task<List<Layer>> GetQueryLayersListAsync()
        {
            var allLayers =  await GetLayersListAsync();
            return allLayers.Where(l => 
                            l.Capabilities.ToLower().Contains("query")
                            ).ToList();
        }

        public async Task<string> GetMapImageAsync(BoundingBox bbox)
        {
            var bboxString = BoundingBoxToString(bbox);
            string url = "http://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/export?f=json";
            url += "&bbox=" + bboxString;
            var mapImage = await _mapServerReader.ReadApiAsync<MapImage>(url);
            return mapImage.Href;
        }

        private string BoundingBoxToString(BoundingBox bbox)
        {
            return bbox.Xmin.ToString(CultureInfo.InvariantCulture) +","+
                bbox.Ymax.ToString(CultureInfo.InvariantCulture) + "," +
                bbox.Xmax.ToString(CultureInfo.InvariantCulture) + "," +
                bbox.Ymax.ToString(CultureInfo.InvariantCulture);
        }

        
    }
}
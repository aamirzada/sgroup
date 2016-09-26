using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Contracts;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    // TODO: solve as many of the unimplemented tasks below as you can
    // All tasks should be implemented using the same service specified below
    // service url: https://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/
    // service api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?mapserver.html
    /// <summary>
    /// Controller for getting information about map services
    /// </summary>
    [RoutePrefix("api/mapservice")]
    public class MapServiceController : ApiController
    {
        private readonly IMapServerService _mapServerService;
        public MapServiceController(IMapServerService mapServerService)
        {
            _mapServerService = mapServerService;
        }
        // TODO: Implement endpoint that returns a class representation of the service(hint: convert json to C# contract class)
        /// <summary>
        /// Get a map service
        /// </summary>
        /// <returns>MapService</returns>
        [HttpGet]
        [Route("GetService")]
        public async Task<IHttpActionResult> GetService()
        {
            try
            {
                var mapServerInfo = await _mapServerService.GetMapServerInfoAsync();
                return Ok(mapServerInfo);
            }
            catch (MapServerException ex)
            {
                return NotFound();
            }
            catch (AggregateException ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Some error occured");
            }
        }

        // TODO: implement endpoint that returns a list of layers from a given service (use the service provided above)
        // api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?layer.html
        /// <summary>
        /// Get all layers from a map service
        /// </summary>
        /// <returns>A list of layers</returns>
        [HttpGet]
        [Route("GetLayers")]
        public async Task<IHttpActionResult> GetLayers()
        {
            try
            {
                var layerList = await _mapServerService.GetLayersListAsync();
                return Ok(layerList);
            }
            catch (MapServerException ex)
            {
                return NotFound();
            }
            catch (AggregateException ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Some error occured");
            }
        }
        // TODO: implement endpoint that returns a list of layers that supports the "Query" Operation (use the service provided above)
        // api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?layer.html
        /// <summary>
        /// Gets all layers that support the "query" operation
        /// </summary>
        /// <returns>A list of layers</returns>
        [HttpGet]
        [Route("GetQueriableLayers")]
        public async Task<IHttpActionResult> GetQueriableLayers()
        {
            try
            {
                var layerQueryList = await _mapServerService.GetQueryLayersListAsync();
                return Ok(layerQueryList);
            }
            catch (MapServerException ex)
            {
                return NotFound();
            }
            catch (AggregateException ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Some error occured");
            }
        }

        // TODO: implement a endpoint that returns the image url of the map for a given bounding box
        // api help page: http://sampleserver1.arcgisonline.com/ArcGIS/SDK/REST/index.html?export.html
        // test values: -207.682974279982,-40.6075371681153,-37.1804225764967,129.89501453537
        /// <summary>
        /// Gets the url of a generated image given a specific bounding box
        /// </summary>
        /// <param name="bbox"></param>
        /// <returns>A image url</returns>
        [HttpGet]
        [Route("GetMapImage")]
        public async Task<IHttpActionResult> GetMapImage([FromBody]BoundingBox bbox)
        {
            try
            {
                var imageUrl = await _mapServerService.GetMapImageAsync(bbox);
                return Ok(imageUrl);
            }
            catch (MapServerException ex)
            {
                return NotFound();
            }
            catch (AggregateException ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Some error occured");
            }
        }
    }
}

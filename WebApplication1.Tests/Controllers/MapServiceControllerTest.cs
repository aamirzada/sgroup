using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication1.Contracts;
using WebApplication1.Controllers;
using WebApplication1.Interfaces;

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class MapServiceControllerTest
    {

        [Test]
        public void GetServiceShouldReturnOkNegotiated()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            var sut = new MapServiceController(mapService.Object);

            mapService.Setup(x => x.GetMapServerInfoAsync())
                .Returns(Task.FromResult<MapServer>(new MapServer()));

            Task<IHttpActionResult> actionResult = sut.GetService();

            Assert.IsInstanceOf<OkNegotiatedContentResult<MapServer>>(actionResult.Result);
        }

        [Test]
        public void GetLayersShouldReturnOkNegotiated()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            var sut = new MapServiceController(mapService.Object);

            mapService.Setup(x => x.GetLayersListAsync())
                .Returns(Task.FromResult(new List<Layer>()));

            Task<IHttpActionResult> actionResult = sut.GetLayers();

            Assert.IsInstanceOf<OkNegotiatedContentResult<List<Layer>>>(actionResult.Result);
        }

        [Test]
        public void GetQueriableLayersShouldReturnOkNegotiated()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            var sut = new MapServiceController(mapService.Object);

            mapService.Setup(x => x.GetQueryLayersListAsync())
                .Returns(Task.FromResult(new List<Layer>()));

            Task<IHttpActionResult> actionResult = sut.GetQueriableLayers();

            Assert.IsInstanceOf<OkNegotiatedContentResult<List<Layer>>>(actionResult.Result);
        }

        [Test]
        public void GetMapImageShouldReturnOkNegotiated()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            var sut = new MapServiceController(mapService.Object);

            mapService.Setup(x => x.GetMapImageAsync(It.IsAny<BoundingBox>()))
                .Returns(Task.FromResult(""));

            Task<IHttpActionResult> actionResult = sut.GetMapImage(It.IsAny<BoundingBox>());

            Assert.IsInstanceOf<OkNegotiatedContentResult<string>>(actionResult.Result);
        }
    }
}

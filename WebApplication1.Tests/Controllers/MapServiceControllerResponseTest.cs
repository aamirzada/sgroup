using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using WebApplication1.Contracts;
using WebApplication1.Controllers;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Tests.Controllers
{
    [TestFixture]
    public class MapServiceControllerResponseTest
    {
        [Test]
        public void GetServiceShouldReturnMapServerObject()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            MapServiceController controller = new MapServiceController(mapService.Object);
            mapService.Setup(x => x.GetMapServerInfoAsync())
                .Returns(Task.FromResult<MapServer>(new MapServer() {MapName = "some map"}));

            var actionResult = controller.GetService().Result;
            var contentResult = actionResult as OkNegotiatedContentResult<MapServer>;
                
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual("some map", contentResult.Content.MapName);
        }

        [Test]
        public void GetServiceShouldReturnListOfLayersObject()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            MapServiceController controller = new MapServiceController(mapService.Object);
            mapService.Setup(x => x.GetLayersListAsync())
                .Returns(Task.FromResult(new List<Layer>() { new Layer(){  Id= 1 }, new Layer() { Id = 2 } }));

            var actionResult = controller.GetLayers().Result;
            var contentResult = actionResult as OkNegotiatedContentResult<List<Layer>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Count);
        }

        [Test]
        public void GetQueriableLayersShouldReturnListOfLayersObject()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            MapServiceController controller = new MapServiceController(mapService.Object);
            mapService.Setup(x => x.GetQueryLayersListAsync())
                .Returns(Task.FromResult(new List<Layer>() { new Layer() { Id = 1 }, new Layer() { Id = 2 } }));

            var actionResult = controller.GetQueriableLayers().Result;
            var contentResult = actionResult as OkNegotiatedContentResult<List<Layer>>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2, contentResult.Content.Count);
        }

        [Test]
        public void GetQueriableLayersMustHaveCalledGetLayersListAsync()
        {
            var mapService = new Mock<IMapServerService>();
            var mapReader = new Mock<IMapServerReader>();

            MapServiceController controller = new MapServiceController(mapService.Object);
            mapService.Setup(x => x.GetQueryLayersListAsync())
                .Returns(Task.FromResult(new List<Layer>() { new Layer() { Id = 1 }, new Layer() { Id = 2 } }));

            var actionResult = controller.GetQueriableLayers().Result;

            mapService.Verify(m => m.GetLayersListAsync(), Times.AtMostOnce);
        }
    }
}

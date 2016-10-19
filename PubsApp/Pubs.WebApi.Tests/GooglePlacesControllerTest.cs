using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Pubs.WebApi.Controllers;
using Pubs.Core.Abstract.Places;
using Moq;
using System.ComponentModel;

namespace Pubs.WebApi.Tests
{
    [TestClass]
    public class GooglePlacesControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        Mock<IContainer> mockContainer = new Mock<IContainer>();
        Mock<IPlacesService> placeService = new Mock<IPlacesService>();


        public async Task GetANearestPlacesAsync_WhenSearchParamsIncorrect_ShouldReturnBadRequest()
        {
            var controller = new GooglePlacesController(placeService.Object);
            controller.Get
            Assert.AreEqual(testProducts.Count, result.Count);
        }
    }
}

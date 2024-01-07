using Microsoft.VisualStudio.TestTools.UnitTesting;
using CityService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityService.Bussines.Abstract;
using CityService.Entities.Dtos;
using CityService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Moq;
using Moq.Protected;

namespace CityService.Controllers.Tests
{
    [TestClass()]
    public class CityControllerTests
    {
        [TestMethod()]
        public async Task AllTest()
        {
            // Arrange
            var cityServiceMock = new Mock<ICityService>();
            var controller = new CityController(cityServiceMock.Object);

            cityServiceMock.Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<City> { new City { Id = 1, Name = "City1" }, new City { Id = 2, Name = "City2" } });

            // Act
            var result = await controller.All();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            Assert.IsNotNull(okResult.Value);

            var cities = okResult.Value as IEnumerable<City>;
            Assert.IsNotNull(cities);
            Assert.AreEqual(2, cities.Count());
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var cityServiceMock = new Mock<ICityService>();
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var handlerMock = new Mock<HttpMessageHandler>();

            var httpClient = new HttpClient(handlerMock.Object);
            var httpClientMock = new Mock<HttpClient> { CallBase = true };


            cityServiceMock.Setup(service => service.AddAsync(It.IsAny<City>()))
                .ReturnsAsync(new City { Id = 1, Name = "TestCity" });
            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
              .Returns(httpClientMock.Object);
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("District saved successfully.")
                });

            var controller = new CityController(cityServiceMock.Object);

            // Act
            IActionResult result = controller.Save(new CityAndDistrictDto
            {
                CityName = "TestCity",
                DistrictName = "TestDistrict"
            }).Result;

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;

            Assert.IsInstanceOfType(okResult.Value, typeof(City));
            var city = (City)okResult.Value;

            Assert.AreEqual("TestCity", city.Name);
        }
    }
}
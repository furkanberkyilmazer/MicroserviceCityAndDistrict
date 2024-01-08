using CityService.Bussines.Abstract;
using CityService.Controllers;
using CityService.Entities.Dtos;
using CityService.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CityServiceTestsWithXUnit.Controllers
{
    public class CityControllerTests
    {
        public CityController _cityController { get; set; }
        public Mock<ICityService> _cityServiceMock { get; set; }
        public IEnumerable<City> _cities { get; set; }
        public CityControllerTests()
        {
            _cityServiceMock = new Mock<ICityService>();
            _cityController = new CityController(_cityServiceMock.Object);
            _cities = new List<City>() { new City { Id = 1, Name = "İstanbul" }, new City { Id = 2, Name = "Ankara" } };
           
        }

        [Fact]
        public async Task AllTest()
        {
            _cityServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_cities);

            var result = await _cityController.All();

            var OkResult = Assert.IsType<OkObjectResult>(result);

            var returnValue = Assert.IsAssignableFrom<IEnumerable<City>>(OkResult.Value);

            Assert.Equal(2, returnValue.Count());

        }

        [Fact]
        public async Task SaveTest()
        {
           

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();

        
            _cityServiceMock.Setup(service => service.AddAsync(It.IsAny<City>()))
                .ReturnsAsync(new City { Id = 1, Name = "TestCity" });
        
            IActionResult result = _cityController.Save(new CityAndDistrictDto
            {
                CityName = "TestCity",
                DistrictName = "TestDistrict"
            }).Result;
          
           
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;

            Assert.IsType<City>(okResult.Value);
            var city = (City)okResult.Value;

            Assert.Equal("TestCity", city.Name);



        }

    }
}

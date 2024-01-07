using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistrictService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistrictService.Bussines.Abstract;
using DistrictService.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CityService.Entities.Dtos;
using CityService.Bussines.Abstract;
using CityService.Controllers;
using CityService.Models;

namespace DistrictService.Controllers.Tests
{
    [TestClass()]
    public class DistrictControllerTests
    {
        [TestMethod()]
        public async Task AllTest()
        {
            // Arrange
            var districtServiceMock = new Mock<IDistrictService>();
            var controller = new DistrictController(districtServiceMock.Object);

            districtServiceMock.Setup(service => service.GetAllAsync())
                .ReturnsAsync(new List<District> { new District { Id = 1, Name = "District1" , CityId=1 }, new District { Id = 2, Name = "District2" , CityId=2} });

            // Act
            var result = await controller.All();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            Assert.IsNotNull(okResult.Value);

            var districts = okResult.Value as IEnumerable<District>;
            Assert.IsNotNull(districts);
            Assert.AreEqual(2, districts.Count());
        }

        [TestMethod()]
        public async Task SaveTest()
        {
            // Arrange
            var districtServiceMock = new Mock<IDistrictService>();
            var controller = new DistrictController(districtServiceMock.Object);

            var district = new District { Name = "testdistrict" }; 

            districtServiceMock.Setup(service => service.AddAsync(It.IsAny<District>()))
                .ReturnsAsync(district);

            // Act
            var result = await controller.Save(district);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

            var okResult = (OkObjectResult)result;
            Assert.IsNotNull(okResult.Value);

            Assert.IsInstanceOfType(okResult, typeof(OkObjectResult));
            
        }
    }
}
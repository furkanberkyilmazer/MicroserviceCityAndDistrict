using DistrictService.Bussines.Abstract;
using DistrictService.Bussines.Concrete;
using DistrictService.Controllers;
using DistrictService.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistrictServiceTestsWithXUnit.Controllers
{
    public class DistrictControllerTests
    {
        public Mock<IDistrictService> _districtServiceMock { get; set; }
        public DistrictController _districtController { get; set; }

        public IEnumerable<District> _districts { get; set; }

        public DistrictControllerTests()
        {
            _districtServiceMock = new Mock<IDistrictService>();
            _districtController = new DistrictController(_districtServiceMock.Object);
            _districts = new List<District>() { new District { Id = 1, CityId = 1, Name = "Beşiktaş" }, new District { Id = 2, CityId = 1, Name = "Kağıthane" } };
        }

        [Fact]
        public async Task AllTest()
        {

            _districtServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(_districts);

            var result = await _districtController.All();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<District>>(okResult.Value);

            Assert.Equal(2, returnValue.Count());


        }

        [Fact]
        public async Task SaveTest()
        {

            _districtServiceMock.Setup(x => x.AddAsync(_districts.FirstOrDefault())).ReturnsAsync(_districts.FirstOrDefault());

            var result = await _districtController.Save(_districts.FirstOrDefault());

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsAssignableFrom<District>(okResult.Value);

            Assert.Equal(_districts.FirstOrDefault(), returnValue);


        }
    }
}

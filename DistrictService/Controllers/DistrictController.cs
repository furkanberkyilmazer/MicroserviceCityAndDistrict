using DistrictService.Bussines.Abstract;
using DistrictService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DistrictService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            return Ok(await _districtService.GetAllAsync());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Save(District district)
        {
            district.Name = district.Name.ToLower().Trim();
            var newDist = await _districtService.AddAsync(district);

            return Ok(newDist);
        }
    }
}

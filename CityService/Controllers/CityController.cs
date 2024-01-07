using CityService.Bussines.Abstract;
using CityService.Entities.Dtos;
using CityService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace CityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

       
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            return Ok(await _cityService.GetAllAsync());
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Save(CityAndDistrictDto data)
        {
            HttpClient httpClient = new HttpClient();
          
            City city= new City() { Name= data.CityName.ToLower().Trim()};
            City newCity = await _cityService.AddAsync(city);
            try
            {
                string apiUrl = "https://localhost:7151/api/District/Save";
                DistrictDto district=new DistrictDto() { Name= data.DistrictName , CityId = newCity.Id};

                var jsonData = JsonConvert.SerializeObject(district);
                var response = await httpClient.PostAsync(apiUrl, new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return BadRequest("İl kayıt edildi. İlçe Kayıt edilemedi.  HTTP Kodu: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        
            return Ok(newCity);
        }
    }
}

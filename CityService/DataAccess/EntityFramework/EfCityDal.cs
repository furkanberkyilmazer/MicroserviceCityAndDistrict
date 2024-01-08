using CityService.DataAccess.Abstract;
using CityService.DataAccess.Context;
using CityService.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace CityService.DataAccess.EntityFramework
{
    public class EfCityDal : GenericDal<City>, ICityDal
    {

        public EfCityDal(CityDbContext cityDbContext) : base(cityDbContext)
        {
           
        }

        public async Task AddAsync(City entity)
        {
            await _cityDbContext.AddAsync(entity);
         
        }
    }
}

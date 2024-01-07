using CityService.DataAccess.Abstract;
using CityService.DataAccess.Context;
using CityService.Models;
using static System.Net.Mime.MediaTypeNames;

namespace CityService.DataAccess.EntityFramework
{
    public class EfCityDal : GenericDal<City>, ICityDal
    {
        public EfCityDal(CityDbContext cityDbContext) : base(cityDbContext)
        {
        }
    }
}

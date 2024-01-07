using CityService.Bussines.Abstract;
using CityService.DataAccess.Abstract;
using CityService.DataAccess.UnitOfWork;
using CityService.Models;

namespace CityService.Bussines.Concrete
{
    public class CityOfService : GenericService<City>, ICityService
    {
        private readonly ICityDal _cityDal;
        private readonly IUnitOfWork _unitofWork;

        public CityOfService(ICityDal cityDal, IUnitOfWork unitofWork):base(cityDal, unitofWork) 
        {
            _cityDal = cityDal;
            _unitofWork = unitofWork;
        }
    }
}

using DistrictService.Bussines.Abstract;
using DistrictService.DataAccess.Abstract;
using DistrictService.DataAccess.UnitOfWork;
using DistrictService.Entities;

namespace DistrictService.Bussines.Concrete
{
    public class DistrictOfService : GenericService<District>, IDistrictService
    {
        private readonly IDistrictDal _districtDal;
        private readonly IUnitOfWork _unitofWork;

        public DistrictOfService(IDistrictDal districtDal, IUnitOfWork unitofWork) : base(districtDal, unitofWork)
        {
            _districtDal = districtDal;
            _unitofWork = unitofWork;
        }
    }
}

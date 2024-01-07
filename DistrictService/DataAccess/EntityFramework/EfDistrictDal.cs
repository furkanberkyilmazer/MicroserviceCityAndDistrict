using DistrictService.DataAccess.Abstract;
using DistrictService.DataAccess.Context;
using DistrictService.Entities;

namespace DistrictService.DataAccess.EntityFramework
{
    public class EfDistrictDal : GenericDal<District>, IDistrictDal
    {
        public EfDistrictDal(DistrictDbContext districtDbContext) : base(districtDbContext)
        {
        }
    }
}

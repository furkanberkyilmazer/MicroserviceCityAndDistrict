using DistrictService.DataAccess.Abstract;
using DistrictService.DataAccess.Context;
using DistrictService.Entities;
using Microsoft.EntityFrameworkCore;

namespace DistrictService.DataAccess.EntityFramework
{
    public class EfDistrictDal : GenericDal<District>, IDistrictDal
    {

   
        public EfDistrictDal(DistrictDbContext districtDbContext) : base(districtDbContext)
        {
           
        }
    }
}

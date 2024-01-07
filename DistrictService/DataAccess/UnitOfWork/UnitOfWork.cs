using DistrictService.DataAccess.Context;

namespace DistrictService.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DistrictDbContext _districtDbContext;

        public UnitOfWork(DistrictDbContext cityDbContext)
        {
            _districtDbContext = cityDbContext;
        }

        public void Commit()
        {
            _districtDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _districtDbContext.SaveChangesAsync();
        }
    }
}

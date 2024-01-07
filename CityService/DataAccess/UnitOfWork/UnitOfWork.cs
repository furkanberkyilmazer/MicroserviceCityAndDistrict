using CityService.DataAccess.Context;

namespace CityService.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CityDbContext _cityDbContext;

        public UnitOfWork(CityDbContext cityDbContext)
        {
            _cityDbContext = cityDbContext;
        }

        public void Commit()
        {
            _cityDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _cityDbContext.SaveChangesAsync();
        }
    }
}

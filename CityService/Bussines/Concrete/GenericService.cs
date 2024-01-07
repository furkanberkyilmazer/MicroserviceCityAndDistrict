using CityService.Bussines.Abstract;
using CityService.DataAccess.Abstract;
using CityService.DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CityService.Bussines.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;
        private readonly IUnitOfWork _unitofWork;

        public GenericService(IGenericDal<T> genericDal, IUnitOfWork unitofWork)
        {
            _genericDal = genericDal;
            _unitofWork = unitofWork;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _genericDal.AddAsync(entity);
            await _unitofWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _genericDal.AddRangeAsync(entities);
            await _unitofWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _genericDal.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _genericDal.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {

            return await _genericDal.GetByIdAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _genericDal.Remove(entity);
            await _unitofWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _genericDal.RemoveRange(entities);
            await _unitofWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _genericDal.Update(entity);
            await _unitofWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _genericDal.Where(expression);
        }
    }
}

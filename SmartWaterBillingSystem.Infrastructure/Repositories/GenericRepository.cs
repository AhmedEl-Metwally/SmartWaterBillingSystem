using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Infrastructure.Data.Context;

namespace SmartWaterBillingSystem.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(SmartWaterBillingSystemDbContext _context) : IGenericRepository<TEntity> where TEntity : class
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetWithSpecificationAsync(ISpecification<TEntity> specification)
            => await ApplySpecification(specification).ToListAsync();

        public async Task<TEntity?> GetEntityWithSpecificationAsync(ISpecification<TEntity> specification)
            => await ApplySpecification(specification).FirstOrDefaultAsync();


        // Helper method to apply specification
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
            => SpecificationEvaluator.Default.GetQuery(_context.Set<TEntity>().AsQueryable(), specification);
    }
}

using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Infrastructure.Data.Context;

namespace SmartWaterBillingSystem.Infrastructure.Repositories
{
    public class UnitOfWork(SmartWaterBillingSystemDbContext _context) : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories = [];

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);
            if (_repositories.TryGetValue(entityType, out object? repository))
                return(IGenericRepository<TEntity>) repository;
            var newRepository = new GenericRepository<TEntity>(_context);
            _repositories[entityType] = newRepository;
            return newRepository;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SmartWaterBillingSystem.Application.Contracts.Repositorys;
using SmartWaterBillingSystem.Infrastructure.Data.Context;

namespace SmartWaterBillingSystem.Infrastructure.Repositories
{
    public class UnitOfWork(SmartWaterBillingSystemDbContext _context) : IUnitOfWork
    {
        public async Task<int> GetNextSequenceValueAsync(string sequenceName)
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = $"SELECT NEXT VALUE FOR {sequenceName}";

            if (command.Connection.State != System.Data.ConnectionState.Open)
                await command.Connection.OpenAsync();

            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);

        }
        // => await _context.Database.SqlQueryRaw<int>("SELECT NEXT VALUE FOR " + sequenceName).FirstAsync();


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

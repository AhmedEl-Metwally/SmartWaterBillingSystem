using Ardalis.Specification;

namespace SmartWaterBillingSystem.Application.Contracts.Repositorys
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetWithSpecificationAsync(ISpecification<TEntity> specification);
        Task<TEntity?> GetEntityWithSpecificationAsync(ISpecification<TEntity> specification);
    }
}

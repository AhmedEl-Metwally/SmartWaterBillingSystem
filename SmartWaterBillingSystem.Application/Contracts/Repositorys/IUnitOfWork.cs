namespace SmartWaterBillingSystem.Application.Contracts.Repositorys
{
    public interface IUnitOfWork
    {
        Task<int> GetNextSequenceValueAsync(string sequenceName);
        Task<int> SaveChangesAsync();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}

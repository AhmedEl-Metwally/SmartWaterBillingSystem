namespace SmartWaterBillingSystem.Application.Contracts.Repositorys
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}

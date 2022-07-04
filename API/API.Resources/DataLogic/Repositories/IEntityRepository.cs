namespace API.Resources.DataLogic.Repositories
{
    using API.Resources.Entities;

    public interface IEntityRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity?> GetAsync(TKey key);
        
        Task<bool> CreateAsync(TEntity entity);
        
        Task<bool> DeleteAsync(TKey key);

        Task<bool> UpdateAsync(TEntity entity);

    }
}

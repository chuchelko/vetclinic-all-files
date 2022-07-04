namespace API.Resources.DataLogic.Repositories
{
    using System.Threading.Tasks;

    using API.Resources.Entities;

    using Microsoft.EntityFrameworkCore;

    public class EntityRepository<TEntity, TKey> : IEntityRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {

        private readonly NpsqlContext context;

        public EntityRepository(NpsqlContext _context)
        {
            context = _context;
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(entity.Key);

            if (foundEntity != null)
                return false;

            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(TKey key)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(key);

            if (foundEntity == null)
                return false;

            context.Set<TEntity>().Remove(foundEntity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity?> GetAsync(TKey key)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(key);

            if (foundEntity != null)
                context.Entry(foundEntity).State = EntityState.Detached;
            
            return foundEntity;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(entity.Key);

            if (foundEntity == null)
                return false;

            foundEntity = entity;

            context.Entry(foundEntity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }

        //private TKey GetEntityKey(TEntity entity)
        //{
        //    var keyName = context.Model?.FindEntityType(typeof(TEntity))?
        //        .FindPrimaryKey()?.Properties..SingleOrDefault();

        //    if (keyName == null)
        //        throw new NullReferenceException($"Entity key of type {entity.GetType()} was null");

        //}

        //private async Task<TEntity?> GetByKey(object key)
        //{
        //    TEntity? foundEntity;
        //    if (key is int intKey)
        //        foundEntity = await context.Set<TEntity>().FindAsync(intKey);
        //    else if (key is string stringKey)
        //        foundEntity = await context.Set<TEntity>().FindAsync(stringKey);
        //    else
        //        throw new Exception("Ошибка с ключом :(");

        //    return foundEntity;
        //}
    }
}

using Learn_CQRS.Core.Repostories;
using Learn_CQRS.Data;
using Microsoft.EntityFrameworkCore;

namespace Learn_CQRS.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected HeroDbContext dbContext;
        protected readonly ILogger logger;
        protected readonly DbSet<T> dbSet;
        public GenericRepository(HeroDbContext dbContext, ILogger logger)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
            this.logger = logger;
        }
        public virtual async Task<T> Add(T entity, CancellationToken cancellationToken)
        {
            await dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
        {
            return await dbSet.ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> GetById<Y>(Y id, CancellationToken cancellationToken)
        {
            return await dbSet.FindAsync(new object?[] { id }, cancellationToken);
        }
        public virtual T? Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

using Learn_CQRS.Data;
using Learn_CQRS.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learn_CQRS.Core.Repositories
{
    public class HeroRepository : GenericRepository<Hero>, IHeroRepository
    {
        public HeroRepository(HeroDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }
        public override async Task<Hero> Add(Hero entity, CancellationToken cancellationToken)
        {
            try
            {
                await base.Add(entity, cancellationToken);
                return entity;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Add method error", typeof(HeroRepository));
                return new();
            }
        }
        public override async Task<IEnumerable<Hero>> GetAll(CancellationToken cancellationToken) 
        {
            try
            {
                return await dbSet.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} GetAll method error", typeof(HeroRepository));
                return new List<Hero>();
            }
        }
        public override Hero? Update(Hero entity)
        {
            try
            {
                dbSet.Update(entity);
                return entity;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "{Repo} Update method error", typeof(HeroRepository));
                return new();
            }
        }
        public override bool Delete(Hero deletedHero)
        {
            try
            {
                dbSet.Remove(deletedHero);
                return true;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "{Repo} Delete method error", typeof(HeroRepository));
                return false;
            }
        }
    }
}

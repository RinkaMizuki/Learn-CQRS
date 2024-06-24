using Learn_CQRS.Data;
using MediatR;

namespace Learn_CQRS.Features.Heros.DeleteHeroById
{
    public class DeleteHeroByIdCommandHandler : IRequestHandler<DeleteHeroByIdCommand, bool>
    {
        private readonly HeroDbContext _dbContext;
        public DeleteHeroByIdCommandHandler(HeroDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteHeroByIdCommand request, CancellationToken cancellationToken)
        {
            var deletedHero = await _dbContext
                                            .Heroes
                                            .FindAsync(new object?[] { request.heroId }, cancellationToken);
            if (deletedHero is null) return false;
            _dbContext
                    .Heroes
                    .Remove(deletedHero);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

using Learn_CQRS.Data;
using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.PostHero
{
    public class PostHeroCommandHandler : IRequestHandler<PostHeroCommand, int>
    {
        private readonly HeroDbContext _dbContext;
        public PostHeroCommandHandler(HeroDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(PostHeroCommand request, CancellationToken cancellationToken)
        {
            var newHero = new Hero { Level = request.level, Name = request.name };
            await _dbContext
                           .Heroes
                           .AddAsync(newHero, cancellationToken);
            await _dbContext
                            .SaveChangesAsync(cancellationToken);
            return newHero.Id;
        }
    }
}

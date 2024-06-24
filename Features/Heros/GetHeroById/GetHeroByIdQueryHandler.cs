using Learn_CQRS.Data;
using Learn_CQRS.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Learn_CQRS.Features.Heros.GetHeroById
{
    public class GetHeroByIdQueryHandler : IRequestHandler<GetHeroByIdQuery, Hero?>
    {
        private readonly HeroDbContext _dbContext;
        public GetHeroByIdQueryHandler(HeroDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Hero?> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
        {
            var hero = await _dbContext
                                        .Heroes
                                        .Where(h => h.Id.Equals(request.heroId))
                                        .FirstOrDefaultAsync(cancellationToken);
            return hero;
        }
    }
}

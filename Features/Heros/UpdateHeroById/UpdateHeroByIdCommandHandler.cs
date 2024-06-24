using AutoMapper;
using Learn_CQRS.Data;
using MediatR;

namespace Learn_CQRS.Features.Heros.UpdateHeroById
{
    public class UpdateHeroByIdCommandHandler : IRequestHandler<UpdateHeroByIdCommand, bool>
    {

        private readonly HeroDbContext _dbContext;
        private readonly IMapper _mapper;
        public UpdateHeroByIdCommandHandler(HeroDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateHeroByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedHero = await _dbContext
                                            .Heroes
                                            .FindAsync(new object?[] { request.heroId }, cancellationToken);
            if (updatedHero is null) return false;
            _mapper.Map(request, updatedHero);
            _dbContext.Heroes.Update(updatedHero);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }   
    }
}

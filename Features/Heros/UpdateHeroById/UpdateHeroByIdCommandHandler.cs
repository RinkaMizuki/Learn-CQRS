using AutoMapper;
using Learn_CQRS.Core.IConfiguration;
using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.UpdateHeroById
{
    public class UpdateHeroByIdCommandHandler : IRequestHandler<UpdateHeroByIdCommand, Hero?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateHeroByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Hero?> Handle(UpdateHeroByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedHero = await _unitOfWork
                                               .Heros
                                               .GetById(request.heroId, cancellationToken);

            if (updatedHero is null) return null;

            _mapper.Map(request, updatedHero);

            _unitOfWork
                      .Heros
                      .Update(updatedHero);

            await _unitOfWork
                            .CompleteAsync(cancellationToken);
            return updatedHero;
        }   
    }
}

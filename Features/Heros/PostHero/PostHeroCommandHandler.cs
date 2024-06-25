using AutoMapper;
using Learn_CQRS.Core.IConfiguration;
using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.PostHero
{
    public class PostHeroCommandHandler : IRequestHandler<PostHeroCommand, Hero>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostHeroCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Hero> Handle(PostHeroCommand request, CancellationToken cancellationToken)
        {
            var mapperHero = _mapper.Map<Hero>(request);
            var newHero = await _unitOfWork.Heros.Add(mapperHero, cancellationToken);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return newHero;
        }
    }
}

using Learn_CQRS.Core.IConfiguration;
using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.GetHeroById
{
    public class GetHeroByIdQueryHandler : IRequestHandler<GetHeroByIdQuery, Hero?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetHeroByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Hero?> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Heros.GetById(request.heroId, cancellationToken);
        }
    }
}

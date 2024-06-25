using Learn_CQRS.Core.IConfiguration;
using MediatR;

namespace Learn_CQRS.Features.Heros.DeleteHeroById
{
    public class DeleteHeroByIdCommandHandler : IRequestHandler<DeleteHeroByIdCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteHeroByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteHeroByIdCommand request, CancellationToken cancellationToken)
        {
            var deletedHero = await _unitOfWork
                                               .Heros
                                               .GetById(request.heroId, cancellationToken);
            if (deletedHero is null) return false;
            _unitOfWork
                      .Heros
                      .Delete(deletedHero);
            await _unitOfWork
                            .CompleteAsync(cancellationToken);
            return true;
        }
    }
}

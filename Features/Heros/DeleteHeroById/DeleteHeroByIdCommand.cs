using MediatR;

namespace Learn_CQRS.Features.Heros.DeleteHeroById
{
    public record DeleteHeroByIdCommand(int heroId) : IRequest<bool>;
}

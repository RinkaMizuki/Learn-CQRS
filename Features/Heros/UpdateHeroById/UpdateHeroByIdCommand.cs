using MediatR;

namespace Learn_CQRS.Features.Heros.UpdateHeroById
{
    public record UpdateHeroByIdCommand(int heroId, string name, int level) : IRequest<bool>;
}

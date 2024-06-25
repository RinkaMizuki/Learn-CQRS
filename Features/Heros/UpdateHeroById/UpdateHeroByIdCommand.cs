using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.UpdateHeroById
{
    public record UpdateHeroByIdCommand(int heroId, string name, int level) : IRequest<Hero?>;
}

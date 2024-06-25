using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.PostHero
{
    public record PostHeroCommand(string name, int level) : IRequest<Hero>;
}

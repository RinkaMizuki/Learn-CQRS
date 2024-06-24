using MediatR;

namespace Learn_CQRS.Features.Heros.PostHero
{
    public record PostHeroCommand(string name, int level) : IRequest<int>;
}

using Learn_CQRS.Entities;
using MediatR;

namespace Learn_CQRS.Features.Heros.GetHeroById
{
    public record GetHeroByIdQuery(int heroId) : IRequest<Hero?>; 
}

using AutoMapper;
using Learn_CQRS.Entities;
using Learn_CQRS.Features.Heros.UpdateHeroById;

namespace Learn_CQRS.Mappers
{
    public class HeroMapper : Profile
    {
        public HeroMapper()
        {
            CreateMap<UpdateHeroByIdCommand, Hero>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.heroId));
        }
    }
}

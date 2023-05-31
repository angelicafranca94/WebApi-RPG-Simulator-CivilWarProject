using AutoMapper;
using CivilWar.Infra.Model;
using CivilWar.Infra.Model.Dto;

namespace CivilWar.Infra;

public class MappingConfig
{
    public static MapperConfiguration RegistroMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<HeroDto, Hero>();
            config.CreateMap<Hero, HeroDto>();
        });

        return mappingConfig;
    }
}

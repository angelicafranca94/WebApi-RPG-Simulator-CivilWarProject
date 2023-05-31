using CivilWar.Infra.Model.Dto;

namespace CivilWar.Infra.Repository.Interface;

public interface IHeroRepository
{
    Task<IEnumerable<HeroDto>> GetHeros();
    Task<HeroDto> GetHeroById(int heroId);
    Task<HeroDto> CreateUpdateHero(HeroDto heroDto);
    Task<bool> DeleteHero(int heroId);
}

using AutoMapper;
using CivilWar.Infra.DbContexts;
using CivilWar.Infra.Model;
using CivilWar.Infra.Model.Dto;
using CivilWar.Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CivilWar.Infra.Repository;

public class HeroRepository : IHeroRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public HeroRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<HeroDto> CreateUpdateHero(HeroDto heroDto)
    {
        var hero = _mapper.Map<HeroDto, Hero>(heroDto);

        if (hero.Id > 0)
            _db.Heros.Update(hero);
        else
            _db.Heros.Add(hero);

        await _db.SaveChangesAsync();
        return _mapper.Map<Hero, HeroDto>(hero);
    }

    public async Task<bool> DeleteHero(int heroId)
    {
        try
        {
            var hero = await _db.Heros.FirstAsync(u => u.Id == heroId);

            if (hero == null)
                return false;

            _db.Heros.Remove(hero);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<HeroDto> GetHeroById(int heroId)
    {
        var hero = await _db.Heros.AsNoTracking().Where(x => x.Id == heroId).FirstOrDefaultAsync();
        return _mapper.Map<HeroDto>(hero);
    }

    public async Task<IEnumerable<HeroDto>> GetHeros()
    {
        var heroList = await _db.Heros.ToListAsync();
        return _mapper.Map<List<HeroDto>>(heroList);
    }
}

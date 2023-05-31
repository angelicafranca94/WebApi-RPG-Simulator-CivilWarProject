using CivilWar.Infra.Model.Dto;
using CivilWar.Infra.Repository.Interface;
using CivilWar.Web.Dto;
using CivilWar.Web.Model;
using CivilWar.Web.Services.Interface;

namespace CivilWar.Web.Services;

public class BattleService : IBattleService
{
    private readonly IHeroRepository _heroRepository;

    public BattleService(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public async Task<BattleModel> BattleActionAsync(int heroFirstId, int heroSecondId)
    {
        //Carregando os heróis
        var heroFirst = await _heroRepository.GetHeroById(heroFirstId);
        var heroSecond = await _heroRepository.GetHeroById(heroSecondId);

        if (heroFirst is not null && heroSecond is not null)
        {
            //Retorna informação de que os herois estão do mesmo lado
            if (VerifySideHero(heroFirst, heroSecond))
                return new BattleModel { Message = "Heróis do mesmo lado da lei não podem batalhar!" };

            List<ShiftDto> shifts = new List<ShiftDto>();

            int shiftCount = 0;

            var battle = GetBatlleInfo(heroFirst, heroSecond, shifts, shiftCount);

            return battle;
        }
        else if(heroFirst is null)
        {
            return new BattleModel { Message = $"Não foi localizado herói com id {heroFirstId}" };
        }
        else
        {
            return new BattleModel { Message = $"Não foi localizado herói com id {heroSecondId}" };
        }
        
    }

    //Um herói não pode batalhar contra outro que esteja do mesmo lado da lei.
    private bool VerifySideHero(HeroDto heroFirst, HeroDto heroSecond)
    {
        return heroFirst.FavorRegisteringSuperhumans == heroSecond.FavorRegisteringSuperhumans;
    }

    private BattleModel GetBatlleInfo(HeroDto heroFirst, HeroDto heroSecond, List<ShiftDto> shifts, int shiftCount)
    {
        shifts = HerosBattleAction(heroFirst, heroSecond, shifts, shiftCount);

        //Objeto dos dados da batalha
        var battle = new BattleModel
        {
            HerosName = new() { heroFirst.Name, heroSecond.Name },
            Round = shifts,
            HerosHPFinalBattle = new() { $"{heroFirst.Name} HP: {heroFirst.HealthPoint}", $"{heroSecond.Name} HP: {heroSecond.HealthPoint}" }
        };

        return battle;
    }

    private List<ShiftDto> HerosBattleAction(HeroDto heroFirst, HeroDto heroSecond, List<ShiftDto> shifts, int shiftsCount)
    {
        var healthPoint = heroFirst.HealthPoint;

        if (healthPoint > 0)
        {
            Random random = new Random();

            //O herói que ataca rola um dado virtual que vai de 0 (zero) até o máximo do seu poder de ataque.
            //O herói que defende rola um dado virtual que vai de 0 (zero) até o seu máximo poder de defesa.
            var attackPowerPoints = random.Next(0, heroFirst.AtackPower);
            var defensePowerPoints = random.Next(0, heroSecond.DefensePower);

            var damage = GetDamage(attackPowerPoints, defensePowerPoints);

            if (damage > 0)
                heroSecond.HealthPoint -= damage;

            shiftsCount++;

            shifts = ShiftGenerator(heroFirst.Name, heroSecond.Name, attackPowerPoints, defensePowerPoints, shifts, shiftsCount);

            //Chamando a si mesmo trocando a ordem dos heróis no parâmetro
            HerosBattleAction(heroSecond, heroFirst, shifts, shiftsCount);
        }

        return shifts;
    }

    //O dano é calculado da seguinte forma: valor do ataque - valor de defesa = dano.
    private int GetDamage(int attackPowerPoints, int defensePowerPoints)
    {
        return attackPowerPoints - defensePowerPoints;
    }

    //Gerando o turno
    private List<ShiftDto> ShiftGenerator(string heroAttackerName, string heroDefenderName, int attackPowerPoints, int defensePowerPoints, List<ShiftDto> shifts, int shiftsCount)
    {
        var shift = new ShiftDto
        {
            Shift = shiftsCount,
            HeroAttackerName = heroAttackerName,
            HeroDefenderName = heroDefenderName,
            AttackPoints = attackPowerPoints,
            DefensePoints = defensePowerPoints
        };

        shifts.Add(shift);

        return shifts;
    }

   

}

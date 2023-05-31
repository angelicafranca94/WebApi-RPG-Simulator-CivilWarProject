using CivilWar.Infra.Model.Dto;
using CivilWar.Web.Dto;
using CivilWar.Web.Model;

namespace CivilWar.Web.Services.Interface;

public interface IBattleService
{
    Task<BattleModel> BattleActionAsync(int heroFirstId, int heroSecondId);
}

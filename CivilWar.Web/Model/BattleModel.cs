using CivilWar.Web.Dto;

namespace CivilWar.Web.Model;

public class BattleModel
{
    public List<string> HerosName { get; set; }
    public List<ShiftDto> Round { get; set; }
    public List<string> HerosHPFinalBattle { get; set; }
    public string Message { get; set; }
}

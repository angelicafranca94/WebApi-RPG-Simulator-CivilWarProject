namespace CivilWar.Infra.Model.Dto;

public class HeroDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AtackPower { get; set; }
    public int DefensePower { get; set; }
    public int HealthPoint { get; set; }
    public bool FavorRegisteringSuperhumans{ get; set; }
}

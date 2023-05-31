using CivilWar.Infra.Model;
using Microsoft.EntityFrameworkCore;

namespace CivilWar.Infra.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Hero> Heros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 1,
            Name = "Capitão América",
            AtackPower = 83,
            DefensePower = 88,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = false
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 2,
            Name = "Soldado Invernal",
            AtackPower = 75,
            DefensePower = 100,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = false
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 3,
            Name = "Gavião Arqueiro",
            AtackPower = 88,
            DefensePower = 77,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = false
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 4,
            Name = "Feiticeira Escarlate",
            AtackPower = 93,
            DefensePower = 77,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = false
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 5,
            Name = "Falcão",
            AtackPower = 80,
            DefensePower = 82,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = false
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 6,
            Name = "Hulk",
            AtackPower = 100,
            DefensePower = 70,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = false
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 7,
            Name = "Homem de Ferro",
            AtackPower = 75,
            DefensePower = 100,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = true
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 8,
            Name = "Pantera Negra",
            AtackPower = 86,
            DefensePower = 93,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = true
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 9,
            Name = "Viúva Negra",
            AtackPower = 88,
            DefensePower = 77,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = true
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 10,
            Name = "Visão",
            AtackPower = 100,
            DefensePower = 70,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = true
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 11,
            Name = "Máquina de Combate",
            AtackPower = 75,
            DefensePower = 100,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = true
        });

        modelBuilder.Entity<Hero>().HasData(new Hero
        {
            Id = 12,
            Name = "Homem-Aranha",
            AtackPower = 80,
            DefensePower = 82,
            HealthPoint = 500,
            FavorRegisteringSuperhumans = true
        });
    }
}
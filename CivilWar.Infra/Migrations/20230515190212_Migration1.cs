using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CivilWar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtackPower = table.Column<int>(type: "int", nullable: false),
                    DefensePower = table.Column<int>(type: "int", nullable: false),
                    HealthPoint = table.Column<int>(type: "int", nullable: false),
                    FavorRegisteringSuperhumans = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heros", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Heros",
                columns: new[] { "Id", "AtackPower", "DefensePower", "FavorRegisteringSuperhumans", "HealthPoint", "Name" },
                values: new object[,]
                {
                    { 1, 83, 88, false, 500, "Capitão América" },
                    { 2, 75, 100, false, 500, "Soldado Invernal" },
                    { 3, 88, 77, false, 500, "Gavião Arqueiro" },
                    { 4, 93, 77, false, 500, "Feiticeira Escarlate" },
                    { 5, 80, 82, false, 500, "Falcão" },
                    { 6, 100, 70, false, 500, "Hulk" },
                    { 7, 75, 100, true, 500, "Homem de Ferro" },
                    { 8, 86, 93, true, 500, "Pantera Negra" },
                    { 9, 88, 77, true, 500, "Viúva Negra" },
                    { 10, 100, 70, true, 500, "Visão" },
                    { 11, 75, 100, true, 500, "Máquina de Combate" },
                    { 12, 80, 82, true, 500, "Homem-Aranha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heros");
        }
    }
}

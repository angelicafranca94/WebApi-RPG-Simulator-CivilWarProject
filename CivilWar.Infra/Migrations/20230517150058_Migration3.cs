using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CivilWar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackPointTotal = table.Column<int>(type: "int", nullable: false),
                    AttackerHealthPointTotal = table.Column<int>(type: "int", nullable: false),
                    DefenderHealthPointTotal = table.Column<int>(type: "int", nullable: false),
                    DefensePointTotal = table.Column<int>(type: "int", nullable: false),
                    HeroAttackerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroDefenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });
        }
    }
}

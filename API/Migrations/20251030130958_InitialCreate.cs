using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BaseDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    DexReq = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageModifier = table.Column<double>(type: "REAL", nullable: false),
                    StrenghtReq = table.Column<int>(type: "INTEGER", nullable: false),
                    Shinyness = table.Column<double>(type: "REAL", nullable: false),
                    ChanceOfFlisFromWoodShaft = table.Column<double>(type: "REAL", nullable: false),
                    CritPercentageDamage = table.Column<double>(type: "REAL", nullable: false),
                    CritPercentageChange = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSamurai.Data.Migrations
{
    public partial class ImplementedCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Samurais");

            migrationBuilder.AddColumn<int>(
                name: "Hairstyle",
                table: "Samurais",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SamuraiBattles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleId",
                table: "SamuraiBattles",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SamuraiBattles_Battles_BattleId",
                table: "SamuraiBattles");

            migrationBuilder.DropIndex(
                name: "IX_SamuraiBattles_BattleId",
                table: "SamuraiBattles");

            migrationBuilder.DropColumn(
                name: "Hairstyle",
                table: "Samurais");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Samurais",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

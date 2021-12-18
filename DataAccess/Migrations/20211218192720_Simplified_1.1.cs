using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Simplified_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Section_SectionId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_SectionId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Exercise");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "SubSection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Optional",
                table: "Exercise",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SubSection_SectionId",
                table: "SubSection",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubSection_Section_SectionId",
                table: "SubSection",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubSection_Section_SectionId",
                table: "SubSection");

            migrationBuilder.DropIndex(
                name: "IX_SubSection_SectionId",
                table: "SubSection");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "SubSection");

            migrationBuilder.DropColumn(
                name: "Optional",
                table: "Exercise");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Exercise",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_SectionId",
                table: "Exercise",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Section_SectionId",
                table: "Exercise",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

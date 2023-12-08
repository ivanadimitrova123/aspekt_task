using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspekt_task.Migrations
{
    public partial class CompanyinCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Countries",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CompanyId",
                table: "Countries",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Companies_CompanyId",
                table: "Countries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Companies_CompanyId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CompanyId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Countries");
        }
    }
}

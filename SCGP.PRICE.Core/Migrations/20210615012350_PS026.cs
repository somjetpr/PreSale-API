using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typeofbagId",
                table: "pr_production_option_cost");

            migrationBuilder.DropColumn(
                name: "vender_Id",
                table: "pr_production_cost");

            migrationBuilder.AddColumn<string>(
                name: "vender_Id",
                table: "pr_production_option_cost",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "typeofbagId",
                table: "pr_production_cost",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vender_Id",
                table: "pr_production_option_cost");

            migrationBuilder.DropColumn(
                name: "typeofbagId",
                table: "pr_production_cost");

            migrationBuilder.AddColumn<int>(
                name: "typeofbagId",
                table: "pr_production_option_cost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "vender_Id",
                table: "pr_production_cost",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

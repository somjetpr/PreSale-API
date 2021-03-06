using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "vender_Id",
                table: "pr_product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vender_Id",
                table: "pr_product");
        }
    }
}

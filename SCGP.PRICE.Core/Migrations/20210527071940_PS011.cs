using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_group",
                table: "pr_product");

            migrationBuilder.DropColumn(
                name: "detail_type",
                table: "pr_detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_group",
                table: "pr_product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "detail_type",
                table: "pr_detail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

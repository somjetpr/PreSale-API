using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "group",
                table: "pr_product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_product_group",
                table: "pr_product",
                column: "group");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_product_pr_bag_of_type_group",
                table: "pr_product",
                column: "group",
                principalTable: "pr_bag_of_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_product_pr_bag_of_type_group",
                table: "pr_product");

            migrationBuilder.DropIndex(
                name: "IX_pr_product_group",
                table: "pr_product");

            migrationBuilder.DropColumn(
                name: "group",
                table: "pr_product");
        }
    }
}

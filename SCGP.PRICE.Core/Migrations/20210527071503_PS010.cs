using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pr_product_groupId",
                table: "pr_product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_product_pr_product_groupId",
                table: "pr_product",
                column: "pr_product_groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_product_pr_product_group_pr_product_groupId",
                table: "pr_product",
                column: "pr_product_groupId",
                principalTable: "pr_product_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_product_pr_product_group_pr_product_groupId",
                table: "pr_product");

            migrationBuilder.DropIndex(
                name: "IX_pr_product_pr_product_groupId",
                table: "pr_product");

            migrationBuilder.DropColumn(
                name: "pr_product_groupId",
                table: "pr_product");
        }
    }
}

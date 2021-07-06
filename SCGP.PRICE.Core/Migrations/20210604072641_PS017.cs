using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "formulaId",
                table: "pr_shipping_area",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_shipping_area_formulaId",
                table: "pr_shipping_area",
                column: "formulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_shipping_area_pr_formula_formulaId",
                table: "pr_shipping_area",
                column: "formulaId",
                principalTable: "pr_formula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_shipping_area_pr_formula_formulaId",
                table: "pr_shipping_area");

            migrationBuilder.DropIndex(
                name: "IX_pr_shipping_area_formulaId",
                table: "pr_shipping_area");

            migrationBuilder.DropColumn(
                name: "formulaId",
                table: "pr_shipping_area");
        }
    }
}

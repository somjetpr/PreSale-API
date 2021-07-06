using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS016 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "formulaId",
                table: "pr_production_option_cost",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "formulaId",
                table: "pr_production_cost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_production_option_cost_formulaId",
                table: "pr_production_option_cost",
                column: "formulaId");

            migrationBuilder.CreateIndex(
                name: "IX_pr_production_cost_formulaId",
                table: "pr_production_cost",
                column: "formulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_production_cost_pr_formula_formulaId",
                table: "pr_production_cost",
                column: "formulaId",
                principalTable: "pr_formula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pr_production_option_cost_pr_formula_formulaId",
                table: "pr_production_option_cost",
                column: "formulaId",
                principalTable: "pr_formula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_production_cost_pr_formula_formulaId",
                table: "pr_production_cost");

            migrationBuilder.DropForeignKey(
                name: "FK_pr_production_option_cost_pr_formula_formulaId",
                table: "pr_production_option_cost");

            migrationBuilder.DropIndex(
                name: "IX_pr_production_option_cost_formulaId",
                table: "pr_production_option_cost");

            migrationBuilder.DropIndex(
                name: "IX_pr_production_cost_formulaId",
                table: "pr_production_cost");

            migrationBuilder.DropColumn(
                name: "formulaId",
                table: "pr_production_option_cost");

            migrationBuilder.DropColumn(
                name: "formulaId",
                table: "pr_production_cost");
        }
    }
}

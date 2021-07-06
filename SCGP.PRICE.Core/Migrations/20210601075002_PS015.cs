using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_formula_pr_formula_pr_formulaId",
                table: "pr_formula");

            migrationBuilder.DropForeignKey(
                name: "FK_pr_formula_variable_pr_formula_group_pr_formula_groupId",
                table: "pr_formula_variable");

            migrationBuilder.DropIndex(
                name: "IX_pr_formula_variable_pr_formula_groupId",
                table: "pr_formula_variable");

            migrationBuilder.DropIndex(
                name: "IX_pr_formula_pr_formulaId",
                table: "pr_formula");

            migrationBuilder.DropColumn(
                name: "pr_formula_groupId",
                table: "pr_formula_variable");

            migrationBuilder.DropColumn(
                name: "pr_formulaId",
                table: "pr_formula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pr_formula_groupId",
                table: "pr_formula_variable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pr_formulaId",
                table: "pr_formula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_variable_pr_formula_groupId",
                table: "pr_formula_variable",
                column: "pr_formula_groupId");

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_pr_formulaId",
                table: "pr_formula",
                column: "pr_formulaId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_formula_pr_formula_pr_formulaId",
                table: "pr_formula",
                column: "pr_formulaId",
                principalTable: "pr_formula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_pr_formula_variable_pr_formula_group_pr_formula_groupId",
                table: "pr_formula_variable",
                column: "pr_formula_groupId",
                principalTable: "pr_formula_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

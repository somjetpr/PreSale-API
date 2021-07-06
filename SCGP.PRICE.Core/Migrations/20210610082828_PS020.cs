using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bagOftypeId",
                table: "pr_formula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_bagOftypeId",
                table: "pr_formula",
                column: "bagOftypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_formula_pr_bag_of_type_bagOftypeId",
                table: "pr_formula",
                column: "bagOftypeId",
                principalTable: "pr_bag_of_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_formula_pr_bag_of_type_bagOftypeId",
                table: "pr_formula");

            migrationBuilder.DropIndex(
                name: "IX_pr_formula_bagOftypeId",
                table: "pr_formula");

            migrationBuilder.DropColumn(
                name: "bagOftypeId",
                table: "pr_formula");
        }
    }
}

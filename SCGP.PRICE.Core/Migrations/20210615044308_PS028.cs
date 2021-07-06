using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS028 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bagOftypeId",
                table: "pr_production_cost",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_production_cost_bagOftypeId",
                table: "pr_production_cost",
                column: "bagOftypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_production_cost_pr_bag_of_type_bagOftypeId",
                table: "pr_production_cost",
                column: "bagOftypeId",
                principalTable: "pr_bag_of_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_production_cost_pr_bag_of_type_bagOftypeId",
                table: "pr_production_cost");

            migrationBuilder.DropIndex(
                name: "IX_pr_production_cost_bagOftypeId",
                table: "pr_production_cost");

            migrationBuilder.DropColumn(
                name: "bagOftypeId",
                table: "pr_production_cost");
        }
    }
}

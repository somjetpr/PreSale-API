using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "pr_formula_group",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "pr_formula_group",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "pr_formula_group",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "pr_formula_group",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "pr_formula_group",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "formulagroupId",
                table: "pr_formula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_formulagroupId",
                table: "pr_formula",
                column: "formulagroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_formula_pr_formula_group_formulagroupId",
                table: "pr_formula",
                column: "formulagroupId",
                principalTable: "pr_formula_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_formula_pr_formula_group_formulagroupId",
                table: "pr_formula");

            migrationBuilder.DropIndex(
                name: "IX_pr_formula_formulagroupId",
                table: "pr_formula");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "pr_formula_group");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "pr_formula_group");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "pr_formula_group");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "pr_formula_group");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "pr_formula_group");

            migrationBuilder.DropColumn(
                name: "formulagroupId",
                table: "pr_formula");
        }
    }
}

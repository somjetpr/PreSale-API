using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pr_formulaId",
                table: "pr_formula",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pr_formula_variable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    variable_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    formulaId = table.Column<int>(type: "int", nullable: true),
                    pr_formula_groupId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pr_formula_variable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pr_formula_variable_pr_formula_formulaId",
                        column: x => x.formulaId,
                        principalTable: "pr_formula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pr_formula_variable_pr_formula_group_pr_formula_groupId",
                        column: x => x.pr_formula_groupId,
                        principalTable: "pr_formula_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_pr_formulaId",
                table: "pr_formula",
                column: "pr_formulaId");

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_variable_formulaId",
                table: "pr_formula_variable",
                column: "formulaId");

            migrationBuilder.CreateIndex(
                name: "IX_pr_formula_variable_pr_formula_groupId",
                table: "pr_formula_variable",
                column: "pr_formula_groupId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_formula_pr_formula_pr_formulaId",
                table: "pr_formula",
                column: "pr_formulaId",
                principalTable: "pr_formula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_formula_pr_formula_pr_formulaId",
                table: "pr_formula");

            migrationBuilder.DropTable(
                name: "pr_formula_variable");

            migrationBuilder.DropIndex(
                name: "IX_pr_formula_pr_formulaId",
                table: "pr_formula");

            migrationBuilder.DropColumn(
                name: "pr_formulaId",
                table: "pr_formula");
        }
    }
}

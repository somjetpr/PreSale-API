using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "pr_detail_type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "pr_detail_type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "pr_detail_type",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "pr_detail_type",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "pr_detail_type",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "pr_detail_typeId",
                table: "pr_detail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pr_detail_pr_detail_typeId",
                table: "pr_detail",
                column: "pr_detail_typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_detail_pr_detail_type_pr_detail_typeId",
                table: "pr_detail",
                column: "pr_detail_typeId",
                principalTable: "pr_detail_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_detail_pr_detail_type_pr_detail_typeId",
                table: "pr_detail");

            migrationBuilder.DropIndex(
                name: "IX_pr_detail_pr_detail_typeId",
                table: "pr_detail");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "pr_detail_type");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "pr_detail_type");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "pr_detail_type");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "pr_detail_type");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "pr_detail_type");

            migrationBuilder.DropColumn(
                name: "pr_detail_typeId",
                table: "pr_detail");
        }
    }
}

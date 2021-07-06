using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS034 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_record_detail_pr_record_RecordId",
                table: "pr_record_detail");

            migrationBuilder.DropIndex(
                name: "IX_pr_record_detail_RecordId",
                table: "pr_record_detail");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "pr_record_detail");

            migrationBuilder.DropColumn(
                name: "record_detail_id",
                table: "pr_record_detail");

            migrationBuilder.AlterColumn<int>(
                name: "record_id",
                table: "pr_record_detail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_pr_record_detail_record_id",
                table: "pr_record_detail",
                column: "record_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_record_detail_pr_record_record_id",
                table: "pr_record_detail",
                column: "record_id",
                principalTable: "pr_record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_record_detail_pr_record_record_id",
                table: "pr_record_detail");

            migrationBuilder.DropIndex(
                name: "IX_pr_record_detail_record_id",
                table: "pr_record_detail");

            migrationBuilder.AlterColumn<int>(
                name: "record_id",
                table: "pr_record_detail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "pr_record_detail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "record_detail_id",
                table: "pr_record_detail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pr_record_detail_RecordId",
                table: "pr_record_detail",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_record_detail_pr_record_RecordId",
                table: "pr_record_detail",
                column: "RecordId",
                principalTable: "pr_record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

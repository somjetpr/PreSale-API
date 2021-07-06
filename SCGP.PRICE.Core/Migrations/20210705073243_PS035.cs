using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS035 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_record_detail_pr_record_record_id",
                table: "pr_record_detail");

            migrationBuilder.RenameColumn(
                name: "record_id",
                table: "pr_record_detail",
                newName: "RecordId");

            migrationBuilder.RenameIndex(
                name: "IX_pr_record_detail_record_id",
                table: "pr_record_detail",
                newName: "IX_pr_record_detail_RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_record_detail_pr_record_RecordId",
                table: "pr_record_detail",
                column: "RecordId",
                principalTable: "pr_record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_record_detail_pr_record_RecordId",
                table: "pr_record_detail");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "pr_record_detail",
                newName: "record_id");

            migrationBuilder.RenameIndex(
                name: "IX_pr_record_detail_RecordId",
                table: "pr_record_detail",
                newName: "IX_pr_record_detail_record_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_record_detail_pr_record_record_id",
                table: "pr_record_detail",
                column: "record_id",
                principalTable: "pr_record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

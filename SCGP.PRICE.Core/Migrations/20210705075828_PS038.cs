using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS038 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pr_recordpr_record_conversion");

            migrationBuilder.AlterColumn<int>(
                name: "record_id",
                table: "pr_record_conversion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_pr_record_conversion_record_id",
                table: "pr_record_conversion",
                column: "record_id");

            migrationBuilder.AddForeignKey(
                name: "FK_pr_record_conversion_pr_record_record_id",
                table: "pr_record_conversion",
                column: "record_id",
                principalTable: "pr_record",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pr_record_conversion_pr_record_record_id",
                table: "pr_record_conversion");

            migrationBuilder.DropIndex(
                name: "IX_pr_record_conversion_record_id",
                table: "pr_record_conversion");

            migrationBuilder.AlterColumn<int>(
                name: "record_id",
                table: "pr_record_conversion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "pr_recordpr_record_conversion",
                columns: table => new
                {
                    ConversionsId = table.Column<int>(type: "int", nullable: false),
                    recordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pr_recordpr_record_conversion", x => new { x.ConversionsId, x.recordsId });
                    table.ForeignKey(
                        name: "FK_pr_recordpr_record_conversion_pr_record_conversion_ConversionsId",
                        column: x => x.ConversionsId,
                        principalTable: "pr_record_conversion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pr_recordpr_record_conversion_pr_record_recordsId",
                        column: x => x.recordsId,
                        principalTable: "pr_record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pr_recordpr_record_conversion_recordsId",
                table: "pr_recordpr_record_conversion",
                column: "recordsId");
        }
    }
}

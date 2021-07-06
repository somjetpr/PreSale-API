using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "pc_shipping_area",
                newName: "area_price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "pc_shipping_area",
                newName: "area_name");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "pc_sale",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "pc_sale",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "productname",
                table: "pc_product_master",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "group",
                table: "pc_product_master",
                newName: "product_group");

            migrationBuilder.RenameColumn(
                name: "typecode",
                table: "pc_formula",
                newName: "type_code");

            migrationBuilder.RenameColumn(
                name: "group",
                table: "pc_formula",
                newName: "formula_group");

            migrationBuilder.RenameColumn(
                name: "formulacode",
                table: "pc_formula",
                newName: "formula_code");

            migrationBuilder.RenameColumn(
                name: "sub_bu",
                table: "pc_detail_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "bu",
                table: "pc_detail_type",
                newName: "bu_type");

            migrationBuilder.AddColumn<string>(
                name: "product_code",
                table: "pc_product_master",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "product_name",
                table: "pc_product_master",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pr_business_unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    business_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sub_bu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pr_business_unit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pr_business_unit");

            migrationBuilder.DropColumn(
                name: "product_code",
                table: "pc_product_master");

            migrationBuilder.DropColumn(
                name: "product_name",
                table: "pc_product_master");

            migrationBuilder.RenameColumn(
                name: "area_price",
                table: "pc_shipping_area",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "area_name",
                table: "pc_shipping_area",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "pc_sale",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "pc_sale",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "pc_product_master",
                newName: "productname");

            migrationBuilder.RenameColumn(
                name: "product_group",
                table: "pc_product_master",
                newName: "group");

            migrationBuilder.RenameColumn(
                name: "type_code",
                table: "pc_formula",
                newName: "typecode");

            migrationBuilder.RenameColumn(
                name: "formula_group",
                table: "pc_formula",
                newName: "group");

            migrationBuilder.RenameColumn(
                name: "formula_code",
                table: "pc_formula",
                newName: "formulacode");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "pc_detail_type",
                newName: "sub_bu");

            migrationBuilder.RenameColumn(
                name: "bu_type",
                table: "pc_detail_type",
                newName: "bu");
        }
    }
}

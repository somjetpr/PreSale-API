using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_shipping_areas",
                table: "pc_shipping_areas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_production_option_costs",
                table: "pc_production_option_costs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_production_costs",
                table: "pc_production_costs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_product_types",
                table: "pc_product_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_product_masters",
                table: "pc_product_masters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_product_logs",
                table: "pc_product_logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_formulas",
                table: "pc_formulas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_formula_groups",
                table: "pc_formula_groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_details",
                table: "pc_details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "pc_shipping_areas",
                newName: "pc_shipping_area");

            migrationBuilder.RenameTable(
                name: "pc_production_option_costs",
                newName: "pc_production_option_cost");

            migrationBuilder.RenameTable(
                name: "pc_production_costs",
                newName: "pc_production_cost");

            migrationBuilder.RenameTable(
                name: "pc_product_types",
                newName: "pc_product_type");

            migrationBuilder.RenameTable(
                name: "pc_product_masters",
                newName: "pc_product_master");

            migrationBuilder.RenameTable(
                name: "pc_product_logs",
                newName: "pc_product_log");

            migrationBuilder.RenameTable(
                name: "pc_formulas",
                newName: "pc_formula");

            migrationBuilder.RenameTable(
                name: "pc_formula_groups",
                newName: "pc_formula_group");

            migrationBuilder.RenameTable(
                name: "pc_details",
                newName: "pc_detail");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_shipping_area",
                table: "pc_shipping_area",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_production_option_cost",
                table: "pc_production_option_cost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_production_cost",
                table: "pc_production_cost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_type",
                table: "pc_product_type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_master",
                table: "pc_product_master",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_log",
                table: "pc_product_log",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_formula",
                table: "pc_formula",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_formula_group",
                table: "pc_formula_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_detail",
                table: "pc_detail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "pc_sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_by = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pc_sale", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pc_sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_shipping_area",
                table: "pc_shipping_area");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_production_option_cost",
                table: "pc_production_option_cost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_production_cost",
                table: "pc_production_cost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_product_type",
                table: "pc_product_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_product_master",
                table: "pc_product_master");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_product_log",
                table: "pc_product_log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_formula_group",
                table: "pc_formula_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_formula",
                table: "pc_formula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_detail",
                table: "pc_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "pc_shipping_area",
                newName: "pc_shipping_areas");

            migrationBuilder.RenameTable(
                name: "pc_production_option_cost",
                newName: "pc_production_option_costs");

            migrationBuilder.RenameTable(
                name: "pc_production_cost",
                newName: "pc_production_costs");

            migrationBuilder.RenameTable(
                name: "pc_product_type",
                newName: "pc_product_types");

            migrationBuilder.RenameTable(
                name: "pc_product_master",
                newName: "pc_product_masters");

            migrationBuilder.RenameTable(
                name: "pc_product_log",
                newName: "pc_product_logs");

            migrationBuilder.RenameTable(
                name: "pc_formula_group",
                newName: "pc_formula_groups");

            migrationBuilder.RenameTable(
                name: "pc_formula",
                newName: "pc_formulas");

            migrationBuilder.RenameTable(
                name: "pc_detail",
                newName: "pc_details");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_shipping_areas",
                table: "pc_shipping_areas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_production_option_costs",
                table: "pc_production_option_costs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_production_costs",
                table: "pc_production_costs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_types",
                table: "pc_product_types",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_masters",
                table: "pc_product_masters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_logs",
                table: "pc_product_logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_formula_groups",
                table: "pc_formula_groups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_formulas",
                table: "pc_formulas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_details",
                table: "pc_details",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");
        }
    }
}

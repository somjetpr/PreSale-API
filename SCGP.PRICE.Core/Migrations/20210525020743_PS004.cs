using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_shipping_area",
                table: "pc_shipping_area");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_sale",
                table: "pc_sale");

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
                name: "PK_pc_detail_type",
                table: "pc_detail_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_detail",
                table: "pc_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pc_customer",
                table: "pc_customer");

            migrationBuilder.RenameTable(
                name: "pc_shipping_area",
                newName: "pr_shipping_area");

            migrationBuilder.RenameTable(
                name: "pc_sale",
                newName: "pr_sale");

            migrationBuilder.RenameTable(
                name: "pc_production_option_cost",
                newName: "pr_production_option_cost");

            migrationBuilder.RenameTable(
                name: "pc_production_cost",
                newName: "pr_production_cost");

            migrationBuilder.RenameTable(
                name: "pc_product_type",
                newName: "pr_product_type");

            migrationBuilder.RenameTable(
                name: "pc_product_master",
                newName: "pr_product");

            migrationBuilder.RenameTable(
                name: "pc_product_log",
                newName: "pr_product_log");

            migrationBuilder.RenameTable(
                name: "pc_formula_group",
                newName: "pr_formula_group");

            migrationBuilder.RenameTable(
                name: "pc_formula",
                newName: "pr_formula");

            migrationBuilder.RenameTable(
                name: "pc_detail_type",
                newName: "pr_detail_type");

            migrationBuilder.RenameTable(
                name: "pc_detail",
                newName: "pr_detail");

            migrationBuilder.RenameTable(
                name: "pc_customer",
                newName: "pr_customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_shipping_area",
                table: "pr_shipping_area",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_sale",
                table: "pr_sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_production_option_cost",
                table: "pr_production_option_cost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_production_cost",
                table: "pr_production_cost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_product_type",
                table: "pr_product_type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_product",
                table: "pr_product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_product_log",
                table: "pr_product_log",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_formula_group",
                table: "pr_formula_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_formula",
                table: "pr_formula",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_detail_type",
                table: "pr_detail_type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_detail",
                table: "pr_detail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pr_customer",
                table: "pr_customer",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_shipping_area",
                table: "pr_shipping_area");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_sale",
                table: "pr_sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_production_option_cost",
                table: "pr_production_option_cost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_production_cost",
                table: "pr_production_cost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_product_type",
                table: "pr_product_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_product_log",
                table: "pr_product_log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_product",
                table: "pr_product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_formula_group",
                table: "pr_formula_group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_formula",
                table: "pr_formula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_detail_type",
                table: "pr_detail_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_detail",
                table: "pr_detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pr_customer",
                table: "pr_customer");

            migrationBuilder.RenameTable(
                name: "pr_shipping_area",
                newName: "pc_shipping_area");

            migrationBuilder.RenameTable(
                name: "pr_sale",
                newName: "pc_sale");

            migrationBuilder.RenameTable(
                name: "pr_production_option_cost",
                newName: "pc_production_option_cost");

            migrationBuilder.RenameTable(
                name: "pr_production_cost",
                newName: "pc_production_cost");

            migrationBuilder.RenameTable(
                name: "pr_product_type",
                newName: "pc_product_type");

            migrationBuilder.RenameTable(
                name: "pr_product_log",
                newName: "pc_product_log");

            migrationBuilder.RenameTable(
                name: "pr_product",
                newName: "pc_product_master");

            migrationBuilder.RenameTable(
                name: "pr_formula_group",
                newName: "pc_formula_group");

            migrationBuilder.RenameTable(
                name: "pr_formula",
                newName: "pc_formula");

            migrationBuilder.RenameTable(
                name: "pr_detail_type",
                newName: "pc_detail_type");

            migrationBuilder.RenameTable(
                name: "pr_detail",
                newName: "pc_detail");

            migrationBuilder.RenameTable(
                name: "pr_customer",
                newName: "pc_customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_shipping_area",
                table: "pc_shipping_area",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_sale",
                table: "pc_sale",
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
                name: "PK_pc_product_log",
                table: "pc_product_log",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_product_master",
                table: "pc_product_master",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_formula_group",
                table: "pc_formula_group",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_formula",
                table: "pc_formula",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_detail_type",
                table: "pc_detail_type",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_detail",
                table: "pc_detail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pc_customer",
                table: "pc_customer",
                column: "Id");
        }
    }
}

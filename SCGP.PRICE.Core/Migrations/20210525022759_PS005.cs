using Microsoft.EntityFrameworkCore.Migrations;

namespace SCGP.PRICE.Core.Migrations
{
    public partial class PS005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "Users",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "Users",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Users",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "Users",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_shipping_area",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_shipping_area",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_shipping_area",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_shipping_area",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_sale",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_sale",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_sale",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_sale",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_production_option_cost",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_production_option_cost",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_production_option_cost",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_production_option_cost",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_production_cost",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_production_cost",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_production_cost",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_production_cost",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_product_log",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_product_log",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_product_log",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_product_log",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_product",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_product",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_product",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_product",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_formula",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_formula",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_formula",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_formula",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_detail_type",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_detail_type",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_detail_type",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_detail_type",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_detail",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_detail",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_detail",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_detail",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_customer",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_customer",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_customer",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_customer",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "pr_business_unit",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "pr_business_unit",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "pr_business_unit",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "pr_business_unit",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "update_date",
                table: "Customer",
                newName: "updated_date");

            migrationBuilder.RenameColumn(
                name: "update_by",
                table: "Customer",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Customer",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "create_by",
                table: "Customer",
                newName: "created_by");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Users",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "Users",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Users",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Users",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_shipping_area",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_shipping_area",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_shipping_area",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_shipping_area",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_sale",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_sale",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_sale",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_sale",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_production_option_cost",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_production_option_cost",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_production_option_cost",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_production_option_cost",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_production_cost",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_production_cost",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_production_cost",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_production_cost",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_product_log",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_product_log",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_product_log",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_product_log",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_product",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_product",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_product",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_product",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_formula",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_formula",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_formula",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_formula",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_detail_type",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_detail_type",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_detail_type",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_detail_type",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_detail",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_detail",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_detail",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_detail",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_customer",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_customer",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_customer",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_customer",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "pr_business_unit",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "pr_business_unit",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "pr_business_unit",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "pr_business_unit",
                newName: "create_by");

            migrationBuilder.RenameColumn(
                name: "updated_date",
                table: "Customer",
                newName: "update_date");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "Customer",
                newName: "update_by");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Customer",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "Customer",
                newName: "create_by");
        }
    }
}

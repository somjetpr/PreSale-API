//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace SCGP.PRICE.Core.Migrations
//{
//    public partial class PS040 : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "pr_record_conversion");

//            migrationBuilder.DropTable(
//                name: "pr_record_detail");

//            migrationBuilder.DropTable(
//                name: "pr_record");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "pr_record",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    bag_adjust_page = table.Column<double>(type: "float", nullable: false),
//                    bag_bottom = table.Column<double>(type: "float", nullable: false),
//                    bag_gear = table.Column<double>(type: "float", nullable: false),
//                    bag_handle = table.Column<int>(type: "int", nullable: false),
//                    bag_lamination = table.Column<int>(type: "int", nullable: false),
//                    bag_length = table.Column<double>(type: "float", nullable: false),
//                    bag_page = table.Column<double>(type: "float", nullable: false),
//                    bag_patch_tape_length = table.Column<double>(type: "float", nullable: false),
//                    bag_patch_tape_width = table.Column<double>(type: "float", nullable: false),
//                    bag_pe__width = table.Column<double>(type: "float", nullable: false),
//                    bag_pe_laminate = table.Column<int>(type: "int", nullable: false),
//                    bag_pe_length = table.Column<double>(type: "float", nullable: false),
//                    bag_pe_thickness = table.Column<int>(type: "int", nullable: false),
//                    bag_plastic_type = table.Column<int>(type: "int", nullable: false),
//                    bag_width = table.Column<double>(type: "float", nullable: false),
//                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    customer_bag_combination = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    customer_bag_type = table.Column<int>(type: "int", nullable: false),
//                    customer_dealer = table.Column<int>(type: "int", nullable: false),
//                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    customer_sold_to = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    customer_vendor = table.Column<int>(type: "int", nullable: false),
//                    fc_id = table.Column<int>(type: "int", nullable: false),
//                    isActive = table.Column<bool>(type: "bit", nullable: false),
//                    laminate_value = table.Column<int>(type: "int", nullable: false),
//                    other_cost = table.Column<double>(type: "float", nullable: false),
//                    other_value_1 = table.Column<double>(type: "float", nullable: false),
//                    other_value_10 = table.Column<double>(type: "float", nullable: false),
//                    other_value_11 = table.Column<double>(type: "float", nullable: false),
//                    other_value_12 = table.Column<double>(type: "float", nullable: false),
//                    other_value_13 = table.Column<double>(type: "float", nullable: false),
//                    other_value_14 = table.Column<double>(type: "float", nullable: false),
//                    other_value_15 = table.Column<double>(type: "float", nullable: false),
//                    other_value_16 = table.Column<double>(type: "float", nullable: false),
//                    other_value_17 = table.Column<double>(type: "float", nullable: false),
//                    other_value_18 = table.Column<double>(type: "float", nullable: false),
//                    other_value_19 = table.Column<double>(type: "float", nullable: false),
//                    other_value_2 = table.Column<double>(type: "float", nullable: false),
//                    other_value_20 = table.Column<double>(type: "float", nullable: false),
//                    other_value_3 = table.Column<double>(type: "float", nullable: false),
//                    other_value_4 = table.Column<double>(type: "float", nullable: false),
//                    other_value_5 = table.Column<double>(type: "float", nullable: false),
//                    other_value_6 = table.Column<double>(type: "float", nullable: false),
//                    other_value_7 = table.Column<double>(type: "float", nullable: false),
//                    other_value_8 = table.Column<double>(type: "float", nullable: false),
//                    other_value_9 = table.Column<double>(type: "float", nullable: false),
//                    plastic_type = table.Column<int>(type: "int", nullable: false),
//                    plastic_value = table.Column<int>(type: "int", nullable: false),
//                    print_per_production_id = table.Column<int>(type: "int", nullable: false),
//                    product_bag_type = table.Column<int>(type: "int", nullable: false),
//                    product_bottom_way = table.Column<int>(type: "int", nullable: false),
//                    product_color = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    product_dealer = table.Column<int>(type: "int", nullable: false),
//                    product_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    product_domestic = table.Column<int>(type: "int", nullable: false),
//                    product_hierarchy = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    product_layer_amount = table.Column<int>(type: "int", nullable: false),
//                    product_material_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    product_unit_used = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    product_vale_depth = table.Column<double>(type: "float", nullable: false),
//                    product_valve_length = table.Column<double>(type: "float", nullable: false),
//                    product_valve_onside = table.Column<int>(type: "int", nullable: false),
//                    product_valve_type = table.Column<int>(type: "int", nullable: false),
//                    product_valve_width = table.Column<double>(type: "float", nullable: false),
//                    product_waste = table.Column<int>(type: "int", nullable: false),
//                    record_state = table.Column<int>(type: "int", nullable: false),
//                    shipping_amount = table.Column<double>(type: "float", nullable: false),
//                    shipping_amount_per_order = table.Column<double>(type: "float", nullable: false),
//                    shipping_area_id = table.Column<int>(type: "int", nullable: false),
//                    shipping_bag_compress = table.Column<int>(type: "int", nullable: false),
//                    shipping_bag_per_pack = table.Column<double>(type: "float", nullable: false),
//                    shipping_bag_per_pallet = table.Column<double>(type: "float", nullable: false),
//                    shipping_mark = table.Column<int>(type: "int", nullable: false),
//                    shipping_pack_binding = table.Column<int>(type: "int", nullable: false),
//                    shipping_packing = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    shipping_pallet_pattern = table.Column<int>(type: "int", nullable: false),
//                    shipping_pallet_per_car = table.Column<double>(type: "float", nullable: false),
//                    shipping_slot = table.Column<int>(type: "int", nullable: false),
//                    shipping_specail_spec = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    total_production_cost = table.Column<double>(type: "float", nullable: false),
//                    total_tube = table.Column<double>(type: "float", nullable: false),
//                    total_waste = table.Column<double>(type: "float", nullable: false),
//                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    vc_id = table.Column<int>(type: "int", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_pr_record", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "pr_record_conversion",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    conversion_id = table.Column<int>(type: "int", nullable: true),
//                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    isActive = table.Column<bool>(type: "bit", nullable: false),
//                    record_id = table.Column<int>(type: "int", nullable: true),
//                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    value = table.Column<double>(type: "float", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_pr_record_conversion", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_pr_record_conversion_pr_production_option_cost_conversion_id",
//                        column: x => x.conversion_id,
//                        principalTable: "pr_production_option_cost",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                    table.ForeignKey(
//                        name: "FK_pr_record_conversion_pr_record_record_id",
//                        column: x => x.record_id,
//                        principalTable: "pr_record",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateTable(
//                name: "pr_record_detail",
//                columns: table => new
//                {
//                    Id = table.Column<int>(type: "int", nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    RecordId = table.Column<int>(type: "int", nullable: true),
//                    allocation_percent = table.Column<double>(type: "float", nullable: false),
//                    created_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    grade = table.Column<int>(type: "int", nullable: false),
//                    gram = table.Column<double>(type: "float", nullable: false),
//                    isActive = table.Column<bool>(type: "bit", nullable: false),
//                    layer = table.Column<int>(type: "int", nullable: false),
//                    other_value_1 = table.Column<double>(type: "float", nullable: false),
//                    other_value_2 = table.Column<double>(type: "float", nullable: false),
//                    other_value_3 = table.Column<double>(type: "float", nullable: false),
//                    other_value_4 = table.Column<double>(type: "float", nullable: false),
//                    other_value_5 = table.Column<double>(type: "float", nullable: false),
//                    other_value_6 = table.Column<double>(type: "float", nullable: false),
//                    other_value_7 = table.Column<double>(type: "float", nullable: false),
//                    sub_type_id = table.Column<int>(type: "int", nullable: false),
//                    tube = table.Column<double>(type: "float", nullable: false),
//                    type_id = table.Column<int>(type: "int", nullable: false),
//                    updated_by = table.Column<string>(type: "nvarchar(max)", nullable: true),
//                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false),
//                    waste = table.Column<double>(type: "float", nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_pr_record_detail", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_pr_record_detail_pr_record_RecordId",
//                        column: x => x.RecordId,
//                        principalTable: "pr_record",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_pr_record_conversion_conversion_id",
//                table: "pr_record_conversion",
//                column: "conversion_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_pr_record_conversion_record_id",
//                table: "pr_record_conversion",
//                column: "record_id");

//            migrationBuilder.CreateIndex(
//                name: "IX_pr_record_detail_RecordId",
//                table: "pr_record_detail",
//                column: "RecordId");
//        }
//    }
//}

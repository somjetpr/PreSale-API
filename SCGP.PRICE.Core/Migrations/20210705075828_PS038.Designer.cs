﻿// < auto - generated />
//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
//using SCGP.PRICE.Core.Context;

//namespace SCGP.PRICE.Core.Migrations
//{
//    [DbContext(typeof(SCGPDbContext))]
//    [Migration("20210705075828_PS038")]
//    partial class PS038
//    {
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("Relational:MaxIdentifierLength", 128)
//                .HasAnnotation("ProductVersion", "5.0.5")
//                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//            modelBuilder.Entity("SCGP.PRICE.Models.Customer", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Code")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Description")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("NameEng")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("Customer");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.User", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("Email")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Image")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("IsLocked")
//                        .HasColumnType("bit");

//                    b.Property<DateTime?>("LastedLoginDate")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Mobile")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PasswordHash")
//                        .IsRequired()
//                        .HasMaxLength(130)
//                        .HasColumnType("nvarchar(130)");

//                    b.Property<string>("PasswordSalt")
//                        .IsRequired()
//                        .HasMaxLength(130)
//                        .HasColumnType("nvarchar(130)");

//                    b.Property<string>("UserName")
//                        .IsRequired()
//                        .HasMaxLength(50)
//                        .HasColumnType("nvarchar(50)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("Users");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_bag_of_type", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("group")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("type")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_bag_of_type");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_business_unit", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("business_unit")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("sub_bu")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_business_unit");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_customer", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("customer_code")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("customer_id")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_customer");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_detail", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("code")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int?>("pr_detail_typeId")
//                        .HasColumnType("int");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int>("value")
//                        .HasColumnType("int");

//                    b.HasKey("Id");

//                    b.HasIndex("pr_detail_typeId");

//                    b.ToTable("pr_detail");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_detail_type", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("bu_type")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_detail_type");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int?>("bagOftypeId")
//                        .HasColumnType("int");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("detail")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("formula_code")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("formula_group")
//                        .HasColumnType("int");

//                    b.Property<int?>("formulagroupId")
//                        .HasColumnType("int");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("type_code")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.HasIndex("bagOftypeId");

//                    b.HasIndex("formulagroupId");

//                    b.ToTable("pr_formula");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula_group", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("seq")
//                        .HasColumnType("int");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_formula_group");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula_variable", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int?>("formulaId")
//                        .HasColumnType("int");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("variable_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("formulaId");

//                    b.ToTable("pr_formula_variable");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_product", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<decimal>("cost")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("gram")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<decimal>("list_price_new")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<decimal>("list_price_old")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<int?>("pr_product_groupId")
//                        .HasColumnType("int");

//                    b.Property<string>("product_code")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("product_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("type")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("vender_Id")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("pr_product_groupId");

//                    b.ToTable("pr_product");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_product_group", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_product_group");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_product_log", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("detail")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("productr_id")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("value")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("pr_product_log");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_product_type", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("bu")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("sub_bu")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("pr_product_type");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_production_cost", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int?>("bagOftypeId")
//                        .HasColumnType("int");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int?>("formulaId")
//                        .HasColumnType("int");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<decimal>("price")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.HasIndex("bagOftypeId");

//                    b.HasIndex("formulaId");

//                    b.ToTable("pr_production_cost");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_production_option_cost", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<decimal>("cost_price")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int?>("formulaId")
//                        .HasColumnType("int");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<decimal>("sale_price")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("vender_Id")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("formulaId");

//                    b.ToTable("pr_production_option_cost");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_record", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<double>("bag_adjust_page")
//                        .HasColumnType("float");

//                    b.Property<double>("bag_bottom")
//                        .HasColumnType("float");

//                    b.Property<double>("bag_gear")
//                        .HasColumnType("float");

//                    b.Property<int>("bag_handle")
//                        .HasColumnType("int");

//                    b.Property<int>("bag_lamination")
//                        .HasColumnType("int");

//                    b.Property<double>("bag_length")
//                        .HasColumnType("float");

//                    b.Property<double>("bag_page")
//                        .HasColumnType("float");

//                    b.Property<double>("bag_patch_tape_length")
//                        .HasColumnType("float");

//                    b.Property<double>("bag_patch_tape_width")
//                        .HasColumnType("float");

//                    b.Property<double>("bag_pe__width")
//                        .HasColumnType("float");

//                    b.Property<int>("bag_pe_laminate")
//                        .HasColumnType("int");

//                    b.Property<double>("bag_pe_length")
//                        .HasColumnType("float");

//                    b.Property<int>("bag_pe_thickness")
//                        .HasColumnType("int");

//                    b.Property<int>("bag_plastic_type")
//                        .HasColumnType("int");

//                    b.Property<double>("bag_width")
//                        .HasColumnType("float");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("customer_bag_combination")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("customer_bag_type")
//                        .HasColumnType("int");

//                    b.Property<int>("customer_dealer")
//                        .HasColumnType("int");

//                    b.Property<string>("customer_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("customer_sold_to")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("customer_vendor")
//                        .HasColumnType("int");

//                    b.Property<int>("fc_id")
//                        .HasColumnType("int");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<int>("laminate_value")
//                        .HasColumnType("int");

//                    b.Property<double>("other_cost")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_1")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_10")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_11")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_12")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_13")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_14")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_15")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_16")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_17")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_18")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_19")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_2")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_20")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_3")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_4")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_5")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_6")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_7")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_8")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_9")
//                        .HasColumnType("float");

//                    b.Property<int>("plastic_type")
//                        .HasColumnType("int");

//                    b.Property<int>("plastic_value")
//                        .HasColumnType("int");

//                    b.Property<int>("print_per_production_id")
//                        .HasColumnType("int");

//                    b.Property<int>("product_bag_type")
//                        .HasColumnType("int");

//                    b.Property<int>("product_bottom_way")
//                        .HasColumnType("int");

//                    b.Property<string>("product_color")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("product_dealer")
//                        .HasColumnType("int");

//                    b.Property<string>("product_description")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("product_domestic")
//                        .HasColumnType("int");

//                    b.Property<string>("product_hierarchy")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("product_layer_amount")
//                        .HasColumnType("int");

//                    b.Property<string>("product_material_id")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("product_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("product_unit_used")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<double>("product_vale_depth")
//                        .HasColumnType("float");

//                    b.Property<double>("product_valve_length")
//                        .HasColumnType("float");

//                    b.Property<int>("product_valve_onside")
//                        .HasColumnType("int");

//                    b.Property<int>("product_valve_type")
//                        .HasColumnType("int");

//                    b.Property<double>("product_valve_width")
//                        .HasColumnType("float");

//                    b.Property<int>("product_waste")
//                        .HasColumnType("int");

//                    b.Property<int>("record_state")
//                        .HasColumnType("int");

//                    b.Property<double>("shipping_amount")
//                        .HasColumnType("float");

//                    b.Property<double>("shipping_amount_per_order")
//                        .HasColumnType("float");

//                    b.Property<int>("shipping_area_id")
//                        .HasColumnType("int");

//                    b.Property<int>("shipping_bag_compress")
//                        .HasColumnType("int");

//                    b.Property<double>("shipping_bag_per_pack")
//                        .HasColumnType("float");

//                    b.Property<double>("shipping_bag_per_pallet")
//                        .HasColumnType("float");

//                    b.Property<int>("shipping_mark")
//                        .HasColumnType("int");

//                    b.Property<int>("shipping_pack_binding")
//                        .HasColumnType("int");

//                    b.Property<string>("shipping_packing")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("shipping_pallet_pattern")
//                        .HasColumnType("int");

//                    b.Property<double>("shipping_pallet_per_car")
//                        .HasColumnType("float");

//                    b.Property<int>("shipping_slot")
//                        .HasColumnType("int");

//                    b.Property<string>("shipping_specail_spec")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<double>("total_production_cost")
//                        .HasColumnType("float");

//                    b.Property<double>("total_tube")
//                        .HasColumnType("float");

//                    b.Property<double>("total_waste")
//                        .HasColumnType("float");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int>("vc_id")
//                        .HasColumnType("int");

//                    b.HasKey("Id");

//                    b.ToTable("pr_record");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_record_conversion", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int?>("conversion_id")
//                        .HasColumnType("int");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<int?>("record_id")
//                        .HasColumnType("int");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<double>("value")
//                        .HasColumnType("float");

//                    b.HasKey("Id");

//                    b.HasIndex("conversion_id");

//                    b.HasIndex("record_id");

//                    b.ToTable("pr_record_conversion");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_record_detail", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<int?>("RecordId")
//                        .HasColumnType("int");

//                    b.Property<double>("allocation_percent")
//                        .HasColumnType("float");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int>("grade")
//                        .HasColumnType("int");

//                    b.Property<double>("gram")
//                        .HasColumnType("float");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<int>("layer")
//                        .HasColumnType("int");

//                    b.Property<double>("other_value_1")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_2")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_3")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_4")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_5")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_6")
//                        .HasColumnType("float");

//                    b.Property<double>("other_value_7")
//                        .HasColumnType("float");

//                    b.Property<int>("sub_type_id")
//                        .HasColumnType("int");

//                    b.Property<double>("tube")
//                        .HasColumnType("float");

//                    b.Property<int>("type_id")
//                        .HasColumnType("int");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<double>("waste")
//                        .HasColumnType("float");

//                    b.HasKey("Id");

//                    b.HasIndex("RecordId");

//                    b.ToTable("pr_record_detail");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_role", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_role");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_sale", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("first_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("last_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int>("status")
//                        .HasColumnType("int");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.HasKey("Id");

//                    b.ToTable("pr_sale");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_shipping_area", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("area_name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<decimal>("area_price")
//                        .HasColumnType("decimal(18,5)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<int?>("formulaId")
//                        .HasColumnType("int");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("vender_Id")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("formulaId");

//                    b.ToTable("pr_shipping_area");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_user", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int")
//                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

//                    b.Property<string>("bu")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("created_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("created_date")
//                        .HasColumnType("datetime2");

//                    b.Property<bool>("isActive")
//                        .HasColumnType("bit");

//                    b.Property<string>("name")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<int?>("pr_roleId")
//                        .HasColumnType("int");

//                    b.Property<string>("updated_by")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("updated_date")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("username")
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.HasIndex("pr_roleId");

//                    b.ToTable("pr_user");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_detail", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_detail_type", "pr_detail_type")
//                        .WithMany("pr_details")
//                        .HasForeignKey("pr_detail_typeId");

//                    b.Navigation("pr_detail_type");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_bag_of_type", "bagOftype")
//                        .WithMany("formulas")
//                        .HasForeignKey("bagOftypeId");

//                    b.HasOne("SCGP.PRICE.Models.pr_formula_group", "formulagroup")
//                        .WithMany("formulas")
//                        .HasForeignKey("formulagroupId");

//                    b.Navigation("bagOftype");

//                    b.Navigation("formulagroup");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula_variable", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_formula", "formula")
//                        .WithMany("formula_variables")
//                        .HasForeignKey("formulaId");

//                    b.Navigation("formula");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_product", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_product_group", "pr_product_group")
//                        .WithMany("products")
//                        .HasForeignKey("pr_product_groupId");

//                    b.Navigation("pr_product_group");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_production_cost", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_bag_of_type", "bagOftype")
//                        .WithMany("Costs")
//                        .HasForeignKey("bagOftypeId");

//                    b.HasOne("SCGP.PRICE.Models.pr_formula", "formula")
//                        .WithMany()
//                        .HasForeignKey("formulaId");

//                    b.Navigation("bagOftype");

//                    b.Navigation("formula");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_production_option_cost", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_formula", "formula")
//                        .WithMany()
//                        .HasForeignKey("formulaId");

//                    b.Navigation("formula");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_record_conversion", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_production_option_cost", "optionCost")
//                        .WithMany()
//                        .HasForeignKey("conversion_id");

//                    b.HasOne("SCGP.PRICE.Models.pr_record", "records")
//                        .WithMany("Conversions")
//                        .HasForeignKey("record_id");

//                    b.Navigation("optionCost");

//                    b.Navigation("records");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_record_detail", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_record", "Record")
//                        .WithMany("RecordItems")
//                        .HasForeignKey("RecordId");

//                    b.Navigation("Record");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_shipping_area", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_formula", "formula")
//                        .WithMany()
//                        .HasForeignKey("formulaId");

//                    b.Navigation("formula");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_user", b =>
//                {
//                    b.HasOne("SCGP.PRICE.Models.pr_role", "pr_role")
//                        .WithMany("users")
//                        .HasForeignKey("pr_roleId");

//                    b.Navigation("pr_role");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_bag_of_type", b =>
//                {
//                    b.Navigation("Costs");

//                    b.Navigation("formulas");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_detail_type", b =>
//                {
//                    b.Navigation("pr_details");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula", b =>
//                {
//                    b.Navigation("formula_variables");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_formula_group", b =>
//                {
//                    b.Navigation("formulas");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_product_group", b =>
//                {
//                    b.Navigation("products");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_record", b =>
//                {
//                    b.Navigation("Conversions");

//                    b.Navigation("RecordItems");
//                });

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_role", b =>
//                {
//                    b.Navigation("users");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}

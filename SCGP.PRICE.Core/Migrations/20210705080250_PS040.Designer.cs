//// <auto-generated />
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
//    [Migration("20210705080250_PS040")]
//    partial class PS040
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

//            modelBuilder.Entity("SCGP.PRICE.Models.pr_role", b =>
//                {
//                    b.Navigation("users");
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}

using SCGP.PRICE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCGP.PRICE.Core.Context
{
    public class SCGPDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<pr_detail> pr_detail { get; set; }
        public DbSet<pr_formula> pr_formula { get; set; }
        public DbSet<pr_formula_group> pr_formula_group { get; set; }
        public DbSet<pr_formula_variable> pr_formula_variable { get; set; }
        public DbSet<pr_product_log> pr_product_log { get; set; }
        public DbSet<pr_product> pr_product { get; set; }
        public DbSet<pr_product_group> pr_product_group { get; set; }
        
        public DbSet<pr_product_type> pr_product_type { get; set; }
        public DbSet<pr_production_cost> pr_production_cost { get; set; }
        public DbSet<pr_production_option_cost> pr_production_option_cost { get; set; }
        public DbSet<pr_shipping_area> pr_shipping_area { get; set; }
        public DbSet<pr_detail_type> pr_detail_type { get; set; }
        public DbSet<pr_customer> pr_customer { get; set; }
        public DbSet<pr_sale> pr_sale { get; set; }
        public DbSet<pr_role> pr_role { get; set; }
        public DbSet<pr_business_unit> pr_business_unit { get; set; }
        public DbSet<pr_bag_of_type> pr_bag_of_type { get; set; }
        public DbSet<pr_record> pr_record { get; set; }
        public DbSet<pr_record_detail> pr_record_detail { get; set; }
        public DbSet<pr_record_conversion> pr_record_conversion { get; set; }
        public SCGPDbContext(DbContextOptions<SCGPDbContext> options) : base(options) { }

        public SCGPDbContext(string connectionString)
            : base(GetOptions(connectionString))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public SCGPDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=27.254.174.144;Database=SCGP;User ID=sa; password=Information@;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Customers;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        // Customers
        public virtual DbSet<CustomerRecord> CustomerRecords { get; set; }

        // Orders
        public virtual DbSet<OrderDetailRecord> OrderDetailRecords { get; set; }

        public virtual DbSet<OrderDetailStatusRecord> OrderDetailStatusRecords { get; set; }
        public virtual DbSet<OrderRecord> OrderRecords { get; set; }
        public virtual DbSet<OrderStatusRecord> OrderStatusRecords { get; set; }

        // Products
        public virtual DbSet<ProductRecord> ProductRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfiguration(modelBuilder);
            Seed(modelBuilder);
        }

        private void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            // Customers
            modelBuilder.ApplyConfiguration(new CustomerRecordConfiguration());

            // Orders
            modelBuilder.ApplyConfiguration(new OrderDetailRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailStatusRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusRecordConfiguration());

            // Products
            modelBuilder.ApplyConfiguration(new ProductRecordConfiguration());
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            SeedEnumRecords<OrderStatusRecord, OrderStatus>(modelBuilder, e => new OrderStatusRecord { Id = (byte)e, Code = e.ToString() });
            SeedEnumRecords<OrderDetailStatusRecord, OrderItemStatus>(modelBuilder, e => new OrderDetailStatusRecord { Id = (byte)e, Code = e.ToString() });
        }

        private void SeedRecords<TRecord>(ModelBuilder modelBuilder, List<TRecord> data)
            where TRecord : class
        {
            modelBuilder.Entity<TRecord>().HasData(data);
        }

        // TODO: VC: ENum entities could inherit from base which has the property Code
        private void SeedEnumRecords<TRecord, TEnum>(ModelBuilder modelBuilder, Func<TEnum, TRecord> converter)
            where TRecord : class
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var records = values.Select(converter).ToList();

            SeedRecords<TRecord>(modelBuilder, records);
        }
    }
}
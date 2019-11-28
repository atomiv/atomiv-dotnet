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
        public virtual DbSet<CustomerRecord> Customers { get; set; }

        // Orders
        public virtual DbSet<OrderItemRecord> OrderItems { get; set; }

        public virtual DbSet<OrderItemStatusRecord> OrderItemStatuses { get; set; }
        public virtual DbSet<OrderRecord> Orders { get; set; }
        public virtual DbSet<OrderStatusRecord> OrderStatuses { get; set; }

        // Products
        public virtual DbSet<ProductRecord> Products { get; set; }

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
            modelBuilder.ApplyConfiguration(new OrderItemRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemStatusRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderRecordConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusRecordConfiguration());

            // Products
            modelBuilder.ApplyConfiguration(new ProductRecordConfiguration());
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            SeedEnumRecords<OrderStatusRecord, OrderStatus>(modelBuilder, e => new OrderStatusRecord { Id = (byte)e, Code = e.ToString() });
            SeedEnumRecords<OrderItemStatusRecord, OrderItemStatus>(modelBuilder, e => new OrderItemStatusRecord { Id = (byte)e, Code = e.ToString() });
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
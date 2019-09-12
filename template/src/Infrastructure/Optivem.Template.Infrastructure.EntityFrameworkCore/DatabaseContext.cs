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

        public virtual DbSet<CustomerRecord> Customer { get; set; }

        public virtual DbSet<ProductRecord> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurations(modelBuilder);
            SeedRecords(modelBuilder);
        }

        private void ApplyConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerRecordConfiguration());
        }

        private void SeedRecords(ModelBuilder modelBuilder)
        {
            SeedEnumRecords<OrderStatusRecord, OrderStatus>(modelBuilder, e => new OrderStatusRecord { Id = (byte)e, Code = e.ToString() });
            SeedEnumRecords<OrderDetailStatusRecord, OrderDetailStatus>(modelBuilder, e => new OrderDetailStatusRecord { Id = (byte)e, Code = e.ToString() });
        }

        private void SeedRecords<TRecord>(ModelBuilder modelBuilder, List<TRecord> data) 
            where TRecord : class
        {
            modelBuilder.Entity<TRecord>().HasData(data);
        }

        // TODO: VC: ENum entities could inherit from base which has the property Code
        private void SeedEnumRecords<TRecord, TEnum>(ModelBuilder modelBuilder, Func<TEnum, TRecord> converter) 
            where TRecord : class 
            where TEnum : Enum
        {

            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var records = values.Select(converter).ToList();

            SeedRecords<TRecord>(modelBuilder, records);
        }
    }
}
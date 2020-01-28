using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Atomiv.Infrastructure.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void Seed<TRecord>(this ModelBuilder modelBuilder, List<TRecord> data)
            where TRecord : class
        {
            modelBuilder.Entity<TRecord>().HasData(data);
        }

        // TODO: VC: ENum entities could inherit from base which has the property Code
        public static void SeedEnum<TRecord, TEnum>(this ModelBuilder modelBuilder, Func<TEnum, TRecord> converter)
            where TRecord : class
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            var records = values.Select(converter).ToList();

            Seed(modelBuilder, records);
        }
    }
}

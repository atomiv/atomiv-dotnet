using Atomiv.Test.Xunit;
using System;
using System.Collections.Generic;
using Xunit;

namespace Atomiv.Infrastructure.CsvHelper.IntegrationTest
{
    public class CsvSerializerTest
    {
        [Fact]
        public void TestSerializeGeneric()
        {
            var csvSerializer = new CsvSerializer();

            var records = CreateRecords();

            var expected = CreateContent();

            var actual = csvSerializer.Serialize(records);

            AssertUtilities.Equal(expected, actual);
        }

        [Fact]
        public void TestSerializeTyped()
        {
            var csvSerializer = new CsvSerializer();

            var records = CreateRecords();

            var expected = CreateContent();

            var actual = csvSerializer.Serialize(records, typeof(Customer));

            AssertUtilities.Equal(expected, actual);
        }

        [Fact]
        public void TestSerializeEnumerable()
        {
            var csvSerializer = new CsvSerializer();

            var records = CreateRecords();

            var expected = CreateContent();

            var actual = csvSerializer.SerializeEnumerable(records);

            AssertUtilities.Equal(expected, actual);
        }

        [Fact]
        public void TestDeserializeGeneric()
        {
            var csvSerializer = new CsvSerializer();

            var content = CreateContent();

            var expected = CreateRecords();

            var actual = csvSerializer.Deserialize<List<Customer>>(content);

            AssertUtilities.Equal(expected, actual);
        }

        [Fact]
        public void TestDeserializeTyped()
        {
            var csvSerializer = new CsvSerializer();

            var content = CreateContent();

            var expected = CreateRecords();

            var actual = csvSerializer.Deserialize(content, typeof(List<Customer>));

            AssertUtilities.Equal(expected, actual);

            Assert.IsType<List<Customer>>(actual);
        }

        [Fact]
        public void TestDeserializeEnumerable()
        {
            var csvSerializer = new CsvSerializer();

            var content = CreateContent();

            var expected = CreateRecords();

            var actual = csvSerializer.DeserializeEnumerable<Customer>(content);

            AssertUtilities.Equal(expected, actual);

            Assert.IsType<List<Customer>>(actual);
        }

        private static List<Customer> CreateRecords()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Smith",
                },

                new Customer
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };
        }

        private static string CreateContent()
        {
            List<string> lines = new List<string>
            {
                "Id,FirstName,LastName",
                "1,John,Smith",
                "2,Mary,McDonald",
            };

            var content = string.Join(Environment.NewLine, lines);

            content += Environment.NewLine;

            return content;
        }

        private class Customer
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }
    }
}
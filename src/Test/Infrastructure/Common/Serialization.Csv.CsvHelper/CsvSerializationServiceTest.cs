using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using System.Collections.Generic;
using Xunit;
using System;
using Optivem.Platform.Test.Common.Xunit;

namespace Optivem.Platform.Test.Common.Serialization
{
    public class CsvSerializationServiceTest
    {
        [Fact]
        public void TestSerializeGeneric()
        {
            var csvSerializationService = new CsvSerializationService();

            var records = CreateRecords();

            var expected = CreateContent();

            var actual = csvSerializationService.Serialize(records);

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public void TestSerializeTyped()
        {
            var csvSerializationService = new CsvSerializationService();

            var records = CreateRecords();

            var expected = CreateContent();

            var actual = csvSerializationService.Serialize(records, typeof(Customer));

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public void TestSerializeEnumerable()
        {
            var csvSerializationService = new CsvSerializationService();

            var records = CreateRecords();

            var expected = CreateContent();

            var actual = csvSerializationService.SerializeEnumerable(records);

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public void TestDeserializeGeneric()
        {
            var csvSerializationService = new CsvSerializationService();

            var content = CreateContent();

            var expected = CreateRecords();

            var actual = csvSerializationService.Deserialize<List<Customer>>(content);

            AssertUtilities.AssertEqual(expected, actual);
        }

        [Fact]
        public void TestDeserializeTyped()
        {
            var csvSerializationService = new CsvSerializationService();

            var content = CreateContent();

            var expected = CreateRecords();

            var actual = csvSerializationService.Deserialize(content, typeof(List<Customer>));

            AssertUtilities.AssertEqual(expected, actual);

            Assert.IsType<List<Customer>>(actual);
        }

        [Fact]
        public void TestDeserializeEnumerable()
        {
            var csvSerializationService = new CsvSerializationService();

            var content = CreateContent();

            var expected = CreateRecords();

            var actual = csvSerializationService.DeserializeEnumerable<Customer>(content);

            AssertUtilities.AssertEqual(expected, actual);

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

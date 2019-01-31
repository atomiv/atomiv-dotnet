using CsvHelper;
using Optivem.Platform.Infrastructure.Common.Serialization.Csv.CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using System;

namespace Optivem.Platform.Test.Common.Serialization
{
    public class CsvSerializationServiceTest
    {
        [Fact]
        public void TestDeserializeLines()
        {
            List<string> lines = new List<string>
            {
                "Id,FirstName,LastName",
                "1,John,Smith",
                "2,Mary,McDonald",
            };

            var csvReaderFactory = new CsvReaderFactory();

            var csvSerializationService = new CsvSerializationService(csvReaderFactory);

            var actual = csvSerializationService.Deserialize<Customer>(lines);

            var expected = new List<Customer>
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

            AssertUtilities.AssertEqual(expected, actual);
        }

        private class Customer
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        private class CsvReaderFactory : ICsvReaderFactory
        {
            public CsvReader Create(TextReader textReader)
            {
                return new CsvReader(textReader, true);
            }

            public CsvReader Create(string content)
            {
                var textReader = new StringReader(content);
                return new CsvReader(textReader, false);
            }

            public CsvReader Create(IEnumerable<string> content)
            {
                var contentString = string.Join(Environment.NewLine, content);
                return Create(contentString);
            }
        }
    }
}

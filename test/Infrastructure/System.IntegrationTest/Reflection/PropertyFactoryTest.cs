using Optivem.Framework.Core.Common.Reflection;
using Optivem.Framework.Infrastructure.System.IntegrationTest.Fixtures;
using Optivem.Framework.Infrastructure.System.Reflection;
using System;
using System.Linq;
using Xunit;

namespace Optivem.Framework.Infrastructure.System.IntegrationTest.Reflection
{
    public class PropertyFactoryTest
    {
        [Fact]
        public void TestCreate()
        {
            var customerRecord = new CustomerRecord
            {
                Id = 2,
                FirstName = "John",
                LastName = "Smith",
                AccountBalance = 4.56m,
                DateJoined = new DateTime(2018, 3, 15),
                IsActive = true,
            };

            IPropertyMapper<CustomerRecord> propertyFactory = new PropertyMapper<CustomerRecord>();

            var properties = propertyFactory.GetObjectProperties(customerRecord).ToList();

            Assert.Equal(6, properties.Count);

            Assert.Equal("Id", properties[0].TypeProperty.Name);
            Assert.Equal(2, properties[0].Value);
        }
    }
}
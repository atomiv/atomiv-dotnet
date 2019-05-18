using Optivem.Test.Xunit;
using Optivem.Test.Xunit.AspNetCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Optivem.Web.AspNetCore.Test
{
    public class ValuesControllerTest : ClientFixture<Client>
    {
        public ValuesControllerTest(Client client) 
            : base(client)
        {
        }

        [Fact]
        public async Task TestGetAsync()
        {
            var expected = new List<string>
            {
                "value1",
                "value2"
            };

            var actual = await Client.Values.GetAllAsync();

            AssertUtilities.AssertEqual(expected, actual);
        }
    }
}

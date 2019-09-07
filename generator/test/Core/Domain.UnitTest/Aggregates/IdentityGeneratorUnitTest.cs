
using Optivem.Generator.Core.Domain.Aggregates;
using Xunit;

namespace Optivem.Generator.Core.Domain.UnitTest.Aggregates
{
    public class IdentityGeneratorUnitTest
    {
        [Fact]
        public void TestGenerate()
        {
            var code = @"using Optivem.Framework.Core.Domain;

namespace Optivem.Generator.Core.Domain.MyCats
{
    public class MyCatIdentity : Identity<int>
    {
        public static readonly MyCatIdentity Null = new MyCatIdentity(0);

        public MyCatIdentity(int id) : base(id)
        {
        }
    }
}";

            var model = new AggregateModel("MyCat", "MyCats");

            var identityGenerator = new IdentityGenerator(model);

            var identitySourceCode = identityGenerator.Generate();

            Assert.Equal(code, identitySourceCode);
        }
    }
}

using Generator.Core.Domain.Generators;
using Generator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Generator.Core.Domain.UnitTest.Generators
{
    public class IdentityGeneratorUnitTest
    {
        [Fact]
        public void TestGenerate()
        {
            var code = @"using Atomiv.Core.Domain;

namespace Generator.Core.Domain.MyCats
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

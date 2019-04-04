using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Optivem.Commons.Parsing.Default.Test
{
    [TestClass]
    public class BooleanParserTest
    {
        [TestMethod]
        public void TestParseBoolean()
        {
            var map = new Dictionary<string, bool>
            {
                { "Yes", true },
                { "No", false },
                { "Y", true },
                { "N", false }
            };

            var parser = new BooleanMapParser(map);

            var actual = parser.Parse("No");
            var expected = false;

            Assert.AreEqual(expected, actual);
        }
    }
}

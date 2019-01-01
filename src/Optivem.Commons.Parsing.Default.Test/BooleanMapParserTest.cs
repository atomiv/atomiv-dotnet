using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optivem.Commons.Parsing.Default.Test
{
    [TestClass]
    public class BooleanMapParserTest
    {
        [TestMethod]
        public void TestParseBoolean()
        {
            var parser = new BooleanParser();

            var actual = parser.Parse("true");
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

    }
}

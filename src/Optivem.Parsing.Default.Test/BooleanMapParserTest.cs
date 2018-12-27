using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Parsing.Default.Test
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

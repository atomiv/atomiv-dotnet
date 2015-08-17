using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optivem.Immerest.Test
{
    [TestClass]
    public class BooleanParserUnitTest
    {
        [TestMethod]
        public void TestParseBoolean1()
        {
            BooleanParser parser = new BooleanParser();

            bool actual = parser.ParseBoolean("true");
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}

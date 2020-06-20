using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Commons.Parsing.Default.Test
{
    [TestClass]
    public class DateTimeParserUnitTest
    {
        [TestMethod]
        public void TestParseDateTime1()
        {
            var parser = new DateTimeParser("yyyy-MM-dd");
            var dateTimeString = "1996-04-01";
            var actual = parser.Parse(dateTimeString);
            var expected = new DateTime(1996, 4, 1);
            Assert.AreEqual(actual, expected);
        }
    }
}

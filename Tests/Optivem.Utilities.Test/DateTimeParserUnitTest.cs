using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optivem.Utilities.Test
{
    [TestClass]
    public class DateTimeParserUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void TestParseDateTime1()
        {
            DateTimeParser _parser = new DateTimeParser("yyyy-MM-dd");
            string dateTimeString = "1996-04-01";
            DateTime actual = _parser.ParseDateTime(dateTimeString);
            DateTime expected = new DateTime(1996, 4, 1);
            Assert.AreEqual(actual, expected);

        }
    }
}

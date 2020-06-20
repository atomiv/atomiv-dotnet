using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Commons.Parsing.Default.Test
{
    [TestClass]
    public class EnumStringParserUnitTest
    {
        enum Seasons { Spring, Summer, Autumn, Winter }

        [TestMethod]
        public void TestParseEnum1()
        {
            Dictionary<string, Seasons> map = new Dictionary<string, Seasons>
                {
                    { "sppringg", Seasons.Spring },
                    { "Sptring", Seasons.Spring },
                    { "Summer", Seasons.Summer },
                    { "SSS", Seasons.Summer },
                    { "suMMer", Seasons.Summer }
                };

            EnumStringParser<Seasons> parser = new EnumStringParser<Seasons>(map);

            Seasons expected = Seasons.Spring;
            Seasons actual = parser.Parse("Sptring");

            Assert.AreEqual(expected, actual);
        }
    }
}

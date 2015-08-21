// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Optivem.Immerest.Tests
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
            Seasons actual = parser.ParseEnum("Sptring");

            Assert.AreEqual(expected, actual);
        }
    }
}

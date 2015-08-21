// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optivem.Immerest.Test
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
            DateTimeParser parser = new DateTimeParser("yyyy-MM-dd");
            string dateTimeString = "1996-04-01";
            DateTime actual = parser.ParseDateTime(dateTimeString);
            DateTime expected = new DateTime(1996, 4, 1);
            Assert.AreEqual(actual, expected);
        }
    }
}

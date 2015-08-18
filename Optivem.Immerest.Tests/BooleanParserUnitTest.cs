// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestParseBoolean2()
        {
            Dictionary<string, bool> mapping = new Dictionary<string, bool>
            {
                { "Yes", true },
                { "No", false },
                { "Y", true },
                { "N", false }
            };

            BooleanParser parser = new BooleanParser(mapping);

            bool actual = parser.ParseBoolean("No");
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
    }
}

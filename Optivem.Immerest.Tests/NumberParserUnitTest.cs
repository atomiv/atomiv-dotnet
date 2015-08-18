// Copyright (c) Optivem.  Licensed under the Apache License, Version 2.0.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Optivem.Immerest.Test
{
    [TestClass]
    public class NumberParserUnitTest
    {
        private const double delta = 0.001;

        private NumberParser americanParser;
        private NumberParser europeanParser;

        [TestInitialize]
        public void Initialize()
        {
            this.americanParser = NumberParser.American;
            this.europeanParser = NumberParser.European;
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void TestParseShortAmerican()
        {
            TestShort("5", 5, americanParser);
        }

        [TestMethod]
        public void TestParseShortEuropean()
        {
            TestShort("5", 5, europeanParser);
        }

        [TestMethod]
        public void TestParseIntegerAmerican()
        {
            TestInteger("5", 5, americanParser);
        }

        [TestMethod]
        public void TestParseIntegerEuropean()
        {
            TestInteger("5", 5, europeanParser);
        }

        [TestMethod]
        public void TestParseLongAmerican()
        {
            TestLong("5", 5, americanParser);
        }

        [TestMethod]
        public void TestParseLongEuropean()
        {
            TestLong("5", 5, europeanParser);
        }

        [TestMethod]
        public void TestParseFloatAmerican()
        {
            TestFloat("5.2", (float)5.2, americanParser);
        }

        [TestMethod]
        public void TestParseFloatEuropean()
        {
            TestFloat("5,2", (float)5.2, europeanParser);
        }

        [TestMethod]
        public void TestParseDoubleAmerican()
        {
            TestDouble("5.2", (float)5.2, americanParser);
        }

        [TestMethod]
        public void TestParseDoubleEuropean()
        {
            TestDouble("5,2", (float)5.2, europeanParser);
        }

        private void TestShort(string input, short expected, NumberParser parser)
        {
            short actual = parser.ParseShort(input);
            Assert.AreEqual(actual, expected);
        }

        private void TestInteger(string input, int expected, NumberParser parser)
        {
            int actual = parser.ParseInteger(input);
            Assert.AreEqual(actual, expected);
        }

        private void TestLong(string input, long expected, NumberParser parser)
        {
            long actual = parser.ParseLong(input);
            Assert.AreEqual(actual, expected);
        }

        private void TestFloat(string input, float expected, NumberParser parser)
        {
            float actual = parser.ParseFloat(input);
            Assert.AreEqual(actual, expected, delta);
        }

        private void TestDouble(string input, double expected, NumberParser parser)
        {
            double actual = parser.ParseDouble(input);
            Assert.AreEqual(actual, expected, delta);
        }
    }
}

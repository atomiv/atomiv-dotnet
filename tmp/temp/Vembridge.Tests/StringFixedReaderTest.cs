// Copyright (c)   Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Vembridge.Tests
{
    [TestClass]
    public class StringFixedReaderTest
    {
        [TestMethod]
        public void TestRead()
        {
            List<FixedFieldFormat> formats = new List<FixedFieldFormat>
            {
                new FixedFieldFormat(0, 5),
                new FixedFieldFormat(5, 3)
            };

            string content = "abcde123\nhijkl456\nstuvw789";

            string[] expectedFirst = new string[] { "abcde", "123" };
            string[] expectedSecond = new string[] { "hijkl", "456" };
            string[] expectedThird = new string[] { "stuvw", "789" };

            List<string[]> records = new List<string[]>();

            using (StringReader textReader = new StringReader(content))
            {
                StringFixedReader reader = new StringFixedReader(textReader, formats);

                string[] actualFirst = reader.Read();
                Assert.IsNotNull(actualFirst);
                CollectionAssert.AreEqual(expectedFirst, actualFirst);

                string[] actualSecond = reader.Read();
                Assert.IsNotNull(actualSecond);
                CollectionAssert.AreEqual(expectedSecond, actualSecond);

                string[] actualThird = reader.Read();
                Assert.IsNotNull(actualThird);
                CollectionAssert.AreEqual(expectedThird, actualThird);

                string[] actualFourth = reader.Read();
                Assert.IsNull(actualFourth);
            }

        }

        [TestMethod]
        public void TestReadToEnd()
        {
            List<FixedFieldFormat> formats = new List<FixedFieldFormat>
            {
                new FixedFieldFormat(0, 5),
                new FixedFieldFormat(5, 3)
            };

            string content = "abcde123\nhijkl456\nstuvw789";

            string[] expectedFirst = new string[] { "abcde", "123" };
            string[] expectedSecond = new string[] { "hijkl", "456" };
            string[] expectedThird = new string[] { "stuvw", "789" };

            int expectedLength = 3;

            using (StringReader textReader = new StringReader(content))
            {
                StringFixedReader reader = new StringFixedReader(textReader, formats);

                List<string[]> records = reader.ReadToEnd();
                Assert.AreEqual(expectedLength, records.Count);

                string[] actualFirst = records[0];
                Assert.IsNotNull(actualFirst);
                CollectionAssert.AreEqual(expectedFirst, actualFirst);

                string[] actualSecond = records[1];
                Assert.IsNotNull(actualSecond);
                CollectionAssert.AreEqual(expectedSecond, actualSecond);

                string[] actualThird = records[2];
                Assert.IsNotNull(actualThird);
                CollectionAssert.AreEqual(expectedThird, actualThird);
            }
        }
    }
}

// Copyright (c)   Licensed under the Apache License, Version 2.0. See the LICENSE file in the root of the project.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace Vembridge
{
    [TestClass]
    public class StringDelimitedReaderTest
    {
        [TestMethod]
        public void TestRead()
        {
            string delimiter = ",";
            string content = "a,b\nc,d\ne,f";

            string[] expectedFirst = new string[] { "a", "b" };
            string[] expectedSecond = new string[] { "c", "d" };
            string[] expectedThird = new string[] { "e", "f" };

            List<string[]> records = new List<string[]>();

            using (StringReader textReader = new StringReader(content))
            {
                StringDelimitedReader reader = new StringDelimitedReader(textReader, delimiter);

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
            string delimiter = ",";
            string content = "a,b\nc,d\ne,f";

            string[] expectedFirst = new string[] { "a", "b" };
            string[] expectedSecond = new string[] { "c", "d" };
            string[] expectedThird = new string[] { "e", "f" };

            int expectedLength = 3;

            using (StringReader textReader = new StringReader(content))
            {
                StringDelimitedReader reader = new StringDelimitedReader(textReader, delimiter);

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

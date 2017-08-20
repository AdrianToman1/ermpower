using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTests.Files;

namespace UnitTests.Processors
{
    [TestClass()]
    public class RecordReaderTests
    {
        MockRecordReader target;

        [TestInitialize()]
        public void TestInit()
        {
            //target = new MockRecordReader();
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            if (target != null)
            {
                target.Dispose();
                target = null;
            }
        }

        [TestMethod()]
        public void RecordReaderConstructorNullParameterTest()
        {
            try
            {
                target = new MockRecordReader(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void RecordReaderConstructorEmptyStringParameterTest()
        {
            try
            {
                target = new MockRecordReader(string.Empty);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void RecordReaderConstructorWhitespaceParameterTest()
        {
            try
            {
                target = new MockRecordReader(" ");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void RecordReaderConstructorTest()
        {
            new MockRecordReader(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv");
        }
    }
}
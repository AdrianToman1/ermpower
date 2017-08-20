using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERMPower.Files;
using System;
using ERMPower.Processors;

namespace UnitTests.Processors
{
    [TestClass()]
    public class ProcessorTests
    {
        MockProcessor target;

        [TestInitialize()]
        public void TestInit()
        {
            //target = new MockProcessor();
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
        public void ProcessorConstructorNullParameterTest()
        {
            try
            {
                target = new MockProcessor(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void ProcessorConstructorEmptyStringParameterTest()
        {
            try
            {
                target = new MockProcessor(string.Empty);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void ProcessorConstructorWhiteSpaceParameterTest()
        {
            try
            {
                target = new MockProcessor(" ");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void ProcessorConstructorTest1()
        {
            target = new MockProcessor(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv");

            PrivateObject privateObject = new PrivateObject(target);

            Assert.IsInstanceOfType(privateObject.GetProperty("Reader"), typeof(LPRecordReader));
        }

        [TestMethod()]
        public void ProcessorConstructorTest2()
        {
            target = new MockProcessor(@"..\..\..\Sample Files\TOU_212621145_20150911T022358.csv");

            PrivateObject privateObject = new PrivateObject(target);

            Assert.IsInstanceOfType(privateObject.GetProperty("Reader"), typeof(TOURecordReader));
        }

        [TestMethod()]
        public void ProcessorRecordReaderFactoryNullParameterTest()
        {
            try
            {
                Processor.ProcessorRecordReaderFactory(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void ProcessorRecordReaderFactoryEmptyStringParameterTest()
        {
            try
            {
                Processor.ProcessorRecordReaderFactory(string.Empty);
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void ProcessorRecordReaderFactoryWhiteSpaceParameterTest()
        {
            try
            {
                Processor.ProcessorRecordReaderFactory(" ");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void ProcessorRecordReaderFactoryLPTest()
        {
            Assert.IsInstanceOfType(Processor.ProcessorRecordReaderFactory(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv"), typeof(LPRecordReader));
        }

        [TestMethod()]
        public void ProcessorRecordReaderFactoryTOUTest1()
        {
            Assert.IsInstanceOfType(Processor.ProcessorRecordReaderFactory(@"..\..\..\Sample Files\TOU_212621145_20150911T022358.csv"), typeof(TOURecordReader));
        }

        [TestMethod()]
        public void ProcessorRecordReaderFactoryUnknowTest()
        {
            try
            {
                Processor.ProcessorRecordReaderFactory("XXXX");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual(e.ParamName, "path");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }
    }
}
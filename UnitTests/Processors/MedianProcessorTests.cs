using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERMPower.Files;
using System;
using ERMPower.Processors;

namespace UnitTests.Processors
{
    [TestClass()]
    public class MedianProcessorTests
    {
        MedianProcessor target;

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
        public void MedianProcessorConstructorTest()
        {
            target = new MedianProcessor(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv");
            Assert.IsNull(target.Result);
        }
    }
}
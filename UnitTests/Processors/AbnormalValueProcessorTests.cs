using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERMPower.Files;
using System;
using ERMPower.Processors;

namespace UnitTests.Processors
{
    [TestClass()]
    public class AbnormalValueProcessorTests
    {
        AbnormalValueProcessor target;

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
            decimal expectedMedian = 2m;
            decimal expectedMaxVariancePercentage = 0.2m;
            Action<string> expectedOutputDelegate = s => { return; };

            target = new AbnormalValueProcessor(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv", expectedMedian, expectedMaxVariancePercentage, expectedOutputDelegate);

            PrivateObject privateObject = new PrivateObject(target);

            Assert.AreEqual(expectedMedian, privateObject.GetProperty("Median"));
            Assert.AreEqual(expectedMaxVariancePercentage, privateObject.GetProperty("MaxVariancePercentage"));
            Assert.AreEqual(expectedOutputDelegate, privateObject.GetProperty("OutputDelegate"));
            Assert.AreEqual(1.6m, privateObject.GetProperty("MaxVarianceLowerLimit"));
            Assert.AreEqual(2.4m, privateObject.GetProperty("MaxVarianceUpperLimit"));
        }
    }
}
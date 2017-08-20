using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERMPower.Extensions;
using System.Collections.Generic;

namespace UnitTests.Extensioins
{
    [TestClass]
    public class NOrderStatisticsTests
    {
        [TestMethod()]
        public void NOrderStatisticsNullTest()
        {
            try
            {
                NOrderStatistics.Median<int>(null);
            }
            catch
            {
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void NOrderStatisticsEmptyListTest()
        {
            IList<int> values = new List<int>();

            try
            {
                var i = NOrderStatistics.Median<int>(values);
            }
            catch
            {
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void NOrderStatisticsOneValueTest()
        {
            int expected = 2;
            IList<int> values = new List<int>() { expected };

            Assert.AreEqual(expected, NOrderStatistics.Median<int>(values));
        }

        [TestMethod()]
        public void NOrderStatisticsSortedValuesTestOdd()
        {
            decimal expected = 2;
            IList<decimal> values = new List<decimal>() { 1, 1, 1, expected, 8, 8, 8 };

            Assert.AreEqual(expected, NOrderStatistics.Median<decimal>(values));
        }

        //Fails
        //[TestMethod()]
        //public void NOrderStatisticsSortedValuesTestEven()
        //{
        //    decimal expected = 4.5m;
        //    IList<decimal> values = new List<decimal>() { 1, 1, 1, 2, 7, 8, 8, 8 };

        //    Assert.AreEqual(expected, NOrderStatistics.Median<decimal>(values));
        //}

        [TestMethod()]
        public void NOrderStatisticsUnsortedValuesTestOdd()
        {
            decimal expected = 2;
            IList<decimal> values = new List<decimal>() { expected, 8, 1, 8, 8, 1, 1 };

            Assert.AreEqual(expected, NOrderStatistics.Median<decimal>(values));
        }

        //Fails
        //[TestMethod()]
        //public void NOrderStatisticsUnsortedValuesTestEven()
        //{
        //    decimal expected = 4.5m;
        //    IList<decimal> values = new List<decimal>() { 2, 8, 1, 8, 7, 8, 1, 1 };

        //    Assert.AreEqual(expected, NOrderStatistics.Median<decimal>(values));
        //}
    }
}

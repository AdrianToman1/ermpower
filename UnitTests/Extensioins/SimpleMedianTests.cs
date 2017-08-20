using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERMPower.Extensions;
using System.Collections.Generic;
using System;

namespace UnitTests.Extensioins
{
    [TestClass]
    public class SimpleMedianTests
    {
        [TestMethod()]
        public void SimpleMedianNullTest()
        {
            try
            {
                SimpleMedian.GetSimpleMedian(null);
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual(e.ParamName, "list");
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        [TestMethod()]
        public void SimpleMedianEmptyListTest()
        {
            IList<decimal> values = new List<decimal>();

            Assert.ThrowsException<InvalidOperationException>(() => SimpleMedian.GetSimpleMedian(values));
        }

        [TestMethod()]
        public void SimpleMedianOneValueTest()
        {
            int expected = 2;
            IList<decimal> values = new List<decimal>() { expected };

            Assert.AreEqual(expected, SimpleMedian.GetSimpleMedian(values));
        }

        [TestMethod()]
        public void SimpleMedianSortedValuesTestOdd()
        {
            decimal expected = 2;
            IList<decimal> values = new List<decimal>() { 1, 1, 1, expected, 8, 8, 8 };

            Assert.AreEqual(expected, SimpleMedian.GetSimpleMedian(values));
        }

        [TestMethod()]
        public void SimpleMedianSortedValuesTestEven()
        {
            decimal expected = 4.5m;
            IList<decimal> values = new List<decimal>() { 1, 1, 1, 2, 7, 8, 8, 8 };

            Assert.AreEqual(expected, SimpleMedian.GetSimpleMedian(values));
        }

        [TestMethod()]
        public void SimpleMedianSortValuesTestOdd()
        {
            decimal expected = 2;
            IList<decimal> values = new List<decimal>() { expected, 8, 1, 8, 8, 1, 1 };

            Assert.AreEqual(expected, SimpleMedian.GetSimpleMedian(values));
        }

        [TestMethod()]
        public void SimpleMedianUnsortedValuesTestEven()
        {
            decimal expected = 4.5m;
            IList<decimal> values = new List<decimal>() { 2, 8, 1, 8, 7, 8, 1, 1 };

            Assert.AreEqual(expected, SimpleMedian.GetSimpleMedian(values));
        }
    }
}

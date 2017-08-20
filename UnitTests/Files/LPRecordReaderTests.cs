using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERMPower.Files.Tests
{
    [TestClass()]
    public class LPRecordReaderTests
    {
        LPRecordReader target;

        [TestInitialize()]
        public void TestInit()
        {
            target = new LPRecordReader(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv");
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
        public void LPRecordReaderInflateRecordTest()
        {
            PrivateObject privateObject = new PrivateObject(target);

            string[] expected = { "210095893", "210095893unique", "ED031000001", @"31/08/2015 19:30:00", "Import Wh Total", "1.230000", "kwh", "" };

            LPRecord record = (LPRecord)privateObject.Invoke("InflateRecord", new object[] { expected });

            Assert.AreEqual(expected[0], record.MeterPointCode);
            Assert.AreEqual(expected[1], record.SerialNumber);
            Assert.AreEqual(expected[2], record.PlantCode);
            Assert.AreEqual(expected[3], record.DateTime.ToString("dd/MM/yyyy HH:mm:ss"));
            Assert.AreEqual(expected[4], record.DataType);
            Assert.AreEqual(expected[5], record.DataValue.ToString());
            Assert.AreEqual(expected[6], record.Units);
            Assert.AreEqual(expected[7], record.Status);
        }
    }
}
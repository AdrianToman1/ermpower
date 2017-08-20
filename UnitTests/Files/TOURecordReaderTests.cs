using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERMPower.Files.Tests
{
    [TestClass()]
    public class TOURecordReaderTests
    {
        TOURecordReader target;

        [TestInitialize()]
        public void TestInit()
        {
            target = new TOURecordReader(@"..\..\..\Sample Files\LP_210095893_20150901T011608049.csv");
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

            string[] expected = { "214667141", "214667141unqiue", "ED071500133", "01/09/2015 19:30:00", "Export Wh Total", "0.146000", "0.008000", "27/08/2015 17:30:00", "kwh", ".....R....", "Previous", "False", "2", "01/09/2015 00:00:00", "Unified" };

            TOURecord record = (TOURecord)privateObject.Invoke("InflateRecord", new object[] { expected });

            Assert.AreEqual(expected[0], record.MeterPointCode);
            Assert.AreEqual(expected[1], record.SerialNumber);
            Assert.AreEqual(expected[2], record.PlantCode);
            Assert.AreEqual(expected[3], record.DateTime.ToString("dd/MM/yyyy HH:mm:ss"));
            Assert.AreEqual(expected[4], record.DataType);
            Assert.AreEqual(expected[5], record.Energy.ToString());
            Assert.AreEqual(expected[6], record.MaximumDemand);
            Assert.AreEqual(expected[7], record.TimeOfMaxDemand);
            Assert.AreEqual(expected[8], record.Units);
            Assert.AreEqual(expected[9], record.Status);
            Assert.AreEqual(expected[10], record.Period);
            Assert.AreEqual(expected[11], record.DLSActive);
            Assert.AreEqual(expected[12], record.BillingResetCount);
            Assert.AreEqual(expected[13], record.BillingResetDateTime);
            Assert.AreEqual(expected[14], record.Rate);
        }
    }
}
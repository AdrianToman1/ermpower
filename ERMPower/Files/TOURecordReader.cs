using System;

namespace ERMPower.Files
{
    /// <summary>
    /// Implements a RecordReader that reads TOURecords from a "TOU" file type.
    /// </summary>
    public class TOURecordReader : RecordReader<TOURecord>
    {
        /// <summary>
        /// Initialises a new instance of the TOURecordReader class for the specified  file name.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        public TOURecordReader(string path) : base(path)
        {
            // Throw the header on the first line away;
            Reader.ReadLine();
        }

        /// <summary>
        /// Creates a TOURecord object for a single line of data from the file.
        /// </summary>
        /// <param name="data">A parsed line of data from the current stream.</param>
        /// <returns>A TOURecord object representing the data.</returns>
        protected override TOURecord InflateRecord(string[] data)
        {
            TOURecord record = new TOURecord();
            record.MeterPointCode = data[0];
            record.SerialNumber = data[1];
            record.PlantCode = data[2];
            record.DateTime = DateTime.Parse(data[3]);
            record.DataType = data[4];
            record.Energy = Decimal.Parse(data[5]);
            record.MaximumDemand = data[6];
            record.TimeOfMaxDemand = data[7];
            record.Units = data[8];
            record.Status = data[9];
            record.Period = data[10];
            record.DLSActive = data[11];
            record.BillingResetCount = data[12];
            record.BillingResetDateTime = data[13];
            record.Rate = data[14];
            return record;
        }
    }
}

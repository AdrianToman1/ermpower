using System;

namespace ERMPower.Files
{
    /// <summary>
    /// Implements a RecordReader that reads LPRecords from a "LP" file type.
    /// </summary>
    public class LPRecordReader : RecordReader<LPRecord>
    {
        /// <summary>
        /// Initialises a new instance of the TOURecordReader class for the specified  file name.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        public LPRecordReader(string path) : base(path)
        {
            // Throw the header on the first line away;
            Reader.ReadLine();
        }

        /// <summary>
        /// Creates a LPRecord object for a single line of data from the file.
        /// </summary>
        /// <param name="data">A parsed line of data from the current stream.</param>
        /// <returns>>A LPRecord object representing the data.</returns>
        protected override LPRecord InflateRecord(string[] data)
        {
            LPRecord record = new LPRecord();
            record.MeterPointCode = data[0];
            record.SerialNumber = data[1];
            record.PlantCode = data[2];
            record.DateTime = DateTime.Parse(data[3]);
            record.DataType = data[4];
            record.DataValue = Decimal.Parse(data[5]);
            record.Units = data[6];
            record.Status = data[7];
            return record;
        }
    }
}

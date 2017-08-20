using ERMPower.Processors;
using System;

namespace ERMPower.Files
{
    /// <summary>
    /// Record in LP file.
    /// </summary>
    /// <remarks>
    /// Using a simple string data type for any field that isn't used.
    /// 
    /// Implements IProcessorRecord to allow process to access required fields.
    /// </remarks>
    public class LPRecord : IProcessorRecord
    {
        public string MeterPointCode { get; set; }
        public string SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime DateTime { get; set; }
        public string DataType { get; set; }
        public Decimal DataValue { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }

        decimal IProcessorRecord.Value => DataValue;
    }
}

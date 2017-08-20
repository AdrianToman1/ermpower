using ERMPower.Processors;
using System;

namespace ERMPower.Files
{
    /// <summary>
    /// Record in TOU file.
    /// </summary>
    /// <remarks>
    /// Using a simple string data type for any field that isn't used.
    /// 
    /// Implements IProcessorRecord to allow process to access required fields.
    /// </remarks>
    public class TOURecord : IProcessorRecord
    {
        public string MeterPointCode { get; set; }
        public string SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime DateTime { get; set; }
        public string DataType { get; set; }
        public Decimal Energy { get; set; }
        public string MaximumDemand { get; set; }
        public string TimeOfMaxDemand { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
        public string Period { get; set; }
        public string DLSActive { get; set; }
        public string BillingResetCount { get; set; }
        public string BillingResetDateTime { get; set; }
        public string Rate { get; set; }

        decimal IProcessorRecord.Value => Energy;
    }
}

using ERMPower.Files;
using ERMPower.Processors;

namespace UnitTests.Files
{
    public class MockRecordReader : RecordReader<IProcessorRecord>
    {
        public MockRecordReader(string path) : base(path)
        {
        }

        public string[] Data { get; set; }

        protected override IProcessorRecord InflateRecord(string[] data)
        {
            Data = data;
            return null;
        }
    }
}

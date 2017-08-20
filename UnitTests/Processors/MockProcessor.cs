using System;
using ERMPower.Processors;

namespace UnitTests.Processors
{
    public class MockProcessor : Processor
    {
        public MockProcessor(string path) : base(path)
        {
        }

        public override void Process()
        {
            throw new NotImplementedException();
        }
    }
}

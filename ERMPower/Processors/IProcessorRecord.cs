using System;

namespace ERMPower.Processors
{
    /// <summary>
    /// Record used in processors.
    /// </summary>
    public interface IProcessorRecord
    {
        DateTime DateTime { get; }
        decimal Value { get; }
    }
}

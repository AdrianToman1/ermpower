using System;

namespace ERMPower.Processors
{
    /// <summary>
    /// RecordReader used in processors
    /// </summary>
    public interface IProcessorRecordReader : IDisposable
    {
        /// <summary>
        /// Reads a line of from the current stream and returns the data as an IProcessorRecord.
        /// </summary>
        /// <returns>The next line from the current stream, or null if the end of the current stream is reached.</returns>
        IProcessorRecord NextRecord();
    }
}

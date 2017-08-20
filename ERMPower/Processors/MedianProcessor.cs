using ERMPower.Extensions;
using System.Collections.Generic;

namespace ERMPower.Processors
{
    /// <summary>
    /// Finds the median of IProcessorRecord.Value from a file.
    /// </summary>
    public class MedianProcessor : Processor
    {
        /// <summary>
        /// Initialises a new instance of the MedianProcessor class for the specified file name.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        public MedianProcessor(string path) : base(path)
        {
            // Providing a capacity could improve performance for very large files.
            Values = new List<decimal>();
            Result = null;
        }

        /// <summary>
        /// A unsort collection of IProcessorRecord.Value for the file.
        /// </summary>
        private IList<decimal> Values { get; set; }

        /// <summary>
        /// The median of Values, null if process hasn't completed.
        /// </summary>
        public decimal? Result { get; private set; }

        /// <summary>
        /// Excutes the calculation of the median on the file.
        /// </summary>
        /// <remarks>
        /// Using the simple median algorithm as that produces a value more correct for size of the sample data size.
        /// </remarks>
        public override void Process()
        {
            IProcessorRecord record;

            while ((record = Reader.NextRecord()) != null)
            {
                Values.Add(record.Value);
            }

            Result = Values.GetSimpleMedian();
        }
    }
}

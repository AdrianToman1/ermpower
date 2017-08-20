using System;

namespace ERMPower.Processors
{
    /// <summary>
    /// Reports IProcessorRecords from a file that have a value outside maxVariancePercentage of the median.
    /// </summary>
    public class AbnormalValueProcessor : Processor
    {
        /// <summary>
        /// Initialises a new instance of the AbnormalValueProcessor class for the specified file name.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        /// <param name="median">The median value of IProcessorRecords.Values in the file.</param>
        /// <param name="maxVariancePercentage">The percentage variance</param>
        /// <param name="outputDelegate">Delegate to call to output results</param>
        public AbnormalValueProcessor(string path, Decimal median, Decimal maxVariancePercentage, Action<string> outputDelegate) 
            : base(path)
        {
            Median = median;
            MaxVariancePercentage = maxVariancePercentage;
            OutputDelegate = outputDelegate ?? throw new ArgumentNullException("outputDelegate");

            // Calculate the limits now to avoid doing it for every record.
            MaxVarianceLowerLimit = Median * (1 - MaxVariancePercentage);
            MaxVarianceUpperLimit = Median * (1 + MaxVariancePercentage);
        }

        private Decimal Median { get; set; }
        private Decimal MaxVariancePercentage { get; set; }
        private Action<string> OutputDelegate { get; set; }

        /// <summary>
        /// Lower limit of normal IProcessorRecords.Value.
        /// </summary>
        private Decimal MaxVarianceLowerLimit { get; set; }

        /// <summary>
        /// Upper limit of normal IProcessorRecords.Value.
        /// </summary>
        private Decimal MaxVarianceUpperLimit { get; set; }

        /// <summary>
        /// Excutes the report of abnormal IProcessorRecords.Value from the file.
        /// </summary>
        public override void Process()
        {
            IProcessorRecord record;

            while ((record = Reader.NextRecord()) != null)
            {
                if (record.Value < MaxVarianceLowerLimit || record.Value > MaxVarianceUpperLimit)
                {
                    OutputDelegate($"{Path} {record.DateTime} {record.Value} {Median}");
                }
            }
        }
    }
}

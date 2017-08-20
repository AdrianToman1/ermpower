using ERMPower.Processors;
using System;
using System.Collections.Generic;
using System.IO;

namespace ERMPower
{
    class Program
    {
        /// <summary>
        /// Program entry.
        /// </summary>
        /// <param name="args">The complete file paths to be read.</param>
        static void Main(string[] args)
        {
            IList<string> fileNames = new List<string>(args);

            foreach (string fileName in fileNames)
            {
                try
                {
                    ProcessFile(fileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            Console.WriteLine("Processing Complete - Press any key to exit.");
            Console.Read();
        }

        /// <summary>
        /// Executes the processors for a single file.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        /// <remarks>
        /// More processors can be simply added within this method.
        /// </remarks>
        static void ProcessFile(string path)
        {
            if (File.Exists(path))
            {
                Processor medianProcessor = new MedianProcessor(path);
                medianProcessor.Process();
                decimal median = (medianProcessor as MedianProcessor).Result.Value;
                medianProcessor.Dispose();

                Processor abnormalValueProcessor = new AbnormalValueProcessor(path, median, 0.2m, s => Console.WriteLine(s));
                abnormalValueProcessor.Process();
                abnormalValueProcessor.Dispose();

                // Add more processors here
            }
            else
            {
                throw new ArgumentException($"{path} does not exist", "path");
            }
        }
    }
}

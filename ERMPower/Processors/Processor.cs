using ERMPower.Files;
using System;

namespace ERMPower.Processors
{
    /// <summary>
    /// Represent a process to be executed on a file.
    /// </summary>
    public abstract class Processor
    {
        /// <summary>
        /// Initialises a new instance of the Processor class for the specified file name.
        /// </summary>
        /// <param name="path">The complete file path to be processed.</param>
        public Processor(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Value can not be empty or whitespace.", "path");
            }

            Path = path;
            Reader = ProcessorRecordReaderFactory(path); 
        }

        protected string Path { get; private set; }

        /// <summary>
        /// IProcessorRecordReader that will be used to read the contents of the file.
        /// </summary>
        protected IProcessorRecordReader Reader { get; private set; }

        /// <summary>
        /// Excutes the process on the file.
        /// </summary>
        public abstract void Process();

        public void Dispose()
        {
            Reader.Dispose();
        }

        /// <summary>
        /// Factory method that returns the appropriate IProcessRecordReader for the file type.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static IProcessorRecordReader ProcessorRecordReaderFactory(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Value can not be empty or whitespace.", "path");
            }

            string filename = System.IO.Path.GetFileName(path);

            if (filename.StartsWith("LP"))
            {
                return new LPRecordReader(path);
            }
            else if (filename.StartsWith("TOU"))
            {
                return new TOURecordReader(path);
            }
            else
            {
                throw new ArgumentOutOfRangeException("path", "Unrecognised file type");
            }
        }
    }
}

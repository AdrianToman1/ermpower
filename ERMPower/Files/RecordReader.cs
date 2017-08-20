using ERMPower.Processors;
using System;
using System.IO;

namespace ERMPower.Files
{
    /// <summary>
    /// Reads a sequential series of records from a CSV file.
    /// </summary>
    /// <typeparam name="T">The type of records in the file.</typeparam>
    /// <remarks>
    /// Wraps a StreamReader to read a line from a file. Classes that implement
    /// the RecordReader are responsible for taking a parsed line of data from 
    /// the CSV file and using it to inflate and object of type T.
    /// 
    /// Implements IProcessorRecordReader so the class can be injected into processors.
    /// </remarks>
    public abstract class RecordReader<T> : IProcessorRecordReader where T: IProcessorRecord
    {
        private const char delimiter = ',';

        /// <summary>
        /// Initialises a new instance of the RecordReader class for the specified file name.
        /// </summary>
        /// <param name="path">The complete file path to be read.</param>
        public RecordReader(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Value can not be empty or whitespace.", "path");
            }

            Reader = new StreamReader(path);
        }

        /// <summary>
        /// Wrapped StreamReader object.
        /// </summary>
        protected StreamReader Reader { get; private set; }

        /// <summary>
        /// Reads a line of from the current stream and returns the data as an object of T.
        /// </summary>
        /// <returns>The next line from the current stream, or null if the end of the current stream is reached.</returns>
        public T NextRecord()
        {
            string s = Reader.ReadLine();

            if (s != null)
            {
                return InflateRecord(s.Split(delimiter));
            }
            else
            {
                return default(T);
            }
        }

        IProcessorRecord IProcessorRecordReader.NextRecord()
        {
            return NextRecord();
        }

        /// <summary>
        /// Creates a record object for a single line of data from the file.
        /// </summary>
        /// <param name="data">A parsed line of data from the current stream.</param>
        /// <returns>A record object representing the data.</returns>
        protected abstract T InflateRecord(string[] data);

        public void Dispose()
        {
            Reader.Close();
            Reader.Dispose();
        }
    }
}

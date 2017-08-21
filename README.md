
## Execution

ERMPower.exe accepts a space delimited list of files.

```
ERMPower.exe "..\..\..\Sample Files\LP_210095893_20150901T011608049.csv" "..\..\..\Sample Files\LP_214612534_20150907T084333712.csv" "..\..\..\Sample Files\LP_214612653_20150907T220027915.csv" "..\..\..\Sample Files\TOU_212621145_20150911T022358.csv" "..\..\..\Sample Files\TOU_212621147_20150911T022240.csv" "..\..\..\Sample Files\TOU_214667141_20150901T040057.csv"
```

## Further Questions

**_1. Your program structure should ideally allow easy adding of new processors._**

To create a new processor, implement the `ERMPower.Processors.Processor` abstract class. Calls to all processors are made from the `ProcessFile` method of `ERMPower.Program`. Due to the potential complexity of handling configuration, and passing data between processors, I choose this simple structure.

The alternatively way of easily adding new processors is a processor pipeline. Processors would be delegates with a signature of `Action<IDictionary<string, object>>`. The dictionary passed into the processor delegate would contain any configuration information and could be used to pass data to later processors. Processor delegates could be stored in an `IEnumerable` and executed in turn for each file.

**_2. What happens if the file size is huge (1 GB+)?_**

I am reading records from files as a stream. A stream approach is more memory efficient than loading the entire file into memory, especially if the files are huge.

I am using a simple median calculation algorithm to calculate the median (`ERMPower.Extensions.SimpleMedian`). While this does give an accurate median for the sample files, it’s execution time is O(n log n) and wouldn’t be suitable for huge files. 

There exist other algorithms that can calculate the median in O(n) time. I have included an example at `ERMPower.Extensions.NOrderStatistics`. From what I understand, these algorithms return an “estimated” median, and that may be good enough depending on the characteristics of the data. 

I tested the `ERMPower.Extensions.NOrderStatistics` median calculation algorithm on the sample files, but it didn’t return an accurate value.

The requirement that all values used to calculate the mean need to be stored in an in memory collection is the biggest constraint of the program in the context of processing huge files. The number of records in any file is capped to 2.1 billion, and this cap can only be reached on 64-bit platforms with sufficient memory (> 8+ GB). Based on the record widths it would take file over 150 GB would be to reach that cap. 

The building of the in memory collection of value for the median calculation can be made more efficient by creating a new processor that counts the number of records in the file. The record count can be used to create a collection of the required size eliminating the need to grow the collection in memory.

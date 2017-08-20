using System;
using System.Collections.Generic;
using System.Linq;

namespace ERMPower.Extensions
{
    /// <summary>
    /// Simple median alogrithm to find the median in O(n log n) time.
    /// </summary>
    /// <remarks>
    /// More suitable for small samples.
    /// </remarks>
    public static class SimpleMedian
    {
        public static decimal GetSimpleMedian(this IList<decimal> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            // Create a copy of the input, and sort the copy
            decimal[] temp = list.ToArray();
            Array.Sort(temp);

            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                // count is even, average two middle elements
                decimal a = temp[count / 2 - 1];
                decimal b = temp[count / 2];
                return (a + b) / 2m;
            }
            else
            {
                // count is odd, return the middle element
                return temp[count / 2];
            }
        }
    }
}

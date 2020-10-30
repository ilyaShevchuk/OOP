using System;
using System.Collections.Generic;

namespace lab2
{
    public static class ListOfOutsExtensions
    {
        public static List<OutInfo> Print(this List<OutInfo> outs)
        {
            foreach (var info in outs)
            {
                Console.WriteLine($"{info.Count} ${info.Name}");
            }

            return outs;
        }
    }
}
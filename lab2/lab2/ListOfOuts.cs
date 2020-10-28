using System;
using System.Collections.Generic;

namespace lab2
{
    public class ListOfOuts
    {
        public void Print(List<OutInfo> outs)
        {
            foreach (var info in outs)
            {
                Console.Write(info.Count + " " + info.Name + " / ");
            }
            Console.Write('\n');
        }
    }
}
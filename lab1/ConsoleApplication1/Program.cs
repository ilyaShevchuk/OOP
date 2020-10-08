using System;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 3)
                Console.WriteLine("TRY to PARSE");
            
            else
                Console.Error.WriteLine("Bad args");

            try
            {
                ParsedIniFile myIniFile = IniParse.Parse(@args[0]);
                var answer= myIniFile.GetStringData(args[1], args[2]);
                Console.WriteLine(answer);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }
        }
    }
}
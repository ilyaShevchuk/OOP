using System;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 4)
                Console.WriteLine("TRY to PARSE");
            
            else
                Console.Error.WriteLine("Bad args");

            try
            { ParsedIniFile myIniFile = IniParse.Parse(@args[0]);
                switch (args[3].ToLower())
                {
                    case "int":
                        var answer1= myIniFile.GetIntData(args[1], args[2]);
                        Console.WriteLine(answer1);
                        break;
                    case "float":
                        var answer2 = myIniFile.GetFloatData(args[1], args[2]);
                        Console.WriteLine(answer2);
                        break;
                    case "string":
                        var answer3 = myIniFile.GetStringData(args[1], args[2]);
                        Console.WriteLine(answer3);
                        break;
                    default:
                        throw new InvalidArgs("Expected value type must be : float, int, string");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
                Console.WriteLine(e.Message);
            }
        }
    }
}
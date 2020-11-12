using System;
using System.Threading;
using laba3.FlyTransports;
using laba3.Properties.LandTransports;

namespace laba3
    {
    internal class Program
    {
        public static void Main(string[] args)
        {
            Engine newEng = new Engine();
            bool flag = true;
            while (true)
            {
                Console.WriteLine("Chose Race Type \n" +
                                  "0 - LandRace \n" +
                                  "1 - FlyRace \n" +
                                  "2 - AnyRace ");
                int x = Convert.ToInt32(Console.ReadLine());
                try
                {
                    newEng.CreateRace((RaceType) x);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    break;
                }

                Console.WriteLine("How many transports you want?");
                int cnt = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < cnt; i++)
                {
                    Console.WriteLine($"Chose {i+1} transport \n" +
                                      $"LandTs : 0 - Centaur, 1 - TwoCamel, 2 - FastCamel, 3 - Boots\n" +
                                      $"FlyTs : 4 - Broom, 5 - MagicCarpet, 6 - Mortar");
                    int y = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        newEng.AddTransport((TransportType) y);
                    }
                    catch (CanNotBeAdd e)
                    {
                        Console.WriteLine(e.Message);
                        flag = false;
                        break;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine(e.Message);
                        flag = false;
                        break;
                    }
                    
                }

                if (flag)
                {
                    Console.WriteLine("Write the distance");
                    int dis = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("THE WINNER IS \n" + newEng.RunRace(dis));
                }

                break; 
            }
        }
    }
}
using System;
using laba3.FlyTransports;
using laba3.Properties.LandTransports;

namespace laba3
{
    public class Engine
    {
        public RaceType TypeOfRace { get; set; } = RaceType.AnyRace;
        private string Winner { get; set; } = "No winner";
        private IRace _newRace;
        public void CreateRace(RaceType x)
        {
            switch (x)
            {
                case RaceType.LandRace:
                    _newRace = new LandRace();
                    break;
                case RaceType.FlyRace:
                    _newRace = new FlyRace();
                    break;
                case RaceType.AnyRace:
                    _newRace = new AnyRace();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(x), x, null);
            }
        }

    
        public void AddTransport(TransportType x)
        {
            ITransport newTransport;
            switch (x)
            { 
                case TransportType.Centaur:
                    newTransport = new Centaur();
                    break;
                case TransportType.TwoCamel:
                    newTransport = new TwoCamel();
                    break;
                case TransportType.FastCamel:
                    newTransport = new FastCamel();
                    break;
                case TransportType.Boots:
                    newTransport = new Boots();
                    break;
                case TransportType.Broom:
                    newTransport = new Broom();
                    break;
                case TransportType.MagicCarpet:
                    newTransport = new MagicCarpet();
                    break;
                case TransportType.Mortar:
                    newTransport = new Mortar();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(x), x, null);
            }

            try
            {
                _newRace.Add(newTransport);
            }
            catch (WrongParty e)
            {
                Console.WriteLine(e.Message);
                throw new CanNotBeAdd("Add problem");
            }
        }

        public string RunRace(double distance)
        {
            Winner = _newRace.RunRace(distance);
            return Winner;
        }
        
    }
}
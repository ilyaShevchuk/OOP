using System.Collections.Generic;

namespace laba3
{
    public abstract class IRace
    {
        protected List<ITransport> Party { get; } = new List<ITransport>();
        public abstract void Add(ITransport x);

        public string RunRace(double distance)
        {
            double minTime = 0;
            string winner = "";
            foreach (var transport in Party)
            {
                if (transport.CalcTime(distance) < minTime || minTime == 0)
                {
                    minTime = transport.CalcTime(distance);
                    winner = transport.ToString();
                }
                
            }
            return winner;
        }
    }
}
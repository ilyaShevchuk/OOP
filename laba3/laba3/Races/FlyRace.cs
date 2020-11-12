using System;

namespace laba3
{
    public class FlyRace: IRace
    {
        public override void Add(ITransport x)
        {
            if (x is FlyTransport)
            {
                this.Party.Add(x);
            }
            else
            {
                throw new WrongParty("Wait for FlyT, " +
                                     "but get smth else");
            }
        }
    }
}
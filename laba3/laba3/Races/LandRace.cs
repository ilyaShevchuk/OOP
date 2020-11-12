namespace laba3
{
    public class LandRace : IRace
    {
        public override void Add(ITransport x)
        {
            if (x is LandTransport)
            {
                this.Party.Add(x);
            }
            else
            {
                throw new WrongParty("Wait for LandT, " +
                                     "but get smth else");
            }
        }
    }
}
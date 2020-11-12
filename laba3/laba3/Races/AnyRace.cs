namespace laba3
{
    public class AnyRace : IRace
    {
        public override void Add(ITransport x)
        {
            this.Party.Add(x);
        }
    }
}
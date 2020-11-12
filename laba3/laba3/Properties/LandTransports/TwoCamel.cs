namespace laba3.Properties.LandTransports
{
    public class TwoCamel:LandTransport
    {
        protected override int Speed { get; } = 10;
        protected override int RestInterval { get; } = 30;
        protected override double RestDuration(int count)
        {
            return count == 1 ? 5 : 8;
        }
    }
}
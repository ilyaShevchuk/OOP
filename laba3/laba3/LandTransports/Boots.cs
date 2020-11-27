namespace laba3.Properties.LandTransports
{
    public class Boots:LandTransport
    {
        protected override int Speed { get; } = 6;
        protected override int RestInterval { get; } = 60;
        protected override double RestDuration(int count)
        {
            return count == 1 ? 10 : 5;
        }
    }
}
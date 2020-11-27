namespace laba3.Properties.LandTransports
{
    public class Centaur: LandTransport
    {
        protected override int Speed { get; } = 15;

        protected override int RestInterval { get; } = 8;
        
        protected override double RestDuration(int count)
        {
            return 2;
        }
    }
}
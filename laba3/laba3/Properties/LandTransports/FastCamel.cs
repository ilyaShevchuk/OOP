namespace laba3.Properties.LandTransports
{
    public class FastCamel:LandTransport
    {
        protected override int Speed { get; } = 40;
        protected override int RestInterval { get; } = 10;
        protected override double RestDuration(int count)
        {
            switch (count)
            {
                case 1:
                    return 5;
                case 2:
                    return 6.5;
                default:
                    return 8;
            }
        }
    }
}
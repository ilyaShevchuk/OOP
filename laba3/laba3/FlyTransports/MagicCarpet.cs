namespace laba3.FlyTransports
{
    public class MagicCarpet:FlyTransport
    {
        protected override int Speed { get; } = 10;

        protected override double DistanceReduction(double distance)
        {
            if (distance < 1000)
                return distance;

            if (distance < 5000)
                return distance * 0.97;

            if (distance < 10000)
                return distance * 0.9;

            return distance * 0.95;

        }
    }
}
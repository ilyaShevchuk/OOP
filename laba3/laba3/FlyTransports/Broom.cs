namespace laba3
{
    public class Broom:FlyTransport
    {
        protected override int Speed { get; } = 20;
        protected override double DistanceReduction(double distance)
        {
            double newDistance = distance;
            const int percent = 1;
            for (int i = 0; i < distance / 1000; i++)
            {
                newDistance -= distance*(1 - percent);
            }

            return newDistance;
        }
    }
}
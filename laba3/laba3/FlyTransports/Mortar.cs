namespace laba3.FlyTransports
{
    public class Mortar:FlyTransport
    {
        protected override int Speed { get; } = 8; 
        protected override double DistanceReduction(double distance)
        {
            return distance * 0.94;
        }
    }
}
using System.Threading;

namespace laba3
{
    public abstract class FlyTransport: ITransport
    {
        protected abstract override int Speed { get;  }

        public override double CalcTime(double distance)
        {
            double newDistance = this.DistanceReduction(distance);

            double time = newDistance / this.Speed;

            return time;
        }

        protected abstract double DistanceReduction(double distance);
    }
}
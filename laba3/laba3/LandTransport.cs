using System;

namespace laba3
{
    public abstract class LandTransport : ITransport
    {
        protected abstract override int Speed { get;}
        protected abstract int RestInterval { get; }
        protected abstract double RestDuration(int count);
        public override double CalcTime(double distance)
        {
            double time = distance / Speed;
            int restCount = Convert.ToInt32(time / RestInterval);
            double restTime = 0;
            for (int i = 0; i < restCount; i++)
            {
                restTime += RestDuration(i);
            }

            return time + restTime;
        }
        
    }
}
namespace laba3
{
    public abstract class ITransport
    {
        protected abstract int Speed { get; }

        public abstract double CalcTime(double distance);
    }
}
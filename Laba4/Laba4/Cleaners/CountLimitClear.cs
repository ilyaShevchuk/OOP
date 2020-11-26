namespace Laba4.Cleaners
{
    public class CountLimitClear:ICleaner
    {
        private int _limitCount;
        public CountLimitClear(int count)
        {
            _limitCount = count;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitCount < backup.RestorePoints.Count;
        }
    }
}

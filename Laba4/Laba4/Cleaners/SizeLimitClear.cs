namespace Laba4.Cleaners
{
    public class SizeLimitClear:ICleaner
    {
        private long _limitSize;

        public SizeLimitClear(long size)
        {
            _limitSize = size;
        }
        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitSize < backup.Size;
        }
    }
}
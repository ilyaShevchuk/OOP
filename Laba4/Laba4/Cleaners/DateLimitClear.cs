using System;

namespace Laba4.Cleaners
{
    public class DateLimitClear:ICleaner
    {
        private DateTime _limitDateTime;
        public DateLimitClear(DateTime dateTime)
        {
            _limitDateTime = dateTime;
        }

        public override bool IsLimitExceeded(Backup backup)
        {
            return _limitDateTime < backup.RestorePoints[0].CreationTime;
        }
    }
        
}

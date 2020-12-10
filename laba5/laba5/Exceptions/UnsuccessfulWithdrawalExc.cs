using System;

namespace laba5.Exceptions
{
    public class UnsuccessfulWithdrawalExc : Exception
    {
        public UnsuccessfulWithdrawalExc(string msg) : base(msg)
        {
        }
    }
}
using System;

namespace laba5.Exceptions
{
    public class NotEnoughMoneyEx : Exception
    {
        public NotEnoughMoneyEx(string msg) : base(msg)
        {
        }
    }
}
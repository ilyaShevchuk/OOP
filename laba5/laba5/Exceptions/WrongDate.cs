using System;

namespace laba5.Exceptions
{
    public class WrongDate : Exception
    {
        public WrongDate(string msg) : base(msg)
        {
        }
    }
}
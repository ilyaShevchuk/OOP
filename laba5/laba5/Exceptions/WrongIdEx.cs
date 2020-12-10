using System;

namespace laba5.Exceptions
{
    public class WrongIdEx:Exception
    {
        public WrongIdEx(string msg) : base(msg)
        {
        }
    }
}
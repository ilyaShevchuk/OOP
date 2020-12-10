using System;
using System.Collections.Generic;

namespace laba5.Exceptions
{
    public class LimitEx:Exception
    {
        public LimitEx(string msg) : base(msg)
        {
        }
    }
}
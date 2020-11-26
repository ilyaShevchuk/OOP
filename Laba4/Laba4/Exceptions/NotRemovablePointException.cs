using System;

namespace Laba4.Exceptions
{
    public class NotRemovablePointException:Exception
    {
        public NotRemovablePointException(string str):base(str)
        {
        }
    }
}
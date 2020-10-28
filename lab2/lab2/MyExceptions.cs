using System;
namespace lab2
{
    public class InvalidId : Exception
    {
        public InvalidId(string message)
            : base(message)
        {}
    }
    public class NotEnough : Exception
    {
        public NotEnough(string message)
            : base(message)
        {}
    }   
}
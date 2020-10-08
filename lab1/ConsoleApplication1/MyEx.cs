using System;

namespace ConsoleApplication1
{
    public class WrongFormat : Exception
    {
        public WrongFormat(string message)
            : base(message)
        {}
        
    }

    public class InvalidInput : Exception
    {
        public InvalidInput(string message)
            :base(message)
        {}
    }
    
    public class InvalidSection : Exception
    {
        public InvalidSection(string message)
            :base(message)
        {}
    }
}
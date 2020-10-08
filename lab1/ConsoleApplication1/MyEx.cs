using System;

namespace ConsoleApplication1
{
    public class WrongFormat : Exception
    {
        public WrongFormat(string message)
            : base(message)
        {}
        
    }

    public class InvalidFileInput : Exception
    {
        public InvalidFileInput(string message)
            :base(message)
        {}
    }
    
    public class InvalidArgs : Exception
    {
        public InvalidArgs(string message)
            :base(message)
        {}
    }
    
    public class InvalidSection : Exception
    {
        public InvalidSection(string message)
            :base(message)
        {}
    }

    public class InvalidFileType : Exception
    {
        public InvalidFileType(string message)
            :base(message)
        {}
    }
}
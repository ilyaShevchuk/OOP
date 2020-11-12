using System;

namespace laba3
{
    public class WrongParty: Exception
    {
        public WrongParty(string message)
            : base(message)
        {}
    }
    public class CanNotBeAdd: Exception
    {
        public CanNotBeAdd(string message)
            : base(message)
        {}
    }
}
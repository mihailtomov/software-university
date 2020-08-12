using System;

namespace _7._Custom_Exception
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string msg) : base(msg)
        {

        }
    }
}

using System;

namespace PocketNet.PocketNet.Exceptions
{
    public class PocketException : Exception
    {
        public PocketException(string message) : base(message)
        {
        }
    }
}
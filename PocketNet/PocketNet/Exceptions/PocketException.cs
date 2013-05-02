using System;
using System.Net.Http;

namespace PocketNet.PocketNet.Exceptions
{
    public class PocketException : Exception
    {
        public int StatusCode { get; private set; }
        public string Error { get; private set; }

        public PocketException(string message) : base(message)
        {
        }

        public PocketException(int statusCode, string error)
        {
            StatusCode = statusCode;
            Error = error;
        }
    }
}
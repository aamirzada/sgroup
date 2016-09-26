using System;

namespace WebApplication1.Exceptions
{
    public class MapServerException : Exception
    {
        public MapServerException(string msg) : base(msg) { }
    }
}
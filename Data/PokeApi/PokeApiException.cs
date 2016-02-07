using System;

namespace PokeD.Core.Data.PokeApi
{
    public class PokeApiException : Exception
    {
        public PokeApiException() : base() { }

        public PokeApiException(string message) : base(message) { }

        public PokeApiException(string format, params object[] args) : base(string.Format(format, args)) { }

        public PokeApiException(string message, Exception innerException) : base(message, innerException) { }

        public PokeApiException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
    }
}
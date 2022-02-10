using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    internal class CoinNotFoundException : Exception
    {
        public CoinNotFoundException()
        {
        }

        public CoinNotFoundException(string? message) : base(message)
        {
        }

        public CoinNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CoinNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
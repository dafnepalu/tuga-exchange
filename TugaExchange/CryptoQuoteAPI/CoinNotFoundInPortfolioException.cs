using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    internal class CoinNotFoundInPortfolioException : Exception
    {
        public CoinNotFoundInPortfolioException()
        {
        }

        public CoinNotFoundInPortfolioException(string? message) : base(message)
        {
        }

        public CoinNotFoundInPortfolioException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CoinNotFoundInPortfolioException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
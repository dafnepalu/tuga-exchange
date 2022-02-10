using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    internal class InvestorNotFoundException : Exception
    {
        public InvestorNotFoundException()
        {
        }

        public InvestorNotFoundException(string? message) : base(message)
        {
        }

        public InvestorNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvestorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
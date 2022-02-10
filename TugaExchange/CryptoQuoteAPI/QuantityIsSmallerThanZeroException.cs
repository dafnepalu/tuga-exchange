using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    internal class QuantityIsSmallerThanZeroException : Exception
    {
        public QuantityIsSmallerThanZeroException()
        {
        }

        public QuantityIsSmallerThanZeroException(string? message) : base(message)
        {
        }

        public QuantityIsSmallerThanZeroException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected QuantityIsSmallerThanZeroException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
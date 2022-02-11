using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string? message) : base(message)
        {
        }
    }
}
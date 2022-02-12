using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    public class InsufficientCoinsException : Exception
    {
        public InsufficientCoinsException(string? message) : base(message)
        {
        }
    }
}
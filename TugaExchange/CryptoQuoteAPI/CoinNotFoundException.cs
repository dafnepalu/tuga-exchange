using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    internal class CoinNotFoundException : Exception
    {
        public CoinNotFoundException(string? message) : base(message)
        {
        }
    }
}
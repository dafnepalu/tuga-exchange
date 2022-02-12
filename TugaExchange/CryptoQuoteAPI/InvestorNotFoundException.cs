using System.Runtime.Serialization;

namespace ClassLibrary
{
    [Serializable]
    public class InvestorNotFoundException : Exception
    {
        public InvestorNotFoundException(string? message) : base(message)
        {
        }
    }
}
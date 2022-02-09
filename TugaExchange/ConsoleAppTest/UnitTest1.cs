using Xunit;
using ClassLibrary;

namespace ConsoleAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void Deposit()
        {
            var api = new API();
            api.AddCoin("moeda1");
            api.AddCoin("moeda2");
            
        }
    }
}
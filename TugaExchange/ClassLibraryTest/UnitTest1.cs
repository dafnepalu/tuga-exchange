using ClassLibrary;
using Xunit;

namespace ClassLibraryTest
{
    public class Buy
    {
        [Fact]
        public void BuyCurrency()
        {
            Investor investor = new Investor();
            investor.MakeDeposit(100);

            Coin coin = new Coin("Money");
            int quantity = 2;

            investor.BuyCurrency(coin, quantity);
            Assert.NotEqual(100, investor.BalanceInEuros);
        }
    }

}
using ClassLibrary;
using Xunit;

namespace ClassLibraryTest
{
    public class Buy
    {
        [Fact]
        //public void BuyCurrency()
        //{
        //    Investor investor = new Investor();

        //    Coin coin = new Coin("Money");
        //    int quantity = 2;

        //    investor.BuyCurrency(coin, quantity);
        //    Assert.Equal(0, investor.BalanceInEuros);
        //}

        public void Hello()
        {
            API api = new API();
            api.AddCoin("whatever");
            Investor investor = new Investor();
            investor.MakeDeposit(100);
            investor.BuyCurrency(api.FindACoin("whatever"), 5);


            Assert.NotEqual(100, investor.BalanceInEuros);
        }
        
        


    }


}
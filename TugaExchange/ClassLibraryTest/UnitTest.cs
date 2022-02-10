using ClassLibrary;
using Xunit;

namespace ClassLibraryTest
{
    public class API_Tests
    {      
        [Fact]
        public void GetCoins()
        {
            var api = new API();
            api.AddCoin("Moeda1");
            Assert.NotEmpty(api.GetCoinNames());
        }

        [Fact]
        public void AddInvestor()
        {
            var api = new API();
            api.AddInvestor();
            Assert.NotEmpty(api.Investors);
        }

        [Fact]
        public void FindCoin()
        {
            var api = new API();
            api.AddCoin("Moeda1");
            api.FindCoin("Moeda1");
            // How can I test if FindCoin found my coin?
        }

        [Fact]
        public void RemoveCoin()
        {
            var api = new API();
            api.AddCoin("Moeda1");
            // Assert.Contains("Coin1", api.Coins);
            Assert.NotEmpty(api.GetCoinNames());
            api.RemoveCoin("Moeda1");
            Assert.Empty(api.GetCoinNames());
        }

        [Fact]
        public void GetPrices()
        {
            var api = new API();
            api.AddCoin("Moeda1");
            api.AddCoin("Moeda2");
            // How can I test if GetPrices() works?
        }

        [Fact]
        public void DefinePriceUpdateInSeconds()
        {
            var api = new API();
            api.DefinePriceUpdateInSeconds(30);
            Assert.Equal(30, api.PriceUpdateInSeconds);
            api.DefinePriceUpdateInSeconds(60);
            Assert.NotEqual(30, api.PriceUpdateInSeconds);
        }

        [Fact]
        public void GetPriceUpdateInSeconds()
        {
            var api = new API();
            api.DefinePriceUpdateInSeconds(30);
            Assert.Equal(30, api.GetPriceUpdateInSeconds());
            api.DefinePriceUpdateInSeconds(60);
            Assert.NotEqual(30, api.GetPriceUpdateInSeconds());
        }

        [Fact]
        public void UpdatePrices()
        {
            var api = new API();
            api.DefinePriceUpdateInSeconds(30);
            api.AddCoin("Moeda1");
            var coins = api.GetCoins();
            var coin = coins[0];
            Assert.True(coin.MarketValue == 1);
            api.UpdatePrices(200);
            Assert.True(coin.MarketValue != 1);
        }
    }
    public class Investor_Tests
    {
        [Fact]
        public void MakeDeposit()
        {
            var investor = new Investor();
            Assert.Equal(0, investor.BalanceInEuros);
            investor.MakeDeposit(100);
            Assert.NotEqual(0, investor.BalanceInEuros);
            Assert.Equal(100, investor.BalanceInEuros);
        }

        [Fact]
        public void BuyCurrency()
        {

        }
    }
}
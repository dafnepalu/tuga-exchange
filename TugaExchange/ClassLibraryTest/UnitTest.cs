using ClassLibrary;
using System;
using System.Threading;
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
            api.GetCoin("Moeda1");
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
            //api.UpdatePrices(200);
            Assert.True(coin.MarketValue != 1);
        }

        [Fact]
        public void Transactions()
        {
            var api = new API();
            var investor = api.AddInvestor();
            api.MakeDeposit(investor.Id, 100);
            api.AddCoin("Coin1");
            api.BuyCurrency(investor.Id, "Coin1", 50);
            Assert.Equal((decimal)0.5, api.Profit);
            Assert.Equal((decimal)50, investor.Portfolio.Coins["Coin1"]);
            Assert.Equal((decimal)49.5, investor.BalanceInEuros);
            api.SellCurrency(investor.Id, "Coin1", 50);
            Assert.Equal((decimal)1, api.Profit);
            Assert.Equal((decimal)0, investor.Portfolio.Coins["Coin1"]);
            Assert.Equal((decimal)99, investor.BalanceInEuros);
        }

        [Fact]
        public void Json()
        {
            var api = new API();
            Assert.Empty(api.Investors);
            var investor = api.AddInvestor();
            Assert.NotEmpty(api.Investors);
            Assert.Equal(0, investor.BalanceInEuros);
            api.MakeDeposit(investor.Id, 100);
            Assert.Equal(100, investor.BalanceInEuros);
            api.AddCoin("Coin1");
            Assert.Empty(investor.Portfolio.Coins);
            api.BuyCurrency(investor.Id, "Coin1", 50);
            Assert.NotEmpty(investor.Portfolio.Coins);
            Assert.NotEqual(0, api.Profit);         
            api.Save();

            api.Read();
            Assert.NotEmpty(api.Investors);
            Assert.NotEmpty(investor.Portfolio.Coins);
            Assert.NotEqual(0, api.Profit);
        }
        [Fact]
        public void Json2()
        {
            var api = new API();
            api.AddCoin("coinhehe");
            api.UpdatePrices();
            DateTime firstTime = api.LastTimeUpdatePricesWasCalled;
            api.Save();
            TimeSpan ts = new TimeSpan(0, 2, 0);
            Thread.Sleep(ts);
            api.UpdatePrices();
            Assert.NotEqual(firstTime, api.LastTimeUpdatePricesWasCalled);
        }
    }
}
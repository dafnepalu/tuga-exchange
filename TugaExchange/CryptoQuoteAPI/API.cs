using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ClassLibrary;
using System.Runtime.Serialization;

namespace ClassLibrary;

////////////////////////////////////////////////////////////////////////////////
/// SUMMARY OF METHODS IN THIS CLASS
/// 
/// /!\ Singular usually denotes that the action pertains to a specific object,
/// while plural usually denotes that the action pertains to a list of objects.
/// 
/// I. COIN METHODS
///     1. AddCoin
///     2. RemoveCoin
///     3. GetCoins
///     4. GetCoin
///     5. GetCoinNames
///     6. GetCoinPrice
/// II. INVESTOR METHODS
///     1. AddInvestor
///     2. GetInvestor
/// III. PRICE METHODS
///     1. GetPrices
///     2. DefinePriceUpdateInSeconds
///     3. GetPriceUpdateInSeconds
///     4. UpdatePrices
/// IV. TRANSACTION METHODS
///     1. MakeDeposit
///     2. BuyCurrency
///     3. SellCurrency
/// V. MISC
///     1. GetRandomNumber
/// VI. JSON METHODS
///     1. Save
///     2. Read
////////////////////////////////////////////////////////////////////////////////


public class API
{
    public List<Coin> Coins { get; set; } = new List<Coin>();
    public List<Investor> Investors { get; set; } = new List<Investor>();
    public decimal Profit { get; set; }
    public int PriceUpdateInSeconds { get; set; } = 30; // Personal choice to get things started.
    private static readonly Random Random = new Random();
    public int LastInvestorID { get; set; }
    public decimal TransactionFee { get; set; } = new decimal(0.01);
    public DateTime? LastTimeUpdatePricesWasCalled { get; set; }


    ////////////////////////////////////////////////////////////////////////////////
    /// COIN METHODS
    ////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Adds a new coin to the system and to the Coin list simultaneously.
    /// </summary>
    /// <param name="name">The name of the cryptocurrency you wish to add.</param>
    public void AddCoin(string name)
    {
        Coins.Add(new Coin(name));
    }

    /// <summary>
    /// Removes a coin from the system.
    /// </summary>
    /// <param name="name">The name of the cryptocurrency we wish to remove.</param>
    public void RemoveCoin(string name)
    {
        // Each coin in my list of coins can be accessed or modified
        // via its index. If the name of a coin matches the
        // name entered by the user, its index is retrieved and
        // removed from the list. We do this for every coin in the list.
        for (int i = 0; i < Coins.Count; i++)
        {
            Coin coin = Coins[i];
            if (coin.Name == name)
            {
                int index = i;
                Coins.RemoveAt(index);
            }
        }
    }

    /// <summary>
    /// Retrieves the Coin list.
    /// </summary>
    /// <returns></returns>
    public List<Coin> GetCoins()
    {
        return Coins;
    }

    /// <summary>
    /// Retrieves a specific coin in our Coin list based on its name.
    /// </summary>
    /// <param name="name">The name of the coin we want to retrieve.</param>
    /// <returns>A Coin object.</returns>
    public Coin GetCoin(string name)
    {
        var coin = Coins.Find(coin => coin.Name == name);
        if (coin == null)
        {
            throw new CoinNotFoundException("Esta criptomoeda não se encontra no seu portfolio.");
        }
        return coin;
    }

    /// <summary>
    /// Retrieves a list with the names of the coins.
    /// </summary>
    public List<string> GetCoinNames()
    {
        List<string> coinsStr = new List<string>();
        foreach (Coin coin in Coins)
        {
            coinsStr.Add(coin.Name);
        }
        return coinsStr;
    }

    /// <summary>
    /// Retrieves the price of a specific Coin in the system based on its name.
    /// </summary>
    /// <param name="name">The name of the coin whose price we want to retrieve.</param>
    /// <returns>The Coin's market value in decimal format.</returns>
    public decimal GetCoinPrice(string name)
    {
        var coin = Coins.Find(coin => coin.Name == name);
        if (coin == null)
        {
            throw new CoinNotFoundException("Esta criptomoeda não se encontra no seu portfolio.");
        }
        return coin.MarketValue;
    }

    ////////////////////////////////////////////////////////////////////////////////
    /// INVESTOR METHODS
    ////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Adds a new investor to the system and to the Investor list simultaneously.
    /// </summary>
    /// <returns>An Investor object.</returns>
    public Investor AddInvestor()
    {
        Investor investor = new Investor();
        investor.Id = LastInvestorID;
        LastInvestorID += 1;
        Investors.Add(investor);
        return investor;
    }

    /// <summary>
    /// Retrieves an investor based on its ID.
    /// </summary>
    /// <param name="investorID"></param>
    /// <returns>An Investor object.</returns>
    /// <exception cref="InvestorNotFoundException"></exception>
    public Investor GetInvestor(int investorID)
    {
        var investor = Investors.Find(investor => investor.Id == investorID);
        if (investor == null)
        {
            throw new InvestorNotFoundException("O ID de investidor não foi encontrado.");
        }
        return investor;
    }

    ////////////////////////////////////////////////////////////////////////////////
    /// PRICE METHODS
    ////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Retrieves the updated prices of all the registered coins.
    /// </summary>
    public (List<string> Names, List<decimal> Values) GetPrices()
    {
        UpdatePrices();
        List<string> names = new List<string>();
        List<decimal> values = new List<decimal>();
        foreach (Coin coin in Coins)
        {
            names.Add(coin.Name);
            values.Add(coin.MarketValue);
        }
        return (names, values);
    }

    /// <summary>
    /// Sets the time interval in seconds that the module updates the currency exchange rate.
    /// </summary>
    /// <param name="seconds">The number of seconds at which you wish to update the currency exchange rate.</param>
    public void DefinePriceUpdateInSeconds(int seconds)
    {
        PriceUpdateInSeconds = seconds;
    }

    /// <summary>
    /// Retrieves the time interval (in seconds) in which the module calculates new quotation prices.
    /// </summary>
    /// <returns>The time interval in seconds.</returns>
    public int GetPriceUpdateInSeconds()
    {
        return PriceUpdateInSeconds;
    }

    /// <summary>
    /// Updates currency prices and makes it seem like it has been done automatically every N seconds.
    /// </summary>
    /// <param name="interval">The time interval elapsed since the last time the method was called.</param>
    public void UpdatePrices()
    {
        const double minimum = -0.5 / 100;
        const double maximum = 0.5 / 100;

        if (!LastTimeUpdatePricesWasCalled.HasValue)
        {
            LastTimeUpdatePricesWasCalled = DateTime.Now;
        }

        double timeSpanInSeconds = (DateTime.Now - LastTimeUpdatePricesWasCalled).Value.TotalSeconds;

        var times = Math.Floor(timeSpanInSeconds / PriceUpdateInSeconds); // Rounds down everytime because...

        for (var i = 0; i < times; i++) // ... if 15 seconds elapsed and defined interval was 30 => times = 0.5. i = 0 is smaller than 0.5, it will execute it once although I don't want that because not enough time has elapsed.
        {
            foreach (var coin in Coins)
            {
                var variation = GetRandomNumber(minimum, maximum);
                coin.UpdateValue(new decimal(variation));
            }
        }
        LastTimeUpdatePricesWasCalled = DateTime.Now;
        Save();
    }

    ////////////////////////////////////////////////////////////////////////////////
    /// TRANSACTION METHODS
    ////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Allows an investor to add EUR to their own account.
    /// </summary>
    public void MakeDeposit(int investorID, decimal euro)
    {
        var investor = GetInvestor(investorID);
        investor.BalanceInEuros += euro;
    }

    /// <summary>
    /// Allows an investor to buy cryptocurrency using their balance in EUR.
    /// </summary>
    /// <param name="name">The name of the coin to be purchased.</param>
    /// <param name="quantity">The number of coins to be purchased.</param>
    public void BuyCurrency(int investorID, string name, decimal quantity)
    {
        var coin = GetCoin(name);
        var subtotal = coin.MarketValue * quantity;
        var fee = subtotal * TransactionFee;
        var total = subtotal + fee;

        var investor = GetInvestor(investorID);

        // Check if the investor can afford the operation
        if (investor.BalanceInEuros < total)
        {
            throw new InsufficientFundsException("Você não tem saldo suficiente para realizar esta operação.");
        }
        investor.Portfolio.AddCoinToPortfolio(name, quantity);
        investor.BalanceInEuros -= total;
        Profit += fee;
    }

    /// <summary>
    /// Allows an investor to sell cryptocurrency they own.
    /// </summary>
    /// <param name="coin">The coin they want to sell.</param>
    /// <param name="quantity">The number of coins they want to sell.</param>
    public void SellCurrency(int investorID, string name, decimal quantity)
    {
        var coin = GetCoin(name);
        var subtotal = coin.MarketValue * quantity;
        var fee = subtotal * TransactionFee;
        var total = subtotal - fee;

        var investor = GetInvestor(investorID);
        investor.Portfolio.RemoveCoinFromPortfolio(name, quantity);
        investor.BalanceInEuros += total;
        Profit += fee;
    }

    ////////////////////////////////////////////////////////////////////////////////
    /// MISC METHODS
    ////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Generates a random number between two numbers.
    /// </summary>
    /// <param name="minimum"></param>
    /// <param name="maximum"></param>
    /// <returns>Returns a random number.</returns>
    private static double GetRandomNumber(double minimum, double maximum)
    {
        // This method is static because if we initialized a different random number generator (RNG) with every call
        // and the system time didn't change between calls, every RNG would get seeded with the same timestamp
        // and generate the same stream of random numbers. https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
        // Therefore, by making the method static, we can call it very frequently (as we need to do in this project).

        return Random.NextDouble() * (maximum - minimum) + minimum;
    }

    ////////////////////////////////////////////////////////////////////////////////
    /// JSON METHODS
    ////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Saves the managed quotes and currencies, as well as the date of the last exchange.
    /// </summary>
    public void Save()
    {
        var json = JsonSerializer.Serialize(this);
        File.WriteAllText("save.json", json);
    }

    /// <summary>
    /// Reads the currencies, exchange rate, and date to which they refer.
    /// </summary>
    public void Read()
    {
        var path = "save.json";
        // Don't do anything if the file doesn't exist.
        if (!File.Exists(path))
            return;

        var json = File.ReadAllText(path);
        var api = JsonSerializer.Deserialize<API>(json);

        // Don't do anything if the file is empty.
        if (api is null)
            return;

        Investors = api.Investors;
        Coins = api.Coins;
        Profit = api.Profit;
        PriceUpdateInSeconds = api.PriceUpdateInSeconds;
        LastTimeUpdatePricesWasCalled = api.LastTimeUpdatePricesWasCalled;
    }
}


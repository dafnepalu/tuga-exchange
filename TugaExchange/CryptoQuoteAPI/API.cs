using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using ClassLibrary;

namespace ClassLibrary;

public class API
{
    public List<Coin> Coins { get; set; } = new List<Coin>();
    public List<Investor> Investors { get; set; } = new List<Investor>();
    public int PriceUpdateInSeconds { get; set; }
    private static readonly Random Random = new Random();

    /// <summary>
    /// Adds a new coin to the system and to the Coin list simultaneously.
    /// </summary>
    /// <param name="name">The name of the cryptocurrency you wish to add.</param>
    public void AddCoin(string name)
    {
        Coins.Add(new Coin(name));
    }

    /// <summary>
    /// Adds a new investor to the system and to the Investor list simultaneously.
    /// </summary>
    public void AddInvestor()
    {
        Investors.Add(new Investor());
    }


    /// <summary>
    /// Returns the Coin list in string format.
    /// </summary>
    public List<string> GetCoins()
    {
        // Creates a new, updated List<string> every time the method is called:
        List<string> coinsStr = new List<string>();
        // Adds every coin name of every coin in our Coin list
        // to the list of strings I've just created:
        foreach (Coin coin in Coins)
        {
            coinsStr.Add(coin.Name);
        }
        return coinsStr;
    }

    /// <summary>
    /// Removes a coin from the system.
    /// </summary>
    /// <param name="name">The name of the cryptocurrency you wish to remove.</param>
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
    /// Returns the updated prices of all the registered coins.
    /// </summary>
    public (List<string>, List<decimal>) GetPrices()
    {
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
    /// Gets the time interval (in seconds) in which the module calculates new quotation prices.
    /// </summary>
    /// <returns>The time interval in seconds.</returns>
    public int GetPriceUpdateInSeconds()
    {
        return PriceUpdateInSeconds;
    }

    /// <summary>
    /// Generates a random number between two numbers.
    /// </summary>
    /// <param name="minimum"></param>
    /// <param name="maximum"></param>
    /// <returns>A random number.</returns>

    // This method is static because if we initialized a different random number generator (RNG) with every call
    // and the system time didn't change between calls, every RNG would get seeded with the same timestamp
    // and generate the same stream of random numbers. https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
    // Therefore, by making the method static, we can call it very frequently (as we need to do in this project).

    private static double GetRandomNumber(double minimum, double maximum)
    {
        return Random.NextDouble() * (maximum - minimum) + minimum;
    }

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
        PriceUpdateInSeconds = api.PriceUpdateInSeconds;
    }
}

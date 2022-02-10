﻿using System;
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
    public List<decimal> Fees { get; set; } = new List<decimal>();
    public int PriceUpdateInSeconds { get; set; } = 30;
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
    /// Simply returns the Coin list.
    /// </summary>
    /// <returns></returns>
    public List<Coin> GetCoins()
    {
        return Coins;
    }

    /// <summary>
    /// Returns the Coin list in string format.
    /// </summary>
    public List<string> GetCoinNames()
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
    /// Adds a new investor to the system and to the Investor list simultaneously.
    /// </summary>
    public void AddInvestor()
    {
        Investors.Add(new Investor());
    }

    /// <summary>
    /// Finds a specific coin in our Coin list.
    /// </summary>
    /// <param name="name">The coin we want to retrieve.</param>
    /// <returns>A Coin object.</returns>
    public Coin FindCoin(string name)
    {
        return Coins.Find(coin => coin.Name == name);
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
    /// Shows the latest exchange rates.
    /// </summary>
    //public void ShowPrices()
    //// This features a ZIP operation
    //{
    //    API api = new API();
    //    (var names, var values) = api.GetPrices();
    //    var namesAndValues = names.Zip(values, (n, v) => new { Name = n, Value = v });
    //    foreach (var nv in namesAndValues)
    //    {
    //        Console.WriteLine(nv.Name + nv.Value);
    //    }
    //}

    /// <summary>
    /// Generates a random number between two numbers.
    /// </summary>
    /// <param name="minimum"></param>
    /// <param name="maximum"></param>
    /// <returns>Returns a random number.</returns>

    // This method is static because if we initialized a different random number generator (RNG) with every call
    // and the system time didn't change between calls, every RNG would get seeded with the same timestamp
    // and generate the same stream of random numbers. https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers
    // Therefore, by making the method static, we can call it very frequently (as we need to do in this project).

    private static double GetRandomNumber(double minimum, double maximum)
    {
        return Random.NextDouble() * (maximum - minimum) + minimum;
    }

    /// <summary>
    /// Updates currency prices and makes it seem like it has been done automatically every N seconds.
    /// </summary>
    /// <param name="interval">The time interval elapsed since the last time the method was called.</param>
    public void UpdatePrices(int interval)
    {
        const double minimum = -0.5 / 100;
        const double maximum = 0.5 / 100;

        var times = interval / PriceUpdateInSeconds; // E.g.: 60/30 => (need to update twice)

        for (var i = 0; i < times; i++)
        {
            foreach (var coin in Coins)
            {
                var variation = GetRandomNumber(minimum, maximum);
                coin.UpdateValue(new decimal(variation));
            }
        }
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
        Fees = api.Fees;
        PriceUpdateInSeconds = api.PriceUpdateInSeconds;
    }
}

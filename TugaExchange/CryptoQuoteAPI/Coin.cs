namespace CryptoQuoteAPI;

public class Coin
{
    public string Name { get; }
    public double MarketValue { get; set; } = 1;

    public Coin(string name)
    {
        Name = name;
    }
}

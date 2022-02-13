namespace ClassLibrary;

public class Coin
{
    public string Name { get; }
    public decimal MarketValue { get; set; } = 1;

    public Coin(string name)
    {
        Name = name;
    }

    public void UpdateValue(decimal variation)
    {
        MarketValue = variation/new decimal(100.0) * MarketValue + MarketValue;
    }
}

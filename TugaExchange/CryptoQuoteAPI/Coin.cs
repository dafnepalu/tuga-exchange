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
        MarketValue = variation * MarketValue + MarketValue;
    }
}

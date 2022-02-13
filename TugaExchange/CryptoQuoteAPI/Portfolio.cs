namespace ClassLibrary;

public class Portfolio
{
    public Dictionary<string, decimal> Coins { get; set; } = new Dictionary<string, decimal>();

    public void AddCoinToPortfolio(string name, decimal quantity)
    {
        if (quantity <= 0)
        {
            throw new QuantityIsSmallerThanZeroException();
        }
        if (Coins.ContainsKey(name)) // We need to check if the Key exists
        {
            Coins[name] += quantity; // We change the Value thanks to the Key
        }
        else
        {
            Coins.Add(name, quantity); // We add the Value to the Key
        }
    }

    public void RemoveCoinFromPortfolio(string name, decimal quantity)
    {
        if (!Coins.ContainsKey(name)) // If the Key doesn't exist, there's an error
        {
            throw new CoinNotFoundInPortfolioException();
        }
        if (quantity <= 0)
        {
            throw new QuantityIsSmallerThanZeroException();
        }
        var value = Coins[name]; // I can get the Value thanks to the Key
        if (value < quantity)
        {
            throw new InsufficientCoinsException($"Você não possui uma quantidade suficiente desta criptomoeda.");
        }
        Coins[name] -= quantity; // We change the Value thanks to the Key
    }
}

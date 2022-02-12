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
        if (Coins.ContainsKey(name)) // je vérifie que la clé existe
        {
            Coins[name] += quantity; // je modifie directement la valeur grâce à la clé name
        }
        else
        {
            Coins.Add(name, quantity); // je rajoute la valeur à la clé name
        }
    }

    public void RemoveCoinFromPortfolio(string name, decimal quantity)
    {
        if (!Coins.ContainsKey(name)) // je vérifie que la clé existe sinon erreur
        {
            throw new CoinNotFoundInPortfolioException();
        }
        if (quantity <= 0)
        {
            throw new QuantityIsSmallerThanZeroException();
        }
        var value = Coins[name]; // j'accède à la valeur grâce à la clé name
        if (value < quantity)
        {
            throw new InsufficientCoinsException($"Você não possui uma quantidade suficiente desta criptomoeda.");
        }
        Coins[name] -= quantity; // je modifie la valeur grâce à la clé name
    }
}

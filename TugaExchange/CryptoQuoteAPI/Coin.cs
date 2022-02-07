namespace CryptoQuoteAPI
{
    public class Coin
    {
        // Class properties
        // Private properties aren't meant to be accessed outside of the Class and need
        // to be modified using a method

        private string coin;
        private double marketValue;

        // Class methods
        // Constructor

        public Coin(string coin)
        {
            this.coin = coin;
            marketValue = 1;
        }
    }
}
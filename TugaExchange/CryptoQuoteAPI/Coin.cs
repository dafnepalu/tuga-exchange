namespace CryptoQuoteAPI
{
    public class Coin
    {
        // Class properties
        // Private properties aren't meant to be accessed outside of the Class and need
        // to be modified using a method

        private string name;
        private double marketValue;

        // Class methods
        // Constructor
        public Coin(string name)
        {
            this.name = name;
            marketValue = 1;
        }

        // Do I really need this?
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double MarketValue
        {
            get { return marketValue; }
            set { marketValue = value; }
        }
    }
}
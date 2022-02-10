using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ClassLibrary
{
    public class Investor
    {
		public decimal BalanceInEuros { get; set; } = 0;
		// "quantity" is a decimal because investors
		// are allowed to buy or sell fractions of a cryptocurrency.
		private List<(Coin, decimal quantity)> _coins = new List<(Coin, decimal quantity)>();

		/// <summary>
		/// Allows an investor to make a deposit into their own account.
		/// </summary>
		public void MakeDeposit(decimal euro)
		{
			BalanceInEuros += euro;
		}

		/// <summary>
		/// Allows an investor to buy cryptocurrency using their balance in EUR.
		/// </summary>
		/// <param name="coin">The coin to be purchased.</param>
		/// <param name="quantity">The number of coins to be purchased.</param>
		public void BuyCurrency(Coin coin, int quantity)
        {
			var subtotal = coin.MarketValue * quantity;
			var fee = subtotal * (decimal)0.01;
			var total = subtotal + fee;

			// Check if the investor can afford the operation
			if (BalanceInEuros < total)
            {
                Console.WriteLine("Você não tem saldo suficiente para realizar esta operação.");
            }
            else
            {
                _coins.Add((coin, quantity));
				BalanceInEuros -= total;
				var api = new API();
				api.Fees.Add(fee);
            }
        }

		/// <summary>
		/// Allows an investor to sell cryptocurrency they own.
		/// </summary>
		/// <param name="coin">The coin they want to sell.</param>
		/// <param name="quantity">The number of coins they want to sell.</param>
		public void SellCurrency(Coin coin, int quantity)
        {
			// Get updated values.
			var api = new API();
			api.GetPrices();

			if (_coins.Contains((coin, quantity)))
            {
				var subtotal = coin.MarketValue * quantity;
				var fee = subtotal * (decimal)0.01;
				BalanceInEuros += subtotal-fee;
				_coins.Remove((coin, quantity));
				api.Fees.Add(fee);
			}
            else
            {
                Console.WriteLine($"Você não tem um número suficiente de {coin} para efetuar esta operação.");
            }
        }
	}
}


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
		public int Id { get; set; }
		public Portfolio Portfolio { get; set; } = new Portfolio();
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoQuoteAPI;

namespace MainModule
{
    internal class Transaction
    {
        // The client initiates the transaction
        private Investor client;
        // Transactions can be deposits, purchases, and sales
        private string typeOfTransaction;
        // Clients can deposit EUR into their portfolio, and purchase and sell cryptocurrencies
        private Coin itemPurchased;
        // Clients can buy 100 EUR worth of a certain cryptocurrency, for example
        private double amount;
        // A 1% fee is charged for every transaction
        private double fee;
    }
}

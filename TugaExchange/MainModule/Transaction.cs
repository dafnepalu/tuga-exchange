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
        // The investor initiates the transaction.
        private Investor initiator;
        // Transactions can be deposits, purchases, and sales.
        private string typeOfTransaction;
        // Clients can deposit EUR into their portfolio, and purchase and sell cryptocurrencies.
        private Coin item; // But this means I have to add EUR to the Coin class, but should I? Or I could leave this empty in the Constructor I call for deposits?
        // Clients can buy or sell 100 EUR worth of a certain cryptocurrency, for example.
        private double amountInEuro;
        // A 1% fee is charged for every transaction (except for Deposits I guess)
        private double fee = 0.01; // But maybe it's better if I define this somewhere else?
        // Amount + fee (for deposits and purchases) or - fee (for sales)
        private double totalAmount;
        // Date and time in which the transaction took place
        private DateTime dateTime;

        // Constructor called for new Purchase and Sales transactions
        public Transaction(Investor initiator, string typeOfTransaction, Coin item, double amountInEuro)
        {
            this.initiator = initiator;
            this.typeOfTransaction = typeOfTransaction;
            this.item = item;
            this.amountInEuro = amountInEuro;
            dateTime = DateTime.Now;
            if (typeOfTransaction == "Purchase") // Add a fee to the amount the Investor wants to purchase
            {
                totalAmount = amountInEuro+(amountInEuro*fee);
            }
            else // Subtract the fee from the amount sold by the Investor
            {
                totalAmount = amountInEuro-(amountInEuro*fee);
            }
        }


        // Constructor called for new Deposit transactions
        public Transaction(Investor initiator, double amountInEuro)
        {
            this.initiator = initiator;
            typeOfTransaction = "Deposit";
            this.amountInEuro = amountInEuro;
            totalAmount = amountInEuro; // I won't charge any fees for deposits
            dateTime = DateTime.Now;
        }
    }
}

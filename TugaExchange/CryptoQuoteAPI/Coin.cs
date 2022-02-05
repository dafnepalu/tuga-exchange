using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQuoteAPI
{
    internal class Coin
    {
        // Propriedades de todos os membros da classe
        // "coin" e "marketValue" estão "private": não quero que sejam acessadas fora da classe, e vou precisar de um método para as modificar
        private string? coin;
        private double marketValue;



        // Construtor
        private Coin(string coin)
        {
            this.coin = coin;
            // Todas as moedas são criadas com um valor de 1 EUR
            marketValue = 1;
        }

        public void AddCoin(string coin)
        {
            Console.WriteLine("Hello");
        }

    }
}

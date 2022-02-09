using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; // Allows us to create the methods Save() and Read() below

namespace CryptoQuoteAPI;

public class API
{
    // Creates a list of coins:
    private List<Coin> _listOfCoins = new List<Coin>();

    // Adds a new coin into the system and to the list of coins simultaneously:
    public void AddCoin(string name)
    {
        _listOfCoins.Add(new Coin(name));
    }

    // Returns the list of coin names in string format:
    public List<string> GetCoins()
    {
        // Creates a new, updated List<string> every time the method is called:
        List<string> listOfCoinsStr = new List<string>();
        foreach (Coin coin in _listOfCoins)
        {
            listOfCoinsStr.Add(coin.Name);
        }
        return listOfCoinsStr;
    }

    // Removes a coin from the system:
    public void RemoveCoin(string name)
    {
        for (int i = 0; i < _listOfCoins.Count; i++)
        {
            Coin coin = _listOfCoins[i];
            if (coin.Name == name)
            {
                int index = i;
                _listOfCoins.RemoveAt(index);
            }
        }
    }

    //public GetPrices(out decimal[] prices, out string[] coins)
    //{
    //    // Devolve os preços atualizados de todas as moedas registadas;
    //}

    public void DefinePriceUpdateInSeconds(int seconds)
    {
        // Permite definir o intervalo de tempo em segundos que
        // o módulo atualiza a cotação das moedas;
    }

    //public int GetPriceUpdateInSeconds()
    //{
    //    // Permite obter o intervalo de tempo (em segundos) em que
    //    // o módulo calcula novos preços de cotações;
    //}

    public void Save()
    {
        // Permite gravar as cotações e moedas geridas, bem como a data do último câmbio;
        // Sempre que o método GetPrices() é chamado, deve ser chamado também
        // o método Save() para assegurar que em caso de falha do sistema,
        // os dados tenham sido persistidos
    }

    public void Read()
    {
        // Permite ler as moedas, câmbio e data a que dizem respeito;
        // Sempre que o programa é iniciado, o sistema deverá ver se o ficheiro já existe e, se sim, carregar todos os dados previamente persistidos
    }
}

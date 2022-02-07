using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoQuoteAPI
{
    internal class API
    {
        public void AddCoin(string coin)
        {
            // Permite adicionar uma nova criptomoeda no sistema da corretora;
        }

        public string[] GetCoins()
        {
            // Devolve a lista de todas as moedas geridas pela corretora;
        }

        public void RemoveCoin(string coin)
        {
            // Retira uma determinada criptomoeda do sistema de cotações;
        }

        public GetPrices(out decimal[] prices, out string[] coins)
        {
            // Devolve os preços atualizados de todas as moedas registadas;
        }

        public void DefinePriceUpdateInSeconds(int seconds)
        {
            // Permite definir o intervalo de tempo em segundos que
            // o módulo atualiza a cotação das moedas;
        }

        public int GetPriceUpdateInSeconds()
        {
            // Permite obter o intervalo de tempo (em segundos) em que
            // o módulo calcula novos preços de cotações;
        }

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
}

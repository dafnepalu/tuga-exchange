using ClassLibrary;
using System.Linq;

namespace Program
{
    public class Program
    {
        ////////////////////////////////////////////////////////////////////////////////
        /// CLASS PROPERTIES
        ////////////////////////////////////////////////////////////////////////////////

        static API api = new API();

        static Investor? currentInvestor;

        ////////////////////////////////////////////////////////////////////////////////
        /// CLASS METHODS
        ////////////////////////////////////////////////////////////////////////////////

        static void ShowWelcomeBanner()
        {
            string welcomeText = "TugaExchange - Cripto com confiança";
            string welcomeText50 = welcomeText.PadLeft(65, ' ');

            for (int i = 0; i < 48; i++)
            {
                Console.Write("* ");
            }

            Console.WriteLine("\n");
            Console.WriteLine(welcomeText50);
            Console.WriteLine("\n");

            for (int i = 0; i < 48; i++)
            {
                Console.Write("* ");
            }
            Console.WriteLine("\n");
        }

        static void PressKeyToContinue()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        static void OpenMainMenu()
        {
            int menuChoice;
            int menuChoice2;
            int menuChoice3;
            bool isValid;

            do
            {
                Console.WriteLine("Selecione uma opção para entrar:");
                Console.WriteLine("\n");
                Console.WriteLine("1 - Sou investidor/a");
                Console.WriteLine("2 - Sou administrador/a");
                Console.WriteLine("\n");

                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);


                if (menuChoice != 1 & menuChoice != 2)
                {
                    Console.Clear();
                    Console.WriteLine("Tem certeza de que inseriu uma opção válida?");
                }
                else
                {
                    Console.WriteLine($"Você escolheu a opção {menuChoice}.");
                }
            }
            while (menuChoice != 1 & menuChoice != 2);

            Console.Clear();

            switch (menuChoice)
            {
                case 1: // Investor menu
                    if (api.Investors.Count == 0)
                    {
                        currentInvestor = api.AddInvestor();
                        Console.WriteLine($"O seu ID de investidor é #{currentInvestor.Id}.");
                        OpenInvestorMenu();
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("Você já tem um ID de investidor?");
                            Console.WriteLine("1 - Sim");
                            Console.WriteLine("2 - Não");
                            isValid = Int32.TryParse(Console.ReadLine(), out menuChoice2);

                            if (menuChoice2 != 1 & menuChoice2 != 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, insira uma opção válida");
                            }
                        }
                        while (menuChoice2 != 1 & menuChoice2 != 2);

                        Console.Clear();

                        if (menuChoice2 == 1)
                        {
                            do
                            {
                                Console.WriteLine("Qual é o seu ID de investidor?");
                                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice3);

                                if (!isValid)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Por favor, insira um número.");
                                }

                                else
                                {
                                    if (menuChoice3 < 0)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Por favor, insira um número igual ou maior do que zero.");
                                        isValid = false;
                                    }
                                    else if (menuChoice3 > api.Investors.Count)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("O ID está incorreto. Por favor, tente novamente.");
                                        isValid = false;
                                    }
                                }
                            }
                            while (!isValid);

                            try
                            {
                                currentInvestor = api.GetInvestor(menuChoice);
                            }
                            catch (InvestorNotFoundException e)
                            {
                                Console.Clear();
                                Console.WriteLine($"{e.Message}");
                            }
                            if (currentInvestor != null)
                            {
                                Console.Clear();
                                Console.WriteLine($"Bem-vindo/a, investidor/a #{currentInvestor.Id}.");
                                OpenInvestorMenu();
                            }
                            else
                            {
                                OpenMainMenu();
                            }
                        }
                        else
                        {
                            currentInvestor = api.AddInvestor();
                            Console.WriteLine($"O seu ID de investidor é #{currentInvestor.Id}.");
                            OpenInvestorMenu();
                        }
                    }
                    break;
                case 2: // Admin menu
                    Console.Clear();
                    OpenAdminMenu();
                    break;
            }
        }

        static void OpenInvestorMenu()
        {
            int menuChoice;
            bool isValid;

            do
            {
                Console.WriteLine($"Sessão do investidor #{currentInvestor.Id}");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("\n");
                Console.WriteLine("1 - Depositar EUR");
                Console.WriteLine("2 - Comprar moeda");
                Console.WriteLine("3 - Vender moeda");
                Console.WriteLine("4 - Mostrar portfolio");
                Console.WriteLine("5 - Mostrar câmbio");
                Console.WriteLine("6 - Fechar a sessão atual e voltar ao menu principal");
                Console.WriteLine("7 - Sair");

                Console.WriteLine("\n");

                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);

                if (menuChoice != 1 & menuChoice != 2 & menuChoice != 3 & menuChoice != 4 & menuChoice != 5 & menuChoice != 6 & menuChoice != 7)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, escolha uma opção válida.");
                }
                else
                {
                    Console.WriteLine($"Você escolheu a opção {menuChoice}.");
                }
            }
            while (menuChoice != 1 & menuChoice != 2 & menuChoice != 3 & menuChoice != 4 & menuChoice != 5 & menuChoice != 6 & menuChoice != 7);

            Console.Clear();

            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine("Você está prestes a depositar dinheiro na sua carteira.");
                    bool amountIsValid;
                    decimal amount;
                    do
                    {
                        Console.WriteLine("Quanto quer depositar?");
                        amountIsValid = Decimal.TryParse(Console.ReadLine(), out amount);
                        if (!amountIsValid)
                        {
                            Console.Clear();
                            Console.WriteLine("Tem certeza de que introduziu uma opção válida?");
                        }
                        if (amountIsValid)
                        {
                            if (amount <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um valor maior do que zero.");
                                amountIsValid = false;
                            }
                            else
                            {
                                api.MakeDeposit(currentInvestor.Id, amount);
                                Console.WriteLine($"Você depositou {amount} EUR na sua carteira.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Por favor, introduza uma opção válida da próxima vez.");
                            OpenInvestorMenu();
                        }
                    }
                    while (!amountIsValid);
                    CloseInvestorMenu();
                    break;
                case 2:
                    Console.WriteLine("Você está prestes a comprar criptomoeda.");
                    var list = api.GetCoinNames();
                    decimal quantity;

                    do
                    {
                        Console.WriteLine("Selecione a moeda que deseja comprar:");
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {list[i]}");
                        }
                        Console.WriteLine("\n");
                        isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);

                        if (!isValid)
                        {
                            Console.Clear();
                            Console.WriteLine("Por favor, introduza um número da lista.");
                        }
                        else
                        {
                            if (menuChoice > list.Count)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número da lista.");
                                isValid = false;
                            }
                            if (menuChoice <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número da lista.");
                                isValid = false;
                            }
                        }
                    }
                    while (!isValid);
                    int index = menuChoice - 1;
                    string coinToPurchase = list[index];

                    do
                    {
                        Console.WriteLine("Quantas moedas deseja comprar?");
                        isValid = Decimal.TryParse(Console.ReadLine(), out quantity);

                        if (!isValid)
                        {
                            Console.Clear();
                            Console.WriteLine("Por favor, introduza um número inteiro (1, 2...) ou decimal (1,5, 3,5...).");
                        }
                        else
                        {
                            if (quantity <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número maior do que zero.");
                                isValid = false;
                            }
                        }
                    }
                    while (!isValid);

                    try
                    {
                        api.BuyCurrency(currentInvestor.Id, coinToPurchase, quantity);
                    }
                    catch (InsufficientFundsException e)
                    {
                        Console.Clear();
                        Console.WriteLine($"{e.Message}");
                        PressKeyToContinue();
                    }
                    Console.Clear();
                    Console.WriteLine($"Você comprou {quantity} unidade/s da criptomoeda {coinToPurchase}.");
                    CloseInvestorMenu();
                    break;
                case 3:
                    var dictionary = currentInvestor.Portfolio.Coins;
                    if (dictionary.Count == 0)
                    {
                        Console.WriteLine("Você ainda não possui criptomoeda.");
                        CloseInvestorMenu();
                    }
                    else
                    {
                        Console.WriteLine("Você está prestes a vender criptomoeda.");
                        do
                        {
                            Console.WriteLine("Selecione a moeda que deseja vender:");

                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                var element1 = dictionary.ElementAt(i);
                                var key = element1.Key;
                                Console.WriteLine($"{i + 1} - {key}");
                            }

                            Console.WriteLine("\n");
                            isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);

                            if (!isValid)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número da lista.");
                            }
                            else
                            {
                                if (menuChoice > dictionary.Count)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Por favor, introduza um número da lista.");
                                    isValid = false;
                                }
                                if (menuChoice <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Por favor, introduza um número da lista.");
                                    isValid = false;
                                }
                            }
                        }
                        while (!isValid);
                        var element = dictionary.ElementAt(menuChoice - 1);
                        var coinToSell = element.Key;
                        Console.WriteLine(coinToSell);
                        Console.Clear();

                        do
                        {
                            Console.WriteLine("Quantas moedas deseja vender?");
                            isValid = Decimal.TryParse(Console.ReadLine(), out quantity);

                            if (!isValid)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número inteiro (1, 2...) ou decimal (1,5, 3,5...).");
                            }
                            else
                            {
                                if (quantity <= 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Por favor, introduza um número maior do que zero.");
                                    isValid = false;
                                }
                            }
                        }
                        while (!isValid);
                        try
                        {
                            api.SellCurrency(currentInvestor.Id, coinToSell, quantity);
                        }
                        catch (InsufficientCoinsException e)
                        {
                            Console.Clear();
                            Console.WriteLine($"{e.Message}");
                            CloseInvestorMenu();
                        }
                        Console.Clear();
                        Console.WriteLine($"Você vendeu {quantity} unidade/s da criptomoeda {coinToSell}.");
                        CloseInvestorMenu();
                    }
                    break;
                case 4:
                    var portfolio = currentInvestor.Portfolio.Coins;
                    var balanceInEuro = currentInvestor.BalanceInEuros;

                    if (portfolio.Count == 0)
                    {
                        if (balanceInEuro == 0)
                        {
                            Console.WriteLine("O seu saldo em EUR é de 0 e você ainda não possui criptomoeda.");
                            CloseInvestorMenu();
                        }
                        else
                        {
                            Console.WriteLine($"Seu saldo em EUR é de {balanceInEuro}, mas você ainda não possui criptomoeda.");
                            CloseInvestorMenu();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Estes são os seus ativos:");

                        (List<string> names1, List<decimal> prices2) = api.GetPrices();

                        string balanceInEuroStr = Convert.ToString(balanceInEuro);
                        int balanceInEuroLength = balanceInEuroStr.Length;

                        Console.WriteLine($"{balanceInEuroStr.PadRight(10, ' ')} EUR @ 1,00 {balanceInEuroStr.PadLeft(10, ' ')} EUR");


                        foreach (KeyValuePair<string, decimal> pair in portfolio)
                        {
                            string pairValueStr = Convert.ToString(pair.Value);
                            int pairValueLength = pairValueStr.Length;
                            int firstColumnPadding = (balanceInEuroLength - pairValueLength) + 5;

                            var coinPrice = api.GetCoinPrice(pair.Key);
                            var coinPriceStr = coinPrice.ToString("0.00");


                            var maximumPairValue = portfolio.Values.Max();
                            var maximumPairValueToString = Convert.ToString(maximumPairValue);
                            var maximumPairValueLength = maximumPairValueToString.Length;

                            string longestPairKey = portfolio.Keys.OrderByDescending(s => s.Length).First();
                            int longestPairKeyLength = longestPairKey.Length;

                            var total = pair.Value * coinPrice;
                            var totalString = total.ToString("0.00");

                            Console.WriteLine($"{pairValueStr.PadRight(firstColumnPadding, ' ')} {pair.Key.PadRight(longestPairKeyLength, ' ')} @ {coinPriceStr} {totalString.PadRight(maximumPairValueLength, ' ')} EUR");
                        }

                        CloseInvestorMenu();
                    }
                    break;
                case 5:
                    Console.WriteLine($"Este é o registo do último câmbio, atualizado em {DateTime.Now}:");
                    // api.UpdatePrices();
                    (List<string> names, List<decimal> prices) = api.GetPrices();
                    string longest = names.OrderByDescending(s => s.Length).First();

                    // Show both lists' contents in the same line and align them.
                    foreach (var a in names.Zip(prices, (n, p) => new { n, p }))
                    {
                        Console.WriteLine($"{a.n.PadRight(longest.Length + 5, ' ')}{a.p}");
                    }
                    CloseInvestorMenu();
                    break;
                case 6:
                    Console.Clear();
                    OpenMainMenu();
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Até a próxima!");
                    break;
            }
        }

        static void OpenAdminMenu()
        {
            int menuChoice;
            bool isValid;

            Console.WriteLine("Bem-vindo/a, administrador/a.");

            do
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("\n");
                Console.WriteLine("1 - Adicionar moeda");
                Console.WriteLine("2 - Remover moeda");
                Console.WriteLine("3 - Ver relatório de comissões");
                Console.WriteLine("4 - Voltar ao menu principal");
                Console.WriteLine("5 - Sair");

                Console.WriteLine("\n");

                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);

                if (menuChoice != 1 & menuChoice != 2 & menuChoice != 3 & menuChoice != 4 & menuChoice != 5)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, escolha uma opção válida.");
                }
                else
                {
                    Console.WriteLine($"Você escolheu a opção {menuChoice}.");
                }
            }
            while (menuChoice != 1 & menuChoice != 2 & menuChoice != 3 & menuChoice != 4 & menuChoice != 5);

            Console.Clear();

            switch (menuChoice)
            {
                case 1:
                    string coinName;
                    Console.WriteLine("Você está prestes a criar uma nova moeda.");
                    Console.WriteLine("Qual é o nome da moeda que deseja adicionar?");
                    coinName = Console.ReadLine();

                    Console.Clear();
                    if (coinName == "")
                    {
                        Console.WriteLine("Você não introduziu nada.");
                    }
                    else
                    {
                        api.AddCoin(coinName);
                        Console.WriteLine($"Você introduziu a moeda {coinName} com sucesso. Esta é a lista atualizada de criptomoedas da TugaExchange:");
                        foreach (string coin in api.GetCoinNames())
                        {
                            Console.WriteLine(coin);
                        }
                    }
                    CloseAdminMenu();
                    break;
                case 2:
                    Console.WriteLine("Você está prestes a remover uma moeda.");
                    var list = api.GetCoinNames();
                    do
                    {
                        Console.WriteLine("Selecione uma opção a partir da lista abaixo:");
                        for (int i = 0; i < list.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {list[i]}");
                        }
                        Console.WriteLine("\n");
                        isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);

                        if (!isValid)
                        {
                            Console.Clear();
                            Console.WriteLine("Por favor, introduza um número da lista.");
                        }
                        else
                        {
                            if (menuChoice > list.Count)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número da lista.");
                                isValid = false;
                            }
                            else if (menuChoice <= 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Por favor, introduza um número da lista.");
                                isValid = false;
                            }
                        }
                    }
                    while (!isValid);
                    int index = menuChoice - 1;
                    string coinToRemove = list[index];
                    api.RemoveCoin(coinToRemove);
                    Console.Clear();
                    Console.WriteLine($"A criptomoeda {coinToRemove} foi removida do sistema. Esta é a lista atualizada de criptomoedas da TugaExchange:");
                    foreach (string coin in api.GetCoinNames())
                    {
                        Console.WriteLine(coin);
                    }
                    CloseAdminMenu();
                    break;
                case 3:
                    Console.WriteLine($"Até o momento, a TugaExchange registou um lucro de {api.Profit} EUR.");
                    CloseAdminMenu();
                    break;
                case 4:
                    Console.Clear();
                    OpenMainMenu();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Até a próxima!");
                    break;
            }
        }

        /// <summary>
        /// Is used at the end of every main operation in the Investor menu
        /// </summary>
        static void CloseInvestorMenu()
        {
            api.Save();
            int menuChoice;
            bool isValid;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("O que você deseja fazer agora?");
                Console.WriteLine("1 - Voltar para o menu Investidor");
                Console.WriteLine("2 - Fechar a sessão atual e voltar para o menu principal");
                Console.WriteLine("3 - Sair");
                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);
                Console.Clear();

                if (menuChoice != 1 & menuChoice != 2 & menuChoice != 3)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, escolha uma opção válida.");
                }
            }
            while (menuChoice != 1 & menuChoice != 2 & menuChoice != 3);

            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    OpenInvestorMenu();
                    break;
                case 2:
                    Console.Clear();
                    currentInvestor = null;
                    OpenMainMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Até à próxima!");
                    break;
            }
        }

        /// <summary>
        /// Is used at the end of every main operation in the Admin menu
        /// </summary>
        static void CloseAdminMenu()
        {
            api.Save();
            int menuChoice;
            bool isValid;

            do
            {
                Console.WriteLine("\n");
                Console.WriteLine("O que você deseja fazer agora?");
                Console.WriteLine("1 - Voltar para o menu Administrador");
                Console.WriteLine("2 - Voltar para o menu principal");
                Console.WriteLine("3 - Sair");
                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);
                Console.Clear();

                if (menuChoice != 1 & menuChoice != 2 & menuChoice != 3)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, escolha uma opção válida.");
                }
            }
            while (menuChoice != 1 & menuChoice != 2 & menuChoice != 3);

            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    OpenAdminMenu();
                    break;
                case 2:
                    Console.Clear();
                    OpenMainMenu();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Até à próxima!");
                    break;
            }
        }

        static void OpenAnythingElseMenu()
        {
            int menuChoice;
            bool isValid;

            do
            {
                Console.WriteLine("O que pretende fazer agora?");
                Console.WriteLine("\n");
                Console.WriteLine("1 - Voltar ao menu principal");
                Console.WriteLine("2 - Sair do programa");
                Console.WriteLine("\n");

                isValid = Int32.TryParse(Console.ReadLine(), out menuChoice);

                if (menuChoice != 1 & menuChoice != 2)
                {
                    Console.Clear();
                    Console.WriteLine("Por favor, escolha uma opção válida.");
                }
            }
            while (menuChoice != 1 & menuChoice != 2);

            switch (menuChoice)
            {
                case 1:
                    Console.Clear();
                    OpenMainMenu();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Até à próxima!");
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////
        /// MAIN PROGRAM
        ////////////////////////////////////////////////////////////////////////////////

        static void Main()
        {
            ///<summary>Reads previously saved data.</summary>
            api.Read();

            ShowWelcomeBanner();

            OpenMainMenu();

            ///<summary>Saves this session's data.</summary>
            api.Save();
        }
    }
}


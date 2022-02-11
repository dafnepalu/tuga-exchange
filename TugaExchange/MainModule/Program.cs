using ClassLibrary;

namespace Program
{
    public class Program
    {
        static API api = new API();

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
            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        static void OpenMainMenu()
        {
            char menuChoice;
            bool isValid;

            do
            {
                Console.WriteLine("Selecione uma opção para entrar:");
                Console.WriteLine("\n");
                Console.WriteLine("A - Sou investidor/a");
                Console.WriteLine("B - Sou administrador/a");
                Console.WriteLine("\n");

                isValid = char.TryParse(Console.ReadLine(), out menuChoice);


                if (menuChoice != 'a' & menuChoice != 'A' & menuChoice != 'b' & menuChoice != 'B')
                {
                    Console.Clear();
                    Console.WriteLine("Tem certeza de que inseriu uma opção válida?");
                }
                else
                {
                    string menuChoiceStr = menuChoice.ToString();
                    string menuChoiceStrUpper = menuChoiceStr.ToUpper();
                    Console.WriteLine($"Você escolheu a opção {menuChoiceStrUpper}.");
                }
            }
            while (menuChoice != 'a' & menuChoice != 'A' & menuChoice != 'b' & menuChoice != 'B');

            Console.Clear();

            switch (menuChoice)
            {
                case 'A':
                    OpenInvestorMenu();
                    break;
                case 'a':
                    OpenInvestorMenu();
                    break;
                case 'B':
                    OpenAdminMenu();
                    break;
                case 'b':
                    OpenAdminMenu();
                    break;
            }
        }

        static void OpenInvestorMenu()
        {
            int menuChoice;
            bool isValid;
            var investor = api.AddInvestor();

            Console.WriteLine($"Bem-vindo/a, investidor/a #{investor.Id}.");

            do
            {
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("\n");
                Console.WriteLine("1 - Depositar EUR");
                Console.WriteLine("2 - Comprar moeda");
                Console.WriteLine("3 - Vender moeda");
                Console.WriteLine("4 - Mostrar portfolio");
                Console.WriteLine("5 - Mostrar câmbio");
                Console.WriteLine("6 - Voltar ao menu principal");
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
                                api.MakeDeposit(investor.Id, amount);
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

                    Console.WriteLine("\n");
                    PressKeyToContinue();
                    Console.Clear();
                    OpenAnythingElseMenu();
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
                        api.BuyCurrency(investor.Id, coinToPurchase, quantity);
                    }
                    catch (InsufficientFundsException e)
                    {
                        Console.Clear();
                        Console.WriteLine($"{e.Message}");
                        PressKeyToContinue();
                    }
                    Console.Clear();
                    Console.WriteLine($"{quantity} unidade/s da criptomoeda {coinToPurchase} foi/foram adicionada/s ao seu portfolio.");
                    Console.WriteLine("\n");
                    PressKeyToContinue();
                    Console.Clear();
                    OpenAnythingElseMenu();
                    break;
                case 3:
                    var dictionary = investor.Portfolio.Coins;
                    Console.WriteLine("Você está prestes a vender criptomoeda.");
                    do
                    {
                        Console.WriteLine("Selecione a moeda que deseja vender:");
                        for (int i = 0; i < dictionary.Count; i++)
                        {
                            Console.WriteLine($"{i + 1} - {dictionary.Values}");
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
                    break;
                case 4:
                    Console.WriteLine("Você selecionou a opção 4.");
                    break;
                case 5:
                    Console.WriteLine("Mostrando o câmbio:");
                    //var api = new API();
                    //api.ShowRates();
                    OpenAnythingElseMenu();
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
                    Console.WriteLine("\n");
                    PressKeyToContinue();
                    Console.Clear();
                    OpenAnythingElseMenu();
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
                    Console.WriteLine("\n");
                    PressKeyToContinue();
                    Console.Clear();
                    OpenAnythingElseMenu();
                    break;
                case 3:
                    Console.WriteLine($"Até o momento, a TugaExchange registou um lucro de {api.Profit} EUR.");
                    Console.WriteLine("\n");
                    PressKeyToContinue();
                    Console.Clear();
                    OpenAnythingElseMenu();
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
                    Console.WriteLine("Até à próxima!");
                    break;
            }
        }

        static void Main()
        {
            ///<summary>Creates a new API object and attributes it to Program's api property.</summary>
            var api = new API();
            Program.api = api;

            ///<summary>Reads previously saved data.</summary>
            api.Read();

            ShowWelcomeBanner();

            OpenMainMenu();

            ///<summary>Saves this session's data.</summary>
            api.Save();
        }

    }
}

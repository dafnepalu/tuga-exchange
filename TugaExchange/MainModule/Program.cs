using ClassLibrary;
using ConsoleApp;

/// <summary>
/// Shows the latest exchange rates.
/// </summary>
static void ShowRates()
// This features a ZIP operation
{
    API api = new API();
    (var names, var values) = api.GetPrices();
    var namesAndValues = names.Zip(values, (n, v) => new { Name = n, Value = v });
    foreach (var nv in namesAndValues)
    {
        Console.WriteLine(nv.Name + nv.Value);
    }
}


static void AnythingElse()
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
        else
        {
            Console.WriteLine($"Você escolheu a opção {menuChoice}.");
        }
    }
    while (menuChoice != 1 & menuChoice != 2);

    switch (menuChoice)
    {
        case 1:
            Menu.OpenMainMenu();
            break;
        case 2:
            Console.WriteLine("Até à próxima!");
            break;
    }
    }

static void InvestorMenu()
{
    int menuChoice;
    bool isValid;

    Console.WriteLine("Bem-vindo/a, investidor/a.");

    do
    {
        Console.WriteLine("O que deseja fazer?");
        Console.WriteLine("\n");
        Console.WriteLine("1 - Depositar");
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
            Investor investor = new Investor();
            investor.MakeDeposit(100);
            Console.WriteLine("Você depositou 100 euros na sua conta.");       
            break;
        case 2:
            Console.WriteLine("Você selecionou a opção 2.");
            break;
        case 3:
            Console.WriteLine("Você selecionou a opção 3.");
            break;
        case 4:
            Console.WriteLine("Você selecionou a opção 4.");
            break;
        case 5:
            Console.WriteLine("Mostrando o câmbio:");
            ShowRates();
            AnythingElse();
            break;
        case 6:
            Menu.OpenMainMenu();
            break;
        case 7:
            Console.WriteLine("Até a próxima!");
            // How can I close the console automatically?
            break;
    }
}

    static void AdminMenu()
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
                Console.WriteLine("Você está prestes a criar uma nova moeda.");
                Console.WriteLine("Qual é o nome da moeda que deseja adicionar?");
                string coin = Console.ReadLine();
                // Create new API instance
                //API action = new API();
                //action.AddCoin(coin);
                //foreach (string item in API.GetCoins()) // Result is weird AF
                //{
                //    Console.WriteLine(item);
                //}
                //Console.WriteLine(API.GetCoins()); doesn't quite work
                AnythingElse();
                break;
            case 2:
                Console.WriteLine("Você está prestes a remover uma moeda.");
                Console.WriteLine("Selecione uma opção a partir da lista abaixo:");
                // algo com GetCoins();
                break;
            case 3:
                Console.WriteLine("Carregando o relatório de comissões...");
                break;
            case 4:
                Menu.OpenMainMenu();
                break;
            case 5:
                Console.WriteLine("Até a próxima!");
                // How can I close the console automatically?
                break;
        }
    }

//static void CommissionReport()
//{
//    // Relatório de comissão
//}

// Main
// Displays a welcome banner.
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

// Creates an API object so we can call the methods and properties in the API class.
var api = new API();

// Reads previously saved data.
api.Read();

// Opens the main menu.
Menu.OpenMainMenu();

// Saves the managed quotes and currencies, the date of the last exchange, and investor info.
api.Save();

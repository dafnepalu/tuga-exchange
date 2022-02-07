using CryptoQuoteAPI;

static void MainMenu()
{
    // Determina o comportamento do menu principal
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
        string menuChoiceStr = menuChoice.ToString();
        string menuChoiceStrUpper = menuChoiceStr.ToUpper();

        if (menuChoice != 'a' & menuChoice != 'A' & menuChoice != 'b' & menuChoice != 'B')
        {
            Console.WriteLine("Tem certeza de que inseriu uma opção válida?");
        }
        else
        {
            Console.WriteLine($"Você escolheu a opção {menuChoiceStrUpper}.");
        }
    }
    while (menuChoice != 'a' & menuChoice != 'A' & menuChoice != 'b' & menuChoice != 'B');

    // Find a way to delay clearing the console for a bit (Task.Delay?)
    Console.Clear();

    switch (menuChoice)
    {
        case 'A':
            InvestorMenu();
            break;
        case 'a':
            InvestorMenu();
            break;
        case 'B':
            AdminMenu();
            break;
        case 'b':
            AdminMenu();
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
            Console.WriteLine("Você selecionou a opção 1.");
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
            Console.WriteLine("Você selecionou a opção 5.");
            break;
        case 6:
            Console.WriteLine("Você selecionou a opção 6.");
            break;
        case 7:
            Console.WriteLine("Você selecionou a opção 7.");
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
            // Criar um objeto ApiAction para chamar o método AddCoin
            ApiAction addCoin = new ApiAction();
            addCoin.AddCoin(coin);
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
            Console.WriteLine("Você selecionou a opção 5.");
            break;
        case 6:
            Console.WriteLine("Você selecionou a opção 6.");
            break;
        case 7:
            Console.WriteLine("Você selecionou a opção 7.");
            break;
    }
}

// Faixa de boas-vindas

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

// Esperar um pouco até o menu principal aparecer
// Task.Delay?
// Limpar a console
// Console.Clear();

// Chamar o menu principal
MainMenu();

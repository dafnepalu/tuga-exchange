using ClassLibrary;

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
            MainMenu();
            break;
        case 2:
            Console.WriteLine("Até à próxima!");
            break;
    }
    }

    static void Depositar()
    {
        Console.WriteLine("Quantos euros pretende depositar?");
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
                Depositar();
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
                MainMenu();
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
                MainMenu();
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


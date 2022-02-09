using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace ConsoleApp
{
    internal class Menu
    {
        /// <summary>
        /// Opens the program's main menu.
        /// </summary>
        public static void OpenMainMenu()
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

            // Find a way to delay clearing the console for a bit (Task.Delay?)
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

        /// <summary>
        /// Opens the program's investor menu.
        /// </summary>
        public static void OpenInvestorMenu()
        {
            var investor = new Investor();
            int menuChoice;
            bool isValid;

            Console.WriteLine("Bem-vindo/a, investidor/a.");

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
                            Console.WriteLine("Tem certeza de que introduziu uma opção válida?");
                        }
                    }
                    while (!amountIsValid);

                    if (amountIsValid)
                    {
                        if (amount <= 0)
                        {
                            Console.WriteLine("Por favor, escolha um valor maior do que zero da próxima vez.");
                            OpenInvestorMenu();
                        }
                        else
                        {
                            investor.MakeDeposit(amount);
                            Console.WriteLine($"Você depositou {amount} EUR na sua carteira.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, introduza uma opção válida da próxima vez.");
                        OpenInvestorMenu();
                    }
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
                    //ShowRates();
                    //AnythingElse();
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

        public static void OpenAdminMenu()
        {

        }
    }
}

using ClassLibrary;
using ConsoleApp;

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

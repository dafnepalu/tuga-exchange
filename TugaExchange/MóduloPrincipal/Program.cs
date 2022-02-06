// O módulo principal é o responsável por gerir as transações de compra e venda, devendo também permitir a visualização de relatórios de lucros provenientes das comissões.

char option;

// Selecione uma opção para entrar
start:
try
{
    do
    {
        Console.WriteLine("Selecione uma opção para entrar: (a) Investidor (b) Administrador");
        option = Convert.ToChar(Console.ReadLine()); // Tem que ser exatamente um caractere - prever uma exceção 
    }
    while (option != 'a' | option != 'A' | option != 'b' | option != 'B');

    // Determinar o menu em que entrar
    if (option == 'a' | option == 'A')
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo/a, investidor/a");
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("(1) Depositar");
        Console.WriteLine("(2) Comprar moeda");
        Console.WriteLine("(3) Vender moeda");
        Console.WriteLine("(4) Mostrar portfolio");
        Console.WriteLine("(5) Mostrar câmbio");
        Console.WriteLine("(6) Sair");
    }

    //else if (option == 'b' | option == 'B')
    else
    {
        Console.Clear();
        Console.WriteLine("Bem-vindo/a, administrador/a");
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("(1) Adicionar moeda");
        Console.WriteLine("(2) Remover moeda");
        Console.WriteLine("(3) Ver relatório de comissões");
        Console.WriteLine("(4) Sair");
    }
    //else
    //{
    //    Console.WriteLine("Por favor, introduza uma opção válida: (a) ou (b)");
    //}
}
catch (Exception e)
{
    Console.WriteLine("Você digitou uma opção válida? Tente novamente.");
    goto start;
}



// O módulo principal é o responsável por gerir as transações de compra e venda, devendo também permitir a visualização de relatórios de lucros provenientes das comissões.

// Selecione uma opção para entrar
Console.WriteLine("Selecione uma opção para entrar: (a) Investidor (b) Administrador");
char option = Convert.ToChar(Console.ReadLine());

// Determinar o menu em que entrar
if (option == 'a' | option == 'A')
{
    Console.WriteLine("Bem-vind@, investidor@");
}
else if (option == 'b' | option == 'B')
{
    Console.WriteLine("Bem-vind@, administrador@");
}
else
{
    Console.WriteLine("Por favor, introduza uma opção válida: (a) ou (b)");
}

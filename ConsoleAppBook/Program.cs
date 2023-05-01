using ConsoleAppBook.Services.Services.Implementations;

MenuService menuService = new MenuService();

Console.WriteLine("1.As Admin");
Console.WriteLine("2.As User");

string request = Console.ReadLine();

if (request == "1")
{
    bool result = await menuService.Login();

    while (!result)
    {

        result = await menuService.Login();

        if (!result)
        {
            Console.WriteLine("2.return As User");
            request = Console.ReadLine();

            if (request == "2")
            {
                result = true;
            }
        }
    }
}

if (menuService.IsAdmin)
{
    menuService.ShowMenuAdmin();
}
else
{
    menuService.ShowMenuUser();
}
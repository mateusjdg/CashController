using System;

namespace CashController
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!\n");

            FinanceCategory food = new FinanceCategory();

            food.SetCategoryName("alimentacao");
            food.Deposit(650.00);
            if( food.Withdraw(550.00) )
            {
                Console.WriteLine("Deposito realizado com sucesso");
            }
            else
            {
                Console.WriteLine("Impossivel realizar deposito requisitado");
                Console.WriteLine("Status do flag de overload {0}", food.overloadStatus);
            }

            Console.WriteLine($"\nTotal disponivel para a categoria {food.GetCategoryName()}: {food.GetRealAmount()}");

            FinanceCategory[] categories;
            categories = new FinanceCategory();

            categories[0].SetCategoryName("saude");
            Console.WriteLine("Nome da primeira categoria: {0}", categories[0].GetCategoryName());

        }
    }
}

using System;
using System.Collections.Generic;

namespace CashController
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FinanceCategory> categories = new List<FinanceCategory>();

            int i = 0;

            Console.Title = "Cash Controller - By Mateus";
            Console.BackgroundColor;

            string opcao = "1";

            while (opcao == "1")
            {
                Console.WriteLine("Digite o nome de uma categoria financeira:");
                string nome = Console.ReadLine();
                categories.Add(new FinanceCategory { });
                categories[i].SetCategoryName(nome);

                Console.WriteLine("Deseja inserir outra categoria? 1-SIM | 2-NAO");
                opcao = Console.ReadLine();

                if (opcao == "1")
                    i++;
                else
                    i = 0;
            }

            int count = categories.Count;
            Console.WriteLine("Quantidade de categorias apos do loop: {0}", count);
            for (int j = 0; j < count; j++ )
            {
                Console.WriteLine("Nome da categoria[{0}]: {1}", j, categories[j].GetCategoryName());
            }
        }
    }
}

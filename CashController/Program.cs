using System;
using System.Collections.Generic;

namespace CashController
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FinanceCategory> categories = new List<FinanceCategory>();

            Console.Title = "Cash Controller - By Mateus";

            /*************************************************************************/
            /* Great colors for foreground: Green, Cyan, Red, Magenta, Yellow, White */
            /*************************************************************************/

            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine("The foreground color is green.");
            //Console.ForegroundColor = currentForeground;
            //Console.ResetColor();

            /******************************************************/

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| Cash Controller - Welcome to Finantial Freedom |");
            Console.WriteLine("--------------------------------------------------\n");

            for (; ; ) {

                Console.WriteLine("Menu:\n");
                Console.WriteLine("1 - Cadastrar categorias financeiras e seus limites");
                Console.WriteLine("2 - Listar todas as categorias e seus limites");
                Console.WriteLine("3 - Credito");
                Console.WriteLine("4 - Debito");
                Console.WriteLine("5 - Fechar o programa\n");
                Console.ForegroundColor = currentForeground;

                Console.Write("Digite a função desejada: ");
                string option = Console.ReadLine();
                string userChoice = "1";
                int catCount = 0; ;

                switch (option)
                {
                    case "1":
                        while (userChoice == "1")
                        {
                            Console.Write("\nNome da categoria desejada: ");
                            string catName = Console.ReadLine();
                            categories.Add(new FinanceCategory { });
                            categories[catCount].SetCategoryName(catName);

                            Console.Write("Limite maximo estimado para gasto: ");
                            double catLimit = Convert.ToDouble(Console.ReadLine());
                            categories[catCount].SetForeseenAmount(catLimit);

                            Console.WriteLine("\nDeseja inserir outra categoria? 1-SIM | 2-NAO");
                            userChoice = Console.ReadLine();
                            if (userChoice == "1")
                                catCount++;
                            else
                                catCount = 0;
                        }
                        break;
                    case "2":
                        for (int j = 0; j < categories.Count; j++)
                        {
                            Console.WriteLine("\nNome da categoria: {0} - Limite: {1}",categories[j].GetCategoryName(),categories[j].GetForeseenAmount());
                        }
                        break;
                    case "3":
                        Console.WriteLine("Opcao 3 escolhida!");
                        break;
                    case "4":
                        Console.WriteLine("Opcao 4 escolhida!");
                        break;
                    case "5":
                        Console.WriteLine("Encerrando o programa!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcao invalida!");
                        break;
                }
            }
            
            int i = 0;
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

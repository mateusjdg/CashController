using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Newtonsoft.Json;


namespace CashController
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FinanceCategory> categories = new List<FinanceCategory>();

            Console.Title = "Cash Controller - By Mateus";
            string path = @"C:\Users\mateus.gagliardi\Desktop\CSharp\Mateus\CashController\CashController\categories.json";
            //string path = @"C:\Users\mms\Desktop\Csharp\CashController\CashController\categories.json";

            /*************************************************************************/
            /* Great colors for foreground: Green, Cyan, Red, Magenta, Yellow, White */
            /*************************************************************************/

            ConsoleColor currentBackground = Console.BackgroundColor;
            ConsoleColor currentForeground = Console.ForegroundColor;

            /******************************************************/

            if (File.Exists(path))
            { 
                categories = JsonConvert.DeserializeObject<List<FinanceCategory>>(File.ReadAllText(path));
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("| Cash Controller - Welcome to Finantial Freedom |");
            Console.WriteLine("--------------------------------------------------");

            for (; ; ) {

                Console.WriteLine("\nMenu:\n");
                Console.WriteLine("1 - Cadastrar categorias financeiras e seus limites");
                Console.WriteLine("2 - Listar todas as categorias, situacao atual e limites");
                Console.WriteLine("3 - Eliminar uma categoria");
                Console.WriteLine("4 - Inserir gasto em categoria");
                Console.WriteLine("5 - Salvar");
                Console.WriteLine("6 - Fechar o programa\n");
                Console.ForegroundColor = currentForeground;

                Console.Write("Digite a função desejada: ");
                string option = Console.ReadLine();
                string userChoice = "1";
                int catCount = categories.Count;

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

                            Console.Write("\nDeseja inserir outra categoria (1-SIM | 2-NAO)? ");
                            userChoice = Console.ReadLine();
                            if (userChoice == "1")
                                catCount++;
                            else
                                catCount = 0;
                        }
                        break;

                    case "2":

                        if (categories.Count > 0)
                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            TableParser tableParser = new TableParser();
                            tableParser.PrintLine();
                            string[] titleNames = new string[] { "CATEGORIA", "VALOR GASTO", "LIMITE", "DELTA" };
                            tableParser.PrintRow(titleNames);
                            tableParser.PrintLine();
                            
                            Console.ForegroundColor = ConsoleColor.White;
                            for (int j = 0; j < categories.Count; j++)
                            { 
                                string[] colData = new string[] { categories[j].GetCategoryName(), categories[j].GetRealAmount().ToString(), categories[j].GetForeseenAmount().ToString(), (categories[j].GetForeseenAmount() - categories[j].GetRealAmount()).ToString() };
                                tableParser.PrintRow(colData);
                                tableParser.PrintLine();
                            }
                                                       
                            Console.ForegroundColor = currentForeground;
                            
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNao existem categorias cadastradas!");
                            Console.ForegroundColor = currentForeground;
                        }
                        
                        break;

                    case "3":
                        if (categories.Count > 0)
                        {
                            bool deleteDone = false;
                            Console.Write("Categoria a ser eliminada: ");
                            string catDelOption = Console.ReadLine();

                            for (int m = 0; m < categories.Count; m++)
                            {
                                if (categories[m].GetCategoryName() == catDelOption)
                                {
                                    deleteDone = true;
                                    categories.RemoveAt(m);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nCategoria eliminada com sucesso!");
                                    Console.ForegroundColor = currentForeground;
                                    break;
                                }
                            }
                            if (!deleteDone)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nCategoria nao encontrada!");
                                Console.ForegroundColor = currentForeground;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNao existem categorias cadastradas!");
                            Console.ForegroundColor = currentForeground;
                        }

                        break;

                    case "4":
                        if (categories.Count > 0)
                        {

                            bool registerDone = false;
                            Console.Write("\nValor gasto: ");
                            double expendValue = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Categoria do gasto: ");
                            string catCreditOption = Console.ReadLine();

                            for (int k = 0; k < categories.Count; k++)
                            {
                                if (categories[k].GetCategoryName() == catCreditOption)
                                {
                                    if (categories[k].ExpenseInput(expendValue))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("\nGasto inserido com sucesso!");
                                        Console.WriteLine("Valor restante na categoria {0}: {1}", categories[k].GetCategoryName(), (categories[k].GetForeseenAmount() - categories[k].GetRealAmount()));
                                        Console.ForegroundColor = currentForeground;
                                        registerDone = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nErro ao inserir gasto!");
                                        Console.WriteLine("Valor igual a zero!");
                                        registerDone = true;
                                    }
                                }
                            }
                            if (!registerDone)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nCategoria nao encontrada!");
                                Console.ForegroundColor = currentForeground;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNao existem categorias cadastradas!");
                            Console.ForegroundColor = currentForeground;
                        }
                
                        break;

                    case "5":
                        if (categories.Count > 0)
                        {
                            Console.Write("\nSalvando...\n");
                            Thread.Sleep(500);
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine("{0}", JsonConvert.SerializeObject(categories));
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNao tenho nada para salvar!");
                            Console.ForegroundColor = currentForeground;
                        }             

                        break;
          
                    case "6":
                        Console.WriteLine("Encerrando o programa!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nOpcao invalida!");
                        Console.ForegroundColor = currentForeground;
                        break;
                }
            }
        }
    }
}

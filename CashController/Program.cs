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
                Console.WriteLine("2 - Listar todas as categorias e seus limites");
                Console.WriteLine("3 - Listar todas as categorias e situacao atual");
                Console.WriteLine("4 - Eliminar uma categoria");
                Console.WriteLine("5 - Deposito");
                Console.WriteLine("6 - Retirada");
                Console.WriteLine("7 - Salvar");
                Console.WriteLine("8 - Fechar o programa\n");
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
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            for (int j = 0; j < categories.Count; j++)
                            {
                                Console.WriteLine("Nome da categoria: {0} - Limite: {1}", categories[j].GetCategoryName(), categories[j].GetForeseenAmount());
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
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            for (int n = 0; n < categories.Count; n++)
                            {
                                Console.WriteLine("Nome da categoria: {0} - Limite: {1}", categories[n].GetCategoryName(), categories[n].GetRealAmount());
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

                    case "4":
                        Console.Write("Categoria a ser eliminada: ");
                        string catDelOption = Console.ReadLine();

                        for (int m = 0; m < categories.Count; m++)
                        {
                            if (categories[m].GetCategoryName() == catDelOption)
                            {
                                categories.RemoveAt(m);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nCategoria eliminada com sucesso!");
                                Console.ForegroundColor = currentForeground;
                                break;
                            }
                        }

                        break;

                    case "5":
                        bool depositDone = false;
                        Console.Write("\nValor do deposito a ser realizado: ");
                        double creditValue = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Categoria a ser creditada: ");
                        string catCreditOption = Console.ReadLine();

                        for (int k = 0; k < categories.Count; k++)
                        {
                            if(categories[k].GetCategoryName() == catCreditOption)
                            {
                                if (categories[k].Deposit(creditValue))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nDeposito realizado com sucesso!");
                                    Console.WriteLine("Valor disponivel na categoria {0}: {1}", categories[k].GetCategoryName(), categories[k].GetRealAmount());
                                    Console.ForegroundColor = currentForeground;
                                    depositDone = true;
                                }
                                else
                                {
                                    Console.WriteLine("Erro ao realizar deposito!");
                                }
                            }
                        }
                        if (!depositDone)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nCategoria nao encontrada!");
                            Console.ForegroundColor = currentForeground;
                        }
                
                        break;

                    case "6":
                        bool withDrawDone = false;
                        Console.Write("\nValor da retirada a ser realizada: ");
                        double withDrawValue = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Categoria a ser debitada: ");
                        string catDebitOption = Console.ReadLine();

                        for (int m = 0; m < categories.Count; m++)
                        {
                            if (categories[m].GetCategoryName() == catDebitOption)
                            {
                                if (categories[m].Withdraw(withDrawValue))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nRetirada realizada com sucesso!");
                                    Console.WriteLine("Valor disponivel na categoria {0}: {1}", categories[m].GetCategoryName(), categories[m].GetRealAmount());
                                    Console.ForegroundColor = currentForeground;
                                    withDrawDone = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nErro ao realizar retirada!");
                                    Console.WriteLine("Valor solicitado e maior que o disponivel!");
                                    Console.WriteLine("Solicitado: {0} / Disponivel {1}", withDrawValue, categories[m].GetRealAmount());
                                    Console.ForegroundColor = currentForeground;
                                    withDrawDone = true;
                                }
                            }
                        }
                        if (!withDrawDone)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nCategoria nao encontrada!");
                            Console.ForegroundColor = currentForeground;
                        }

                        break;

                    case "7":
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
                            Console.WriteLine("\nNao existem categorias cadastradas!");
                            Console.ForegroundColor = currentForeground;
                        }             

                        break;
          
                    case "8":
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

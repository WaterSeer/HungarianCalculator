using System;
using System.IO;

namespace HungarianCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticExpression ae = new ArithmeticExpression();
            Calculator c = new Calculator();

            string userInput;            
            while (true)
            {
                Console.WriteLine("Введите выражение, путь к файлу или q для выхода");
                userInput = Console.ReadLine();

                if (userInput == 'q'.ToString())
                    break;
                
                if (File.Exists(userInput))
                {
                    Console.WriteLine("Направлен в файл result.txt\n");
                    Console.WriteLine();
                    StreamService streamService = new StreamService();
                    var linesFromFile = streamService.ReadFromFile(userInput);
                    streamService.WriteToFile(linesFromFile, Environment.CurrentDirectory + "/result.txt");
                    continue;
                }

               
                switch (c.Calculate(c.ProcessInput(userInput)))
                {
                    case double.NegativeInfinity:
                        Console.WriteLine("Ошибка деления на ноль\n");
                        break;
                    case double.PositiveInfinity:
                        Console.WriteLine("Ошибка деления на ноль\n");
                        break;
                    case double.NaN:
                        Console.WriteLine("Ошибка в выражении\n");
                        break;
                    default:
                        Console.WriteLine(c.Calculate(c.ProcessInput(userInput))+"\n");
                        break;
                }
            }           
        }
    }
}

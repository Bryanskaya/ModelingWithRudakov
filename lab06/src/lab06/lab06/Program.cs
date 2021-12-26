using System;
using System.Threading;

namespace lab06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Обслужено \t Отказано \t Время мод-ния \t Вероятность отказа \t Макс размер очереди 1 | 2 | 3 | 4");

            for (int i = 0; i < 10; i++)
            {
                Model model = new Model(1000);
                model.Imitation();

                Console.WriteLine($"  {model.processed} \t\t {model.refused} \t\t {Math.Round(model.simTime, 5)} \t\t {Math.Round(model.pRefuse, 3)} \t\t\t\t     {model.maxSizeQ[0]} | {model.maxSizeQ[1]} | {model.maxSizeQ[2]} |{model.maxSizeQ[3]}");
                Thread.Sleep(5);
            }

            Console.WriteLine("\nPress any button");
            Console.ReadKey();
        }
    }
}

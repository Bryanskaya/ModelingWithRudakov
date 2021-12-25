using System;
using System.Threading;

namespace lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Обслужено \t Отказано \t Время моделирования \t Вероятность отказа");
            for (int i = 0; i < 10; i++)
            {
                Model model = new Model(300);
                model.Imitation();
                Console.WriteLine($"   {model.processed} \t\t {model.refused} \t\t {Math.Round(model.simTime, 5)} \t\t {Math.Round(model.pRefuse, 3)}");
                Thread.Sleep(5);
            }

            Console.WriteLine("\nPress any button");
            Console.ReadKey();
        }
    }
}

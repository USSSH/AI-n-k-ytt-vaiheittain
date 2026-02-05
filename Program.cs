using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== Ajanvaraus ===");
                Console.WriteLine("1. Vapaat ajat");
                Console.WriteLine("2. Varaa aika");
                Console.WriteLine("3. Peru aika");
                Console.WriteLine("X. Lopeta");
                Console.Write("\nValitse: ");

                string valinta = Console.ReadLine();

                switch (valinta.ToUpper())
                {
                    case "1":
                        Console.WriteLine("\nVapaat ajat");
                        break;
                    case "2":
                        Console.WriteLine("\nVaraa aika");
                        break;
                    case "3":
                        Console.WriteLine("\nPeru aika");
                        break;
                    case "X":
                        Console.WriteLine("\nOhjelma päätetään.");
                        return;
                    default:
                        Console.WriteLine("\nVirheellinen valinta. Yritä uudelleen.");
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static List<string> VaratutAika = new List<string>();

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
                        VaraaAika();
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

        static void VaraaAika()
        {
            Console.WriteLine($"\nTänään on {DateTime.Today:yyyy-MM-dd}");
            Console.WriteLine("Kirjoita B palataksesi edelliseen valikkoon, X lopettaaksesi.");

            Console.Write("Päivämäärä (esim. 2026-02-05): ");
            string pvm = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pvm))
            {
                Console.WriteLine("Peruutetaan varaus.");
                return;
            }
            if (pvm.Equals("B", StringComparison.OrdinalIgnoreCase)) return;
            if (pvm.Equals("X", StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Ohjelma päätetään."); Environment.Exit(0); }

            Console.Write("Alkamiskellonaika (HH:mm): ");
            string alk = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(alk))
            {
                Console.WriteLine("Peruutetaan varaus.");
                return;
            }
            if (alk.Equals("B", StringComparison.OrdinalIgnoreCase)) return;
            if (alk.Equals("X", StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Ohjelma päätetään."); Environment.Exit(0); }

            Console.Write("Päättymiskellonaika (HH:mm): ");
            string loppu = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(loppu))
            {
                Console.WriteLine("Peruutetaan varaus.");
                return;
            }
            if (loppu.Equals("B", StringComparison.OrdinalIgnoreCase)) return;
            if (loppu.Equals("X", StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Ohjelma päätetään."); Environment.Exit(0); }

            string varaus = $"{pvm} {alk}-{loppu}";
            VaratutAika.Add(varaus);
            Console.WriteLine($"Aika lisätty varattuihin: {varaus}");
        }
    }
}

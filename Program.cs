using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        class Booking
        {
            public DateTime Date { get; }
            public TimeSpan Start { get; }
            public TimeSpan End { get; }
            public Booking(DateTime date, TimeSpan start, TimeSpan end)
            {
                Date = date.Date;
                Start = start;
                End = end;
            }
            public override string ToString() => $"{Date:yyyy-MM-dd} {Start:hh\\:mm}-{End:hh\\:mm}";
        }

        static List<Booking> VaratutAika = new List<Booking>();

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
                        PeruAika();
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
            if (!DateTime.TryParse(pvm, out DateTime date))
            {
                Console.WriteLine("Virheellinen päivämäärä. Käytä muotoa YYYY-MM-DD tai vastaavaa.");
                return;
            }

            var dow = date.DayOfWeek;
            if (dow == DayOfWeek.Saturday || dow == DayOfWeek.Sunday)
            {
                Console.WriteLine("Virhe: Liike ei ole auki lauantaina eikä sunnuntaina.");
                return;
            }

            Console.Write("Alkamiskellonaika (HH:mm): ");
            string alk = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(alk))
            {
                Console.WriteLine("Peruutetaan varaus.");
                return;
            }
            if (alk.Equals("B", StringComparison.OrdinalIgnoreCase)) return;
            if (alk.Equals("X", StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Ohjelma päätetään."); Environment.Exit(0); }
            if (!TimeSpan.TryParse(alk, out TimeSpan start))
            {
                Console.WriteLine("Virheellinen kellonaika. Käytä muotoa HH:mm.");
                return;
            }

            Console.Write("Päättymiskellonaika (HH:mm): ");
            string loppu = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(loppu))
            {
                Console.WriteLine("Peruutetaan varaus.");
                return;
            }
            if (loppu.Equals("B", StringComparison.OrdinalIgnoreCase)) return;
            if (loppu.Equals("X", StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Ohjelma päätetään."); Environment.Exit(0); }
            if (!TimeSpan.TryParse(loppu, out TimeSpan end))
            {
                Console.WriteLine("Virheellinen kellonaika. Käytä muotoa HH:mm.");
                return;
            }

            TimeSpan open = TimeSpan.FromHours(8);
            TimeSpan close = TimeSpan.FromHours(16);

            if (start < open || end > close || start >= end)
            {
                Console.WriteLine("Virhe: Liike on auki vain arkisin 08:00 - 16:00 ja aloitus täytyy olla ennen loppua.");
                return;
            }

            // Tarkista päällekkäisyydet
            var bookingsForDay = VaratutAika.Where(b => b.Date.Date == date.Date).OrderBy(b => b.Start).ToList();
            foreach (var b in bookingsForDay)
            {
                if (!(end <= b.Start || start >= b.End))
                {
                    // Löytyi päällekkäisyys, etsitään seuraava vapaa aikaväli samana päivänä
                    TimeSpan duration = end - start;
                    TimeSpan candidate = start;
                    foreach (var ex in bookingsForDay)
                    {
                        if (candidate + duration <= ex.Start)
                        {
                            Console.WriteLine($"Aikaväli on varattu. Seuraava mahdollinen aikaväli: {date:yyyy-MM-dd} {candidate:hh\\:mm}-{(candidate + duration):hh\\:mm}");
                            return;
                        }
                        if (candidate < ex.End) candidate = ex.End;
                    }

                    if (candidate + duration <= close)
                    {
                        Console.WriteLine($"Aikaväli on varattu. Seuraava mahdollinen aikaväli: {date:yyyy-MM-dd} {candidate:hh\\:mm}-{(candidate + duration):hh\\:mm}");
                    }
                    else
                    {
                        Console.WriteLine("Aikaväli on varattu eikä saman päivän aikana ole vapaita aikoja.");
                    }
                    return;
                }
            }

            var uusi = new Booking(date, start, end);
            VaratutAika.Add(uusi);
            Console.WriteLine($"Aika lisätty varattuihin: {uusi}");
        }

        static void PeruAika()
        {
            if (VaratutAika.Count == 0)
            {
                Console.WriteLine("\nEi varattuja aikoja peruttavaksi.");
                return;
            }

            Console.WriteLine("\n=== Peru aika ===");
            Console.WriteLine("Kirjoita B palataksesi edelliseen valikkoon, X lopettaaksesi.");
            Console.WriteLine();

            var sorted = VaratutAika.OrderBy(b => b.Date).ThenBy(b => b.Start).ToList();
            for (int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sorted[i]}");
            }

            Console.WriteLine("B. Edellinen valikko");
            Console.WriteLine("X. Lopeta");
            Console.Write("\nValitse peruttava aika: ");

            string valinta = Console.ReadLine();

            if (valinta.Equals("B", StringComparison.OrdinalIgnoreCase)) return;
            if (valinta.Equals("X", StringComparison.OrdinalIgnoreCase)) { Console.WriteLine("Ohjelma päätetään."); Environment.Exit(0); }

            if (int.TryParse(valinta, out int index) && index > 0 && index <= sorted.Count)
            {
                var peruttava = sorted[index - 1];
                VaratutAika.Remove(peruttava);
                Console.WriteLine($"Aika peruttu: {peruttava}");
            }
            else
            {
                Console.WriteLine("Virheellinen valinta.");
            }
        }
    }
}

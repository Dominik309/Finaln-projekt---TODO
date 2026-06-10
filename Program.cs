Console.Clear();
List<string> ukoly = new List<string>();
List<bool> splnene = new List<bool>(); 

Console.WriteLine("ŮKOLNÍČEK :D");
Console.WriteLine("Napiš help aby ti to vypsalo příkazy.");

while (true)
{
    Console.Write("Zadej příkaz: ");
    string prikaz = Console.ReadLine();
    prikaz = prikaz.Trim().ToLower();

    if (prikaz == "konec")
    {
        Console.WriteLine("Aplikace se ukončuje.");
        break;
    }
    else if (prikaz == "help")
    {
        Console.WriteLine("   PŘÍKAZY   ");
        Console.WriteLine("pridat  - Vytvoří nový úkol");
        Console.WriteLine("vypsat  - Zobrazí všechny tvoje úkoly a jejich stav");
        Console.WriteLine("done    - Označí úkol jako splněný");
        Console.WriteLine("smazat  - Smaže úkol ze seznamu");
        Console.WriteLine("help    - Ukáže nápovědu");
        Console.WriteLine("konec   - Zavře program");
    }

    else if (prikaz == "pridat")
    {
        Console.Write("Napiš text úkolu: ");
        string novyUkol = Console.ReadLine();
        ukoly.Add(novyUkol);
        splnene.Add(false); 
        Console.WriteLine("Úkol byl úspěšně přidán!");
    }

    else if (prikaz == "vypsat")
    {
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš žádné úkoly.");
        }
        else
        {
            Console.WriteLine("   MOJE ÚKOLY   ");
            for (int i = 0; i < ukoly.Count; i++)
            {
                if (splnene[i] == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i]}");
                else
                    Console.WriteLine($"{i + 1}. [       ] {ukoly[i]}");
            }
        }
    }

    else if (prikaz == "done")
    {
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš žádné úkoly.");
        }
        else
        {
            Console.WriteLine("   MOJE ÚKOLY   ");
            for (int i = 0; i < ukoly.Count; i++)
            {
                if (splnene[i] == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i]}");
                else
                    Console.WriteLine($"{i + 1}. [NESPLNĚNO] {ukoly[i]}");
            }

            Console.Write("Zadej číslo úkolu který chceš označit jako splněný: ");
            int cislo = int.Parse(Console.ReadLine());

            if (cislo < 1 || cislo > ukoly.Count)
                Console.WriteLine("Tento úkol neexistuje.");
            else
            {
                splnene[cislo - 1] = true;
                Console.WriteLine("Úkol je splňený splněný.");
            }
        }
    }

    else if (prikaz == "smazat")
    {
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš žádné úkoly.");
        }
        else
        {
            Console.WriteLine("   MOJE ÚKOLY   ");
            for (int i = 0; i < ukoly.Count; i++)
            {
                if (splnene[i] == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i]}");
                else
                    Console.WriteLine($"{i + 1}. [       ] {ukoly[i]}");
            }

            Console.Write("Zadej číslo úkolu který chceš smazat: ");
            int cislo = int.Parse(Console.ReadLine());

            if (cislo < 1 || cislo > ukoly.Count)
                Console.WriteLine("Takový úkol neexistuje.");
            else
            {
                ukoly.RemoveAt(cislo - 1);
                splnene.RemoveAt(cislo - 1);
                Console.WriteLine("Úkol byl smazán.");
            }
        }
    }

    else
    {
        Console.WriteLine("Špatně ani příkazy psát neumíš. Napiš: help, pridat, vypsat, smazat, done nebo konec");
    }
}
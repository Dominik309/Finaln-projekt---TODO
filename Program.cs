Console.Clear();
List<TaskItem> ukoly = UkladaniUkolu.Nacist();
int dalsiId = 1;
if (ukoly.Count > 0)
    dalsiId = ukoly[ukoly.Count - 1].Id + 1;

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

        if (novyUkol == "")
        {
            Console.WriteLine("Název úkolu nesmí být prázdný.");
        }
        else
        {
            Console.Write("Napiš popis úkolu: ");
            string popis = Console.ReadLine();

            Console.Write("Priorita (1 = nizka, 2 = stredni, 3 = vysoka): ");
            string prioritaVstup = Console.ReadLine();

            if (!int.TryParse(prioritaVstup, out int priorita))
            {
                Console.WriteLine("Chyba: priorita musí být číslo!");
            }
            else if (priorita < 1 || priorita > 3)
            {
                Console.WriteLine("Chyba: priorita musí být 1, 2 nebo 3!");
            }
            else
            {
                ukoly.Add(new TaskItem(dalsiId, novyUkol, popis, priorita));
                dalsiId++;
                UkladaniUkolu.Ulozit(ukoly);
                Console.WriteLine("Úkol byl úspěšně přidán!");
            }
        }
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
                if (ukoly[i].Hotovy == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
                else
                    Console.WriteLine($"{i + 1}. [NESPLNĚNO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
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
                if (ukoly[i].Hotovy == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
                else
                    Console.WriteLine($"{i + 1}. [NESPLNĚNO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
            }

            Console.Write("Zadej číslo úkolu který chceš označit jako splněný: ");
            string vstup = Console.ReadLine();

            if (!int.TryParse(vstup, out int cislo))
            {
                Console.WriteLine("Musíš zadat číslo.");
            }
            else if (cislo < 1 || cislo > ukoly.Count)
            {
                Console.WriteLine("Tento úkol neexistuje.");
            }
            else if (ukoly[cislo - 1].Hotovy == true)
            {
                Console.WriteLine("Úkol už je splněný.");
            }
            else
            {
                ukoly[cislo - 1].Hotovy = true;
                UkladaniUkolu.Ulozit(ukoly);
                Console.WriteLine("Úkol je splněný.");
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
                if (ukoly[i].Hotovy == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
                else
                    Console.WriteLine($"{i + 1}. [       ] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
            }

            Console.Write("Zadej číslo úkolu který chceš smazat: ");
            string vstup = Console.ReadLine();

            if (!int.TryParse(vstup, out int cislo))
            {
                Console.WriteLine("Musíš zadat číslo.");
            }
            else if (cislo < 1 || cislo > ukoly.Count)
            {
                Console.WriteLine("Tento úkol neexistuje.");
            }
            else
            {
                ukoly.RemoveAt(cislo - 1);
                UkladaniUkolu.Ulozit(ukoly);
                Console.WriteLine("Úkol byl smazán.");
            }
        }
    }
    else
    {
        Console.WriteLine("Špatně ani příkazy psát neumíš. Napiš: help, pridat, vypsat, smazat, done nebo konec");
    }
}
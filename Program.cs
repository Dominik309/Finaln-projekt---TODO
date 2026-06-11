Console.Clear();

// nacteme ukoly ze souboru - pokud soubor neexistuje vrati se prazdny seznam
List<TaskItem> ukoly = UkladaniUkolu.Nacist();

// dalsiId je cislo ktere dostane dalsi novy ukol
// pokud uz nejake ukoly mame, vezmeme id posledniho a pridame 1
// pokud zadne ukoly nemame, zacneme od 1
int dalsiId = 1;
if (ukoly.Count > 0)
    dalsiId = ukoly[ukoly.Count - 1].Id + 1;

Console.WriteLine("ŮKOLNÍČEK :D");
Console.WriteLine("Napiš help aby ti to vypsalo příkazy.");

// hlavni smycka programu - bezi porad dokud uzivatel nenapise konec
while (true)
{
    Console.Write("Zadej příkaz: ");
    string prikaz = Console.ReadLine();
    prikaz = prikaz.Trim().ToLower(); // orizne mezery a prevede na mala pismena

    if (prikaz == "konec")
    {
        Console.WriteLine("Aplikace se ukončuje.");
        break; // ukonci smycku a tim i program
    }
    else if (prikaz == "help")
    {
        // vypise vsechny prikazy ktere program umi
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
            Console.WriteLine("Název úkolu nesmí být prázdný!");
        }
        else
        {
            Console.Write("Napiš popis úkolu: ");
            string popis = Console.ReadLine();
            
            Console.Write("Priorita (1 = nizka, 2 = stredni, 3 = vysoka): ");
            string prioritaVstup = Console.ReadLine();

            // int.TryParse zkusi prevest text na cislo
            // pokud se to nepovede (uzivatel napsal pismeno), vrati false
            if (!int.TryParse(prioritaVstup, out int priorita))
            {
                Console.WriteLine("Chyba: priorita musí být číslo!");
            }
            else if (priorita < 1 || priorita > 3)
            {
                Console.WriteLine("Priorita musí být 1, 2 nebo 3!");
            }
            else
            {
                // vse je ok - pridame novy ukol do seznamu
                ukoly.Add(new TaskItem(dalsiId, novyUkol, popis, priorita));
                dalsiId++; // zvysime id pro pristi ukol
                UkladaniUkolu.Ulozit(ukoly); // ulozime do souboru
                Console.WriteLine("Úkol byl úspěšně přidán!");
            }
        }
    }

    else if (prikaz == "vypsat")
    {
        // zkontrolujeme jestli vubec nejake ukoly mame
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš žádné úkoly.");
        }
        else
        {
            Console.WriteLine("   MOJE ÚKOLY   ");

            // projdeme vsechny ukoly a vypiseme je
            for (int i = 0; i < ukoly.Count; i++)
            {
                // podle toho jestli je ukol hotovy vypiseme jiny stav
                if (ukoly[i].Hotovy == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
                else
                    Console.WriteLine($"{i + 1}. [NESPLNĚNO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
            }
        }
    }

    else if (prikaz == "done")
    {
        // zkontrolujeme jestli vubec nejake ukoly mame
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš žádné úkoly.");
        }
        else
        {
            // nejdrive vypiseme ukoly at uzivatel vi co zadat
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

            // kontrola - uzivatel musel zadat cislo
            if (!int.TryParse(vstup, out int cislo))
            {
                Console.WriteLine("Chyba: zadej číslo!");
            }
            // kontrola - cislo musi existovat v seznamu
            else if (cislo < 1 || cislo > ukoly.Count)
            {
                Console.WriteLine("Chyba: tento úkol neexistuje.");
            }
            // kontrola - ukol uz neni hotovy
            else if (ukoly[cislo - 1].Hotovy == true)
            {
                Console.WriteLine("Chyba: úkol už je splněný.");
            }
            else
            {
                // oznacime ukol jako hotovy a ulozime
                ukoly[cislo - 1].Hotovy = true;
                UkladaniUkolu.Ulozit(ukoly);
                Console.WriteLine("Úkol je splněný.");
            }
        }
    }

    else if (prikaz == "smazat")
    {
        // zkontrolujeme jestli vubec nejake ukoly mame
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš žádné úkoly.");
        }
        else
        {
            // nejdrive vypiseme ukoly at uzivatel vi co zadat
            Console.WriteLine("   MOJE ÚKOLY   ");
            for (int i = 0; i < ukoly.Count; i++)
            {
                if (ukoly[i].Hotovy == true)
                    Console.WriteLine($"{i + 1}. [HOTOVO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
                else
                    Console.WriteLine($"{i + 1}. [NESPLNĚNO] {ukoly[i].Nazev} (priorita: {ukoly[i].Priorita})");
            }

            Console.Write("Zadej číslo úkolu který chceš smazat: ");
            string vstup = Console.ReadLine();

            // kontrola - uzivatel musel zadat cislo
            if (!int.TryParse(vstup, out int cislo))
            {
                Console.WriteLine("Chyba: zadej číslo!");
            }
            // kontrola - cislo musi existovat v seznamu
            else if (cislo < 1 || cislo > ukoly.Count)
            {
                Console.WriteLine("Chyba: tento úkol neexistuje.");
            }
            else
            {
                // odstranime ukol ze seznamu a ulozime
                ukoly.RemoveAt(cislo - 1); // cislo - 1 protoze seznam zacina od 0 ale my zobrazujeme od 1
                UkladaniUkolu.Ulozit(ukoly);
                Console.WriteLine("Úkol byl smazán.");
            }
        }
    }

    else
    {
        // uzivatel zadal neco co program nezna
        Console.WriteLine("Špatně ani příkazy psát neumíš. Napiš: help, pridat, vypsat, smazat, done nebo konec");
    }
}
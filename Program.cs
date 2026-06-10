Console.Clear();
List<string> ukoly = new List<string>();

Console.WriteLine("ŮKOLNÍČEK :D");
Console.WriteLine("Aby ti to vypsalo příkazy napiš help.");

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
        Console.WriteLine("--- PŘÍKAZY ---");
        Console.WriteLine("  pridat    - Přidat nový úkol");
        Console.WriteLine("  vypsat    - Vypsat všechny úkoly");
        Console.WriteLine("  done      - Označit úkol jako hotový");
        Console.WriteLine("  smazat    - Smazat úkol podle ID");
        Console.WriteLine("  help      - Ukázat tuto nápovědu");
        Console.WriteLine("  konec     - Ukončit program");
    }
 
    else if (prikaz == "pridat")
    {
        Console.Write("Napiš text úkolu: ");
        string novyUkol = Console.ReadLine();
        ukoly.Add(novyUkol); 
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
            Console.WriteLine("--- MOJE ÚKOLY ---");

            for (int i = 0; i < ukoly.Count; i++)
            {

                Console.WriteLine($"{i + 1}. {ukoly[i]}");
            }
        }
    }
    
    else if (prikaz == "done")
    {
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš tam nic co bys mohl označit.");
            continue;
        }
        Console.Write("Napiš ID úkolu, který je hotový: ");
        string vstupCislo = Console.ReadLine() ?? "";
        int.TryParse(vstupCislo, out int id);

        if (id >= 1 && id <= ukoly.Count)
        {
            ukoly[id - 1].IsCompleted = true;
            Console.WriteLine("Úkol byl označen jako hotový!");
        }
        else
        {
            Console.WriteLine($"Chyba: Úkol s ID '{vstupCislo}' neexistuje!");
        }
    }
    
    else if (prikaz == "smazat")
    {
        if (ukoly.Count == 0)
        {
            Console.WriteLine("Nemáš co smazat je to prázdný.");
            continue;
        }
        Console.Write("Napiš číslo úkolu, který chceš smazat: ");
        string vstupCislo = Console.ReadLine();
        
        int.TryParse(vstupCislo, out int cislo);
        
        if (cislo >= 1 && cislo <= ukoly.Count)
        {
            ukoly.RemoveAt(cislo - 1);
            Console.WriteLine("Úkol smazán.");
        }
        else
        {
            Console.WriteLine("Neplatné číslo úkolu.");
        }
    }
    
    else
    {
        Console.WriteLine("Špatně ani příkazy psát neumíš. Napiš: pridat, vypsat nebo konec");
    }
}

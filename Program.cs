Console.Clear();
List<string> ukoly = new List<string>();

Console.WriteLine("ŮKOLNÍČEK :D");
Console.WriteLine("Příkazy: pridat | vypsat | konec");

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
    
    else
    {
        Console.WriteLine("Špatně ani příkazy psát neumíš. Napiš: pridat, vypsat nebo konec");
    }
}
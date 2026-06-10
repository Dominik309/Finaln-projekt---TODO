using System.Text.Json;

class UkladaniUkolu
{
    private static string soubor = "ukoly.json";

    // nacte ukoly ze souboru, pokud soubor neexistuje vrati prazdny seznam
    public static List<TaskItem> Nacist()
    {
        if (!File.Exists(soubor))
            return new List<TaskItem>();

        string json = File.ReadAllText(soubor);
        return JsonSerializer.Deserialize<List<TaskItem>>(json);
    }

    // ulozi ukoly do souboru
    public static void Ulozit(List<TaskItem> ukoly)
    {
        string json = JsonSerializer.Serialize(ukoly);
        File.WriteAllText(soubor, json);
    }
}
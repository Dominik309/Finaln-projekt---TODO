
class TaskItem
{
    public string Nazev { get; set; }
    public string Popis { get; set; }
    public int Priorita { get; set; }   
    public bool Hotovy { get; set; }   

    public TaskItem(string nazev, string popis, int priorita)
    {
        Nazev = nazev;
        Popis = popis;
        Priorita = priorita;
        Hotovy = false; 
    }
}
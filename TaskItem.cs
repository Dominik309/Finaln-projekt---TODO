
class TaskItem
{
    public int Id { get; set; }
    public string Nazev { get; set; }
    public string Popis { get; set; }
    public int Priorita { get; set; }   
    public bool Hotovy { get; set; }   

    public TaskItem(int id, string nazev, string popis, int priorita)
    {
        Id = id;
        Nazev = nazev;
        Popis = popis;
        Priorita = priorita;
        Hotovy = false; 
    }
}
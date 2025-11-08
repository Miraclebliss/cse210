public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry()
    {
        _date = DateTime.Now. ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }
}
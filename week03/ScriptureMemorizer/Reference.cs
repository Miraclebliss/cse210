public class Reference  // Class to represent a scripture reference (book, chapter, verse(s))
{
    private string _book;  // Private field for book name (e.g., "John")
    private int _chapter;  // Private field for chapter number
    private int _verse;  // Private field for starting verse number
    private int _endVerse;  // Private field for ending verse number (same as verse for single verses)

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;  // Initialize book name
        _chapter = chapter;  // Initialize chapter number
        _verse = verse;  // Initialize verse number
        _endVerse = verse;  // Set end verse same as start verse for single verse
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;  // Initialize book name
        _chapter = chapter;  // Initialize chapter number
        _verse = startVerse;  // Initialize starting verse number
        _endVerse = endVerse;  // Initialize ending verse number
    }

    public string GetDisplayText()  // Method to format reference for display
    {
        if (_verse == _endVerse)  // Check if this is a single verse reference
        {
            return $"{_book} {_chapter}:{_verse}";  // Format as "Book Chapter:Verse"
        }
        else  // This is a verse range
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";  // Format as "Book Chapter:StartVerse-EndVerse"
        }
    }
}
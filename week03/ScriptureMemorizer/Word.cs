public class Word  // Class to represent an individual word in the scripture
{
    private string _text;  // Private field to store the actual word text
    private bool _isHidden;  // Private field to track if word is hidden

    public Word(string text)  // Constructor that takes the word text
    {
        _text = text;  // Initialize the word text
        _isHidden = false;  // Initialize as not hidden by default
    }

    public void Hide()  // Method to hide the word
    {
        _isHidden = true;  // Set hidden flag to true
    }

    public void Show()  // Method to show the word (make it visible)
    {
        _isHidden = false;  // Set hidden flag to false
    }

    public bool IsHidden()  // Method to check if word is hidden
    {
        return _isHidden;  // Return current hidden status
    }

    public string GetDisplayText()  // Method to get display text (either word or underscores)
    {
        if (_isHidden)  // Check if word should be hidden
        {
            return new string('_', _text.Length);  // Return underscores matching word length
        }
        else  // Word should be visible
        {
            return _text;  // Return the actual word text
        }
    }
}
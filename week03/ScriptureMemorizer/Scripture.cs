using System;  // Import System namespace for basic functionality
using System.Collections.Generic;  // Import for List collection
using System.Linq;  // Import for LINQ methods like Where, All, Count

public class Scripture  // Class to represent a complete scripture with reference and words
{
    private Reference _reference;  // Private field to store the scripture reference
    private List<Word> _words;  // Private field to store list of Word objects
    private Random _random;  // Private field for random number generation

    public Scripture(Reference reference, string text)  // Constructor that takes reference and text
    {
        _reference = reference;  // Initialize the reference field
        _words = new List<Word>();  // Create new empty list for words
        _random = new Random();  // Create new Random instance for random operations
        
        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');  // Split text by spaces to get individual words
        foreach (string wordText in wordArray)  // Loop through each word in the array
        {
            _words.Add(new Word(wordText));  // Create new Word object and add to list
        }
    }

    public void HideRandomWords(int numberToHide)  // Method to hide specified number of random words
    {
        // Get only the words that are not already hidden using LINQ
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        
        // If there are fewer visible words than requested to hide, hide all remaining
        numberToHide = Math.Min(numberToHide, visibleWords.Count);  // Ensure we don't try to hide more than available
        
        for (int i = 0; i < numberToHide; i++)  // Loop for the number of words to hide
        {
            if (visibleWords.Count == 0) break;  // Exit loop if no more visible words
            
            int randomIndex = _random.Next(visibleWords.Count);  // Get random index from visible words
            visibleWords[randomIndex].Hide();  // Call Hide method on the selected word
            visibleWords.RemoveAt(randomIndex);  // Remove hidden word from visible words list
        }
    }

    public string GetDisplayText()  // Method to get the complete display text of scripture
    {
        string displayText = _reference.GetDisplayText() + " ";  // Start with reference text
        
        foreach (Word word in _words)  // Loop through all words in the scripture
        {
            displayText += word.GetDisplayText() + " ";  // Append each word's display text
        }
        
        return displayText.Trim();  // Return the complete text with trailing space removed
    }

    public bool IsCompletelyHidden()  // Method to check if all words are hidden
    {
        return _words.All(word => word.IsHidden());  // Use LINQ to check if all words are hidden
    }

    public int GetTotalWordCount()  // Method to get total number of words in scripture
    {
        return _words.Count;  // Return count of all words in the list
    }

    public int GetHiddenWordCount()  // Method to get count of hidden words
    {
        return _words.Count(word => word.IsHidden());  // Use LINQ to count hidden words
    }
}
using System;  // Import System namespace
using System.Collections.Generic;  // Import for List collection
using System.IO;  // Import for file operations

public class ScriptureMemorizer  // Class to manage the memorization process and user interface
{
    private List<Scripture> _scriptures;  // Private field to store library of scriptures
    private Random _random;  // Private field for random number generation

    public ScriptureMemorizer()  // Constructor
    {
        _scriptures = new List<Scripture>();  // Initialize empty scripture list
        _random = new Random();  // Initialize Random instance
        InitializeScriptures();  // Call method to populate scriptures
    }

    private void InitializeScriptures()  // Method to load scriptures into memory
    {
        // Pre-loaded scriptures - add some default scriptures
        _scriptures.Add(new Scripture(  // Add John 3:16
            new Reference("John", 3, 16),  // Create reference for John 3:16
            "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."  // Scripture text
        ));

        _scriptures.Add(new Scripture(  // Add Proverbs 3:5-6
            new Reference("Proverbs", 3, 5, 6),  // Create reference for verse range
            "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him and he will make your paths straight."  // Scripture text
        ));

        _scriptures.Add(new Scripture(  // Add Philippians 4:13
            new Reference("Philippians", 4, 13),  // Create reference for Philippians 4:13
            "I can do all this through him who gives me strength."  // Scripture text
        ));

        _scriptures.Add(new Scripture(  // Add Psalm 23:1
            new Reference("Psalm", 23, 1),  // Create reference for Psalm 23:1
            "The Lord is my shepherd I shall not want"  // Scripture text
        ));

        // Try to load additional scriptures from file
        LoadScripturesFromFile();  // Call method to load from external file
    }

    private void LoadScripturesFromFile()  // Method to load scriptures from text file
    {
        try  // Try block to handle file errors gracefully
        {
            if (File.Exists("scriptures.txt"))  // Check if scriptures file exists
            {
                string[] lines = File.ReadAllLines("scriptures.txt");  // Read all lines from file
                foreach (string line in lines)  // Loop through each line in file
                {
                    if (!string.IsNullOrWhiteSpace(line))  // Skip empty lines
                    {
                        string[] parts = line.Split('|');  // Split line by pipe character
                        if (parts.Length >= 4)  // Check if line has enough parts
                        {
                            string book = parts[0];  // First part is book name
                            int chapter = int.Parse(parts[1]);  // Second part is chapter number
                            
                            if (parts[2].Contains("-"))  // Check if verse is a range
                            {
                                string[] verseParts = parts[2].Split('-');  // Split verse range
                                int startVerse = int.Parse(verseParts[0]);  // Get start verse
                                int endVerse = int.Parse(verseParts[1]);  // Get end verse
                                string text = parts[3];  // Fourth part is scripture text
                                
                                _scriptures.Add(new Scripture(  // Add scripture with verse range
                                    new Reference(book, chapter, startVerse, endVerse), text));
                            }
                            else  // Single verse
                            {
                                int verse = int.Parse(parts[2]);  // Third part is verse number
                                string text = parts[3];  // Fourth part is scripture text
                                
                                _scriptures.Add(new Scripture(  // Add scripture with single verse
                                    new Reference(book, chapter, verse), text));
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)  // Catch any exceptions during file loading
        {
            Console.WriteLine($"Note: Could not load scriptures from file: {ex.Message}");  // Show error message
        }
    }

    public void Run()  // Main method to run the memorizer application
    {
        Console.Clear();  // Clear console screen
        Console.WriteLine("Welcome to Scripture Memorizer!");  // Display welcome message
        Console.WriteLine();  // Empty line for spacing

        // Let user choose difficulty
        int difficulty = ChooseDifficulty();  // Call method to get difficulty level
        int wordsToHide = difficulty == 1 ? 1 : (difficulty == 2 ? 2 : 3);  // Set words to hide based on difficulty

        // Let user choose or get random scripture
        Scripture scripture = ChooseScripture();  // Call method to select scripture

        MemorizeScripture(scripture, wordsToHide);  // Start memorization process with selected scripture
    }

    private int ChooseDifficulty()  // Method to let user choose difficulty level
    {
        Console.WriteLine("Choose difficulty level:");  // Display difficulty options
        Console.WriteLine("1. Easy (1 word hidden per round)");  // Easy option
        Console.WriteLine("2. Medium (2 words hidden per round)");  // Medium option
        Console.WriteLine("3. Hard (3 words hidden per round)");  // Hard option
        Console.Write("Enter choice (1-3): ");  // Prompt for input
        
        string input = Console.ReadLine();  // Read user input
        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)  // Validate input
        {
            return choice;  // Return valid choice
        }
        return 2;  // Default to medium if invalid input
    }

    private Scripture ChooseScripture()  // Method to let user choose scripture
    {
        Console.WriteLine("\nChoose a scripture:");  // Display scripture choices header
        for (int i = 0; i < _scriptures.Count; i++)  // Loop through all scriptures
        {
            // Display truncated scripture text with index number
            Console.WriteLine($"{i + 1}. {_scriptures[i].GetDisplayText().Substring(0, Math.Min(50, _scriptures[i].GetDisplayText().Length))}...");
        }
        Console.WriteLine($"{_scriptures.Count + 1}. Random scripture");  // Add random option
        Console.Write($"Enter choice (1-{_scriptures.Count + 1}): ");  // Prompt for input

        string input = Console.ReadLine();  // Read user input
        if (int.TryParse(input, out int choice))  // Try to parse input as integer
        {
            if (choice >= 1 && choice <= _scriptures.Count)  // Check if choice is valid scripture index
            {
                return _scriptures[choice - 1];  // Return selected scripture (adjust for 0-based index)
            }
            else if (choice == _scriptures.Count + 1)  // Check if user chose random
            {
                return _scriptures[_random.Next(_scriptures.Count)];  // Return random scripture
            }
        }
        
        // Default to random if invalid input
        return _scriptures[_random.Next(_scriptures.Count)];  // Return random scripture
    }

    private void MemorizeScripture(Scripture scripture, int wordsToHide)  // Main memorization loop
    {
        while (true)  // Infinite loop until break condition
        {
            Console.Clear();  // Clear console for fresh display
            // Show progress information
            Console.WriteLine($"Progress: {scripture.GetHiddenWordCount()}/{scripture.GetTotalWordCount()} words hidden");
            Console.WriteLine();  // Empty line for spacing
            Console.WriteLine(scripture.GetDisplayText());  // Display the scripture text
            Console.WriteLine();  // Empty line for spacing

            if (scripture.IsCompletelyHidden())  // Check if all words are hidden
            {
                Console.WriteLine("All words are hidden! Well done!");  // Success message
                Console.WriteLine("Press any key to continue...");  // Prompt to continue
                Console.ReadKey();  // Wait for key press
                break;  // Exit the loop
            }

            // Prompt user for action
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string input = Console.ReadLine();  // Read user input

            if (input?.ToLower() == "quit")  // Check if user wants to quit
            {
                break;  // Exit the loop
            }

            scripture.HideRandomWords(wordsToHide);  // Hide more words and continue
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static bool WordPattern(string pattern, string s)
    {
        if (pattern == null)
            throw new ArgumentNullException(nameof(pattern), "Pattern cannot be null.");
        if (s == null)
            throw new ArgumentNullException(nameof(s), "Input string cannot be null.");

        string[] words = s.Split(' ');
        if (pattern.Length != words.Length)
            return false;

        Dictionary<char, string> charToWord = new Dictionary<char, string>();
        Dictionary<string, char> wordToChar = new Dictionary<string, char>();

        for (int i = 0; i < pattern.Length; i++)
        {
            char c = pattern[i];
            string word = words[i];

            if (charToWord.ContainsKey(c))
            {
                if (charToWord[c] != word)
                    return false;
            }
            else
            {
                charToWord[c] = word;
            }

            if (wordToChar.ContainsKey(word))
            {
                if (wordToChar[word] != c)
                    return false;
            }
            else
            {
                wordToChar[word] = c;
            }
        }

        return true;
    }

    public static void Main()
    {
        var comparison = new (string pattern, string s)[]
        {
            ("abba", "dog cat cat dog"),
            ("abba", "dog cat cat fish"),
            ("aaaa", "dog cat cat dog"),
        };

        foreach (var (pattern, s) in comparison)
        {
            try
            {
                Console.WriteLine(WordPattern(pattern, s));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
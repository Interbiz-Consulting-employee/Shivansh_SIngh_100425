using System;
using System.Collections.Generic;

class Program
{
    static bool WordBreak(string s, List<string> dictionary)
    {
        if (s == null)
            throw new ArgumentNullException(nameof(s));
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        HashSet<string> wordSet = new HashSet<string>(dictionary);
        Dictionary<string, bool> memo = new Dictionary<string, bool>();

        return CanBreak(s, wordSet, memo);
    }

    static bool CanBreak(string s, HashSet<string> wordSet, Dictionary<string, bool> memo)
    {
        if (s.Length == 0)
            return true;

        if (memo.ContainsKey(s))
            return memo[s];

        for (int i = 1; i <= s.Length; i++)
        {
            string prefix = s.Substring(0, i);

            if (wordSet.Contains(prefix) && CanBreak(s.Substring(i), wordSet, memo))
            {
                memo[s] = true;
                return true;
            }
        }

        memo[s] = false;
        return false;
    }

    public static void Main()
    {
        Console.WriteLine(WordBreak("ilike", new List<string> { "i", "like", "gfg" }));
        Console.WriteLine(WordBreak("ilikegfg", new List<string> { "i", "like", "man", "india", "gfg" }));
        Console.WriteLine(WordBreak("ilikemangoes", new List<string> { "i", "like", "gfg" }));
    }
}
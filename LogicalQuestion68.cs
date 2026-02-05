using System;

class Program
{
    static bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
            return false;

        return Check(s1, s2, s3, 0, 0, 0);
    }

    static bool Check(string s1, string s2, string s3, int i, int j, int k)
    {
        if (k == s3.Length)
            return i == s1.Length && j == s2.Length;

        bool useS1 = i < s1.Length && s1[i] == s3[k] && Check(s1, s2, s3, i + 1, j, k + 1);
        bool useS2 = j < s2.Length && s2[j] == s3[k] && Check(s1, s2, s3, i, j + 1, k + 1);

        return useS1 || useS2;
    }

    static void Main()
    {
        Console.WriteLine(IsInterleave("AAB", "AAC", "AAAABC"));
        Console.WriteLine(IsInterleave("YX", "X", "XXY"));
    }
}


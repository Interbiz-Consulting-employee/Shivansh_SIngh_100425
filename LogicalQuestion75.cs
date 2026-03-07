using System;
using System.Collections.Generic;

class PalindromePartitioning
{
    public static (int, List<string>) ComputeMinimumCuts(string inputText)
    {
        int textLength = inputText.Length;

        bool[,] palindromeTable = new bool[textLength, textLength];

        for (int endIndex = 0; endIndex < textLength; endIndex++)
        {
            for (int startIndex = 0; startIndex <= endIndex; startIndex++)
            {
                if (inputText[startIndex] == inputText[endIndex] &&
                   (endIndex - startIndex <= 2 || palindromeTable[startIndex + 1, endIndex - 1]))
                {
                    palindromeTable[startIndex, endIndex] = true;
                }
            }
        }

        int[] minimumCutsAtIndex = new int[textLength];
        int[] partitionStartIndex = new int[textLength];

        for (int currentEnd = 0; currentEnd < textLength; currentEnd++)
        {
            if (palindromeTable[0, currentEnd])
            {
                minimumCutsAtIndex[currentEnd] = 0;
                partitionStartIndex[currentEnd] = -1;
            }
            else
            {
                minimumCutsAtIndex[currentEnd] = int.MaxValue;

                for (int previousEnd = 0; previousEnd < currentEnd; previousEnd++)
                {
                    if (palindromeTable[previousEnd + 1, currentEnd] &&
                        minimumCutsAtIndex[previousEnd] + 1 < minimumCutsAtIndex[currentEnd])
                    {
                        minimumCutsAtIndex[currentEnd] = minimumCutsAtIndex[previousEnd] + 1;
                        partitionStartIndex[currentEnd] = previousEnd;
                    }
                }
            }
        }

        List<string> finalPartition = new List<string>();
        int currentIndex = textLength - 1;

        while (currentIndex >= 0)
        {
            int previousIndex = partitionStartIndex[currentIndex];
            finalPartition.Insert(0, inputText.Substring(previousIndex + 1, currentIndex - previousIndex));
            currentIndex = previousIndex;
        }

        return (minimumCutsAtIndex[textLength - 1], finalPartition);
    }

    static void Main()
    {
        string inputText = "aab";

        var result = ComputeMinimumCuts(inputText);

        Console.WriteLine("Cuts = " + result.Item1);
        Console.WriteLine("Partition = [" + string.Join(", ", result.Item2) + "]");

        inputText = "racecar";

         result = ComputeMinimumCuts(inputText);

        Console.WriteLine("Cuts = " + result.Item1);
        Console.WriteLine("Partition = [" + string.Join(", ", result.Item2) + "]");

         inputText = "abccbc";

         result = ComputeMinimumCuts(inputText);

        Console.WriteLine("Cuts = " + result.Item1);
        Console.WriteLine("Partition = [" + string.Join(", ", result.Item2) + "]");
    }
}
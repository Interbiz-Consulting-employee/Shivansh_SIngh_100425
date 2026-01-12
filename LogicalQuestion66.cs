using System;

class Program
{
    static void Main()
    {
        char[] letters1 = { 'c', 'f', 'j' };
        char target1 = 'a';
        Console.WriteLine(NextGreatestLetter(letters1, target1)); // Output: c

        char[] letters2 = { 'c', 'f', 'j' };
        char target2 = 'c';
        Console.WriteLine(NextGreatestLetter(letters2, target2)); // Output: f

        char[] letters3 = { 'x', 'x', 'y', 'y' };
        char target3 = 'z';
        Console.WriteLine(NextGreatestLetter(letters3, target3)); // Output: x
    }

    public static char NextGreatestLetter(char[] letters, char target)
    {
        int left = 0;
        int right = letters.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (letters[mid] <= target)
            {
                left = mid + 1; 
            }
            else
            {
                right = mid - 1;            
            }
        }


        if (left < letters.Length)
            return letters[left];
        else
            return letters[0];
    }
}

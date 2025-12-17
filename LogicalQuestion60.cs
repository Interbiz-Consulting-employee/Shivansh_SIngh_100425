

namespace LogicalQuestion60
{
    internal class LogicalQuestion60
    {
        public static void Main()
        {
            string s1 = "leetcode";
            // Output: 'l'
            string s2 = "loveleetcode";
            // Output: 'v'
            string s3 = "aabb";
            //   Output: '\0'
            string s4 = "programming";
            // Output: 'p'
            string s5 = "aabbccddeff";
            // Output: 'e'

            Console.WriteLine("1st output :" + FirstNonRepeatingCharacter(s1));
            Console.WriteLine("2nd output :" + FirstNonRepeatingCharacter(s2));
            Console.WriteLine("3rd output :" + FirstNonRepeatingCharacter(s3));
            Console.WriteLine("4th output :" + FirstNonRepeatingCharacter(s4));
            Console.WriteLine("4th output :" + FirstNonRepeatingCharacter(s5));
        }
        public static char FirstNonRepeatingCharacter(string str)
        {
            char[] str2 = str.ToCharArray();
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (Array.IndexOf(str2, str2[i]) == Array.LastIndexOf(str2, str2[i]))
                    return str2[i];
            }
            return '\0';

        }
    }
}



using System.Globalization;

namespace LogicalQuestion60
{
    internal class LogicalQuestion60
    {
        public static void Main()
        {
            string str1 = "AAABBBBAA";
            int k1 = 2;
            string str2 = "ABABABAB";
            int k2 = 1;
            string str3 = "AAAABBBAAABBB";
            int k3 = 4;
            string str4 = "AAAAAAAAAA";
            int k4 = 3;

            Console.WriteLine("NumberFormatInfo of deletions for str1 " + MinimumNumberOfDeletion(str1, k1)); // output : 3 
            Console.WriteLine("NumberFormatInfo of deletions for str2 " + MinimumNumberOfDeletion(str2, k2)); // output : 0
            Console.WriteLine("NumberFormatInfo of deletions for str3 " + MinimumNumberOfDeletion(str3, k3)); // output : 0
            Console.WriteLine("NumberFormatInfo of deletions for str4 " + MinimumNumberOfDeletion(str4, k4)); // output : 7

        }
        public static int MinimumNumberOfDeletion(string str, int k)
        {
            int noOfDeletion = 0;
            int count = 1;
            char[] arr = str.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    count++;
                    if (count > k)
                    {
                        noOfDeletion++;
                    }
                }
                else
                {
                    count = 1;
                }
            }
            return noOfDeletion;
        }
    }
}

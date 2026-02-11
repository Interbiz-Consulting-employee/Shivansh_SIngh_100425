using System;
using System.Collections.Generic;
using System.Text;
internal class logicalQuesion69
{
    static void Main(string[] args)
        {
            string[] str = { "flower", "flow", "flight" };

            Console.WriteLine(LongestCommonPrefix(str));

            string[] str1 = { "dog", "racecar", "car" };

            Console.WriteLine(LongestCommonPrefix(str1));

            string[] str2 = { };

            Console.WriteLine(LongestCommonPrefix(str2));

        }
        public static string LongestCommonPrefix(string[] str)
        {
            if (str == null || str.Length == 0)
                return "Empty array";

            string prefix = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                while (!str[i].StartsWith(prefix))
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);

                    if (prefix == "")
                        return "No Common Prefix";
                }
            }

        return prefix;
   }
}

using System;
using System.Collections.Generic;

namespace PNC_Console.PersonalNumberLibrary
{
    public static class Extensions
    {
        public static string RemoveWhiteSpaceToLower(this string str)
        {
            var newName = string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            return newName.ToLower();
        }

        public static void PrintAdditionSequence(this IEnumerable<int> enumerable)
        {
            var printStr = string.Empty;

            foreach(var value in enumerable)
            {
                printStr = printStr + " + " + $"{value}";
            }

            printStr = printStr.TrimStart('+');

            Console.WriteLine(printStr);
        }
    }
}

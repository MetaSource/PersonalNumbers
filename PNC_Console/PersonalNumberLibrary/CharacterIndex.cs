using System;
using System.Collections.Generic;
using System.Linq;

namespace PNC_Console.PersonalNumberLibrary
{
    public static class CharacterIndex
    {
        public static Dictionary<char, int> Values = new Dictionary<char, int> {
                            {'a', 1}, {'j', 1}, {'s', 1},
                            {'b', 2}, {'k', 2}, {'t', 2},
                            {'c', 3}, {'l', 3}, {'u', 3},
                            {'d', 4}, {'m', 4}, {'v', 4},
                            {'e', 5}, {'n', 5}, {'w', 5},
                            {'f', 6}, {'o', 6}, {'x', 6},
                            {'g', 7}, {'p', 7}, {'y', 7},
                            {'h', 8}, {'q', 8}, {'z', 8},
                            {'i', 9}, {'r', 9},
                        };

        public static char[] Vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };


        public static bool IsVowel(char letter)
        {
            return (Vowels.Contains(letter));
        }

        public static int[] ExtactVowelValues(string word)
        {
            var convertedValues = new List<int> { };

            foreach(char character in word)
            {
                if (IsVowel(character))
                {
                    convertedValues.Add(Values[character]);
                }
            }

            return convertedValues.ToArray();
        }
           
    }
}

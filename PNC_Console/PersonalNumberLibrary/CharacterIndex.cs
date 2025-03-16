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

        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsVowelY(int index, string word)
        {
            return false; 
        }

        /// <summary>
        /// TODO 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsVowelW(int index, string word)
        {
            return false; 
        }

        /// <summary>
        /// will take a word and convert its vowles into the corresponding number array 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static List<int> ExtactVowelValues(string word)
        {
            var convertedValues = new List<int> { };

            foreach(char character in word)
            {
                if (IsVowel(character))
                {
                    convertedValues.Add(Values[character]);
                }
            }

            if (IsYVowel(word))
            {
                convertedValues.Add(Values['y']);
            }

            if (IsWVowel(word))
            {
                convertedValues.Add(Values['w']);
            }

            return convertedValues;
        }

        public static List<int> ExtractCosonantValues(string words)
        {
            var convertedValues = new List<int> { };

            
            //Edge cases

            
            return convertedValues;
        }

        private static bool IsWVowel(string name)
        {
            name = name.ToLower();

            // Find the first occurrence of 'w'
            int wIndex = name.IndexOf('w');

            if (wIndex == -1)
                return false; // No 'W' found in the name

            // 'W' is a vowel if preceded by 'D' or 'G'
            if (wIndex > 0 && (name[wIndex - 1] == 'd' || name[wIndex - 1] == 'g'))
            {
                Console.WriteLine("Determined W vowel");
                return true; // "W" is acting as a vowel
            }


            return false; // Otherwise, it's a consonant
        }

        public static bool  IsYVowel(string name)
        {
            name = name.ToLower();

            // Find positions of 'y' in the name
            int yIndex = name.IndexOf('y');

            return IsYVowel(yIndex, name);
        }

        public static bool IsYVowel(int yIndex, string name)
        {
            name = name.ToLower();

            if (yIndex == -1)
                return false; // No 'Y' found in the name

            // 'Y' is a consonant if it is at the start of the name
            if (yIndex == 0)
                return false;

            // Define vowels
            string vowels = "aeiou";

            // Check if 'Y' is surrounded by consonants (acts as a vowel)
            if ((yIndex > 0 && !vowels.Contains(name[yIndex - 1])) &&
                (yIndex < name.Length - 1 && !vowels.Contains(name[yIndex + 1])))
            {
                Console.WriteLine("determined Y vowel");
                return true;
            }

            return false;
        }

    }
}

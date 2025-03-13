﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PNC_Console
{

    class Program
    {
        static int Options()
        {
            Console.WriteLine("1 for personal number, 2 for birthyear, 3 for combined");
            var option = Console.ReadLine();
            return int.Parse(option);
        }

        static void Main(string[] args)
        {
            for (int i = 1900; i < 2026; i++)
            {
                Console.Write($"Year {i} ");
                var total = ReduceBirthYear(i);

                Console.WriteLine($"= {total}");
            }

            while (true)
            {
                var option = Options();
                switch ((option))
                {
                    case 1:
                        PersonalNumber();
                        break;
                    case 2:
                        Year();
                        break;
                    case 3:
                        Console.WriteLine("not available");
                        break;
                    default:
                        PersonalNumber();
                        break;
                }
                Console.WriteLine("Enter to restart (return)");

                Console.ReadLine();
            }
        }

        static void PersonalNumber()
        {
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();
            CalculatePersonalNumber(name);
        }

        static void Year()
        {
            Console.WriteLine("Enter Birth Year:");
            var yearString = Console.ReadLine();
            var year = int.Parse(yearString);
            var total = ReduceBirthYear(year);
            Console.WriteLine($"= {total}");
        }

        static void CalculatePersonalNumber(string name)
        {

            var index = new Dictionary<char, int> {
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

            var count = 0;
            var computation = string.Empty;
            var newName = string.Join("", name.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

            newName = newName.ToLower();
            Console.WriteLine(newName);
            foreach (var letter in newName)
            {

                //count the number total, then reduce
                var tocalculate = $"{letter} " + $"({index[letter]})" + " + ";
                computation = computation + tocalculate;
                count += index[letter];
            }
            Console.WriteLine(computation + " = " + count);

            Console.WriteLine("Personal number is: ");

            if (count > 78)
            {
                Console.WriteLine("reducing base number over 78");
                count = (ReduceBaseNumber(count));
            }
            var baseNum = count;

            var reduced = Reduce(count);

            Console.WriteLine(reduced);
            if (baseNum != reduced)
            {
                Console.WriteLine($"{ baseNum}/{reduced}");
            }

        }

        /// <summary>
        /// non recursive reduction of a number. 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int ReduceBaseNumber(int number)
        {
            var hundreds = number / 100;
            var tens = (number / 10) % 10;
            var ones = number % 10;

            return hundreds + ones + tens;
        }


        /// <summary>
        /// splits year into four digits then adds each digit 
        /// </summary>
        /// <param name="year"></param>
        public static int ReduceBirthYear(int year)
        {
            var thousands = year / 1000;
            var hundreds = (year / 100) % 10;
            var tens = (year / 10) % 10;
            var ones = year % 10;

            Console.WriteLine($"{thousands} + {hundreds} + {tens} + {ones}");

            return thousands + hundreds + tens + ones;
        }


        /// <summary>
        /// recursive reduction of a number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Reduce(int number)
        {
            var masterNumbers = new int[] { 11, 22, 33 };

            Console.WriteLine($"   reducing: {number}");

            if (masterNumbers.Contains(number))
            {
                return number;
            }

            if (number > 9)
            {
                var hundreds = number / 100;
                var tens = (number / 10) % 10;
                var ones = number % 10;

                var newNum = hundreds + ones + tens;

                return Reduce(newNum);
            }
            else
            {
                return number;
            }
        }

    }


}


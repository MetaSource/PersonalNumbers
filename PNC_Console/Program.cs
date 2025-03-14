using System;
using System.Collections.Generic;
using System.Linq;

namespace PNC_Console
{
    public static class MASTER_NUMBERS
    {
        public static int[] Values {  get { return new int[] { 11, 22, 33, 44 }; } }
    }

    public class LifeLessonNumber
    {
        public int BaseValue { get; set; }

        /// <summary>
        /// Value of life lesson number 
        /// </summary>
        public int Value { get; set; }

        public override string ToString()
        {
            if (Value != 22 || Value != 33 || Value != 11 || Value!= 44)
            {
                return $"{BaseValue}/{Value}";
            }
            return $"{Value}";
        }
    }

    class Program
    {
        static int Options()
        {
            Console.WriteLine("1 for personal number, 2 for birthyear, 3 for (Life Lesson) combined");
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
                        LifeLessonNumber();
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

        /// <summary>
        /// Option for Calculating life sesson number
        /// </summary>
        static void LifeLessonNumber()
        {
            Console.WriteLine("Enter Full Birthdate (mm/dd/yyyy):");
            var yearString = Console.ReadLine();

            // Console.WriteLine($"= {total}");
            CalculateLifeLessonNumber(yearString);
        }

        /// <summary>
        /// Caclulates life lesson number which is based on ONLY birth DATE
        /// </summary>
        /// <param name="fulldate"></param>
        static void CalculateLifeLessonNumber(string fulldate)
        {
            var separated = fulldate.Split("/");

            var fullstring = string.Empty;

            foreach (var section in separated)
            {
                fullstring = fullstring + section;
            }

            Console.WriteLine(fullstring);

            AddMonthDayYear(int.Parse(separated[0]), int.Parse(separated[1]), int.Parse(separated[2]));         
        }


        /// <summary>
        /// Will calcualte the total number for lifelesson calculations;
        /// only reducing after day, month and year have been totaled first 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        static void AddMonthDayYear(int month, int day, int year)
        {
            var yeartotal = ReduceBirthYear(year);
            var total = month + day + yeartotal;
            Console.WriteLine($"{month} + {day} + {yeartotal}({year}) = {total}");
            var reduced = Reduce(total);
            var str = $"{total}/{reduced}";
            Console.WriteLine($"You are a life lesson number {reduced} ({str})");
        }

        /// <summary>
        /// totals and arbirary set of numbers in an array 
        /// </summary>
        /// <param name="numbers"></param>
        static void AddNumbers(string[] numbers)
        {
            var total = 0;
            foreach (var section in numbers)
            {
                total = total + int.Parse(section);
            }
            Console.WriteLine(total);

        }

        static void AddHumbers(int[] numbers)
        {
            var total = 0;
            foreach (var section in numbers)
            {
                total = total + section;
            }
            Console.WriteLine(total);
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

            var total =  thousands + hundreds + tens + ones;
            Console.WriteLine($"{thousands} + {hundreds} + {tens} + {ones} = {total}" +
                $"" +
                $"");

            return total;
        }


        /// <summary>
        /// recursive reduction of a number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Reduce(int number)
        {
            var masterNumbers = new int[] { 11, 22, 33, 44 };

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


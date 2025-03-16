using System;
using System.Linq;

namespace PNC_Console.PersonalNumberLibrary
{
    public static class Reducer
    {
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

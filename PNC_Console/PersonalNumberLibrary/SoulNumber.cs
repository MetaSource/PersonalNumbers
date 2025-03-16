using System;
using System.Linq;

namespace PNC_Console.PersonalNumberLibrary
{
    public class SoulNumber : IPersonalNumber 
    {
        private readonly string name;

        public SoulNumber(string name)
        {
            this.name = name.RemoveWhiteSpaceToLower();
        }

        public string Description { get { return "The soul number comes from adding vowels " +
                    "in the full birth name"; } }

        public int Calculate()
        {
           
            var convertedValues = CharacterIndex.ExtactVowelValues(name);
            convertedValues.PrintAdditionSequence();
            //Add values then reduce
            var baseNumber = convertedValues.Sum();
            var reduced = Reducer.Reduce(baseNumber);

            if(baseNumber != reduced)
            {
                Console.WriteLine($"Soul Number {reduced} ({baseNumber}/{reduced})");
            }
            {
                Console.WriteLine($"Soul Number {reduced}");
            }

            return reduced;
        }

       

    }
}

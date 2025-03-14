using System;
namespace PNC_Console.PersonalNumberLibrary
{
    public class SoulNumber : IPersonalNumber 
    {
        private readonly string name;

        public SoulNumber(string name)
        {
            this.name = name;
        }

        public string Description { get { return "The soul number comes from adding vowels " +
                    "into the name using the character number index"; } }

        public void Calculate()
        {
            var convertedValues = CharacterIndex.ExtactVowelValues(name);

            //Add convertedValues
            //Reduce total 
        }

    }
}

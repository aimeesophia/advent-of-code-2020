using System;
using System.IO;
using Day07.Enums;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            var luggageRules = File.ReadAllLines("Data/Data.txt");
            var numberOfBagsThatCanEventuallyContainSpecificBagColour = LuggageProcessor.ProcessRules(luggageRules, "shiny gold", LuggageProcessorType.TotalNumberOfBagsThatCanEventuallyContainSpecificBagColour);

            Console.WriteLine("The number of bags that can eventually contain at least 1 shiny gold bag is: {0}", numberOfBagsThatCanEventuallyContainSpecificBagColour);

            var numberOfBagsWithinSpecificBagColour = LuggageProcessor.ProcessRules(luggageRules, "shiny gold", LuggageProcessorType.TotalNumberOfBagsContainedWithinSpecificBagColour);

            Console.WriteLine("The total number of bags contained within a shiny gold bag is: {0}", numberOfBagsWithinSpecificBagColour);
        }
    }
}

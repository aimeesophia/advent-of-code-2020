using System;
using System.IO;
using Day08.Enums;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootInstructions = File.ReadAllLines("Data/Data.txt");
            var evaluationResults = BootLoader.EvaluateInstructions(bootInstructions);

            Console.WriteLine("The accumulator was {0} when the program began to loop.", evaluationResults[EvaluatedInstructions.UnsuccessfulRunAccumulator]);
            Console.WriteLine("The accumulator was {0} when the program ran successfully.", evaluationResults[EvaluatedInstructions.SuccessfulRunAccumulator]);
        }
    }
}

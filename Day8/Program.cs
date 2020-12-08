using System;
using System.IO;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var bootInstructions = File.ReadAllLines("Data/Data.txt");

            Console.WriteLine("The accumulator was {0} when the program began to loop.", BootLoader.GetAccumulatorValueBeforeInfiniteLoop(bootInstructions));
        }
    }
}

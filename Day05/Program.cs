using System;
using System.IO;
using System.Linq;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardingPasses = File.ReadAllLines("Data/Data.txt");
            var decodedBoardingPasses = BoardingPassDecoder.Decode(boardingPasses);
            var highestSeatId = decodedBoardingPasses.Max();

            Console.WriteLine("The highest seat ID is: {0}", highestSeatId);

            var missingSeatId = BoardingPassDecoder.FindMissingSeatId(decodedBoardingPasses);

            Console.WriteLine("Your seat ID is: {0}", missingSeatId);
        }
    }
}

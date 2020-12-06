using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var customsAnswersInput = File.ReadAllLines("Data/Data.txt");
            var sumOfQuestionsAnsweredByEachGroup = CustomsCalculator.CalculateNumberOfQuestionsEveryoneAnswered(customsAnswersInput);

            Console.WriteLine("The sum of the number of questions answered by each group is: {0}", sumOfQuestionsAnsweredByEachGroup);
        }
    }
}

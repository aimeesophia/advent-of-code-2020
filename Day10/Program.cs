using System;
using System.IO;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var adapterStrings = File.ReadAllLines("Data/Data.txt");
            var adapterArray = new AdapterArray(adapterStrings);
            var result = adapterArray.GetJoltage();

            Console.WriteLine("The number of 1-jolt differences multiplied by the number of 3-jolt differences is: {0}", result);
            Console.WriteLine("The number of adapter arrangements is: {0}", adapterArray.GetNumberOfArrangements());
        }
    }
}

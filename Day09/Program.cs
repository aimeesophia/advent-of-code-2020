using System;
using System.IO;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberStrings = File.ReadAllLines("Data/Data.txt");
            var firstFailingNumber = XMASDecoder.Decode(numberStrings, 25);

            Console.WriteLine("The first failing number is: {0}", firstFailingNumber.Key);
            Console.WriteLine("The encryption weakness number is: {0}", firstFailingNumber.Value);
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace Day09
{
    public static class XMASDecoder
    {
        public static KeyValuePair<ulong, ulong> Decode(string[] numberStrings, int preamble)
        {
            var normalisedNumbers = NormaliseNumbers(numberStrings);
            var firstInvalidNumber = FindFirstInvalidNumber(normalisedNumbers, preamble);
            var numberRange = normalisedNumbers.GetRange(0, normalisedNumbers.IndexOf(firstInvalidNumber));
            var encryptionWeakness = FindEncryptionWeakness(numberRange, firstInvalidNumber);

            return new KeyValuePair<ulong, ulong>(firstInvalidNumber, encryptionWeakness);
        }

        private static ulong FindFirstInvalidNumber(List<ulong> numbers, int preamble)
        {
            for (int i = preamble; i < numbers.Count; i++)
            {
                var startIndex = i - preamble;
                var endIndex = preamble;
                var previousNumbers = numbers.GetRange(startIndex, endIndex);
                var currentNumber = numbers[i];
                var success = false;

                foreach (var previousNumber in previousNumbers)
                {
                    var remainder = currentNumber - previousNumber;

                    if (previousNumbers.Contains(remainder))
                    {
                        success = true;
                    }
                }

                if (success == false)
                {
                    return currentNumber;
                }
            }

            return 0;
        }

        private static ulong FindEncryptionWeakness(List<ulong> numbers, ulong invalidNumber)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var currentSection = numbers.GetRange(i, numbers.Count - i);
                var currentTotal = new ulong();

                foreach (var number in currentSection)
                {
                    currentTotal += number;

                    if (currentTotal == invalidNumber)
                    {
                        var thisPosition = currentSection.IndexOf(number);
                        var thisSection = currentSection.GetRange(0, thisPosition);
                        var lowestNumber = thisSection.Min();
                        var highestNumber = thisSection.Max();
                        var weaknessNumber = lowestNumber + highestNumber;
                        return weaknessNumber;
                    }
                }
            }

            return 0;
        }

        private static List<ulong> NormaliseNumbers(string[] numberStrings)
        {
            var normalisedNumbers = new List<ulong>();

            foreach (var numberString in numberStrings)
            {
                var normalisedNumber = ulong.Parse(numberString);
                normalisedNumbers.Add(normalisedNumber);
            }

            return normalisedNumbers;
        }
    }
}

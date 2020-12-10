using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    public class AdapterArray
    {
        public AdapterArray(string[] adapterStrings)
        {
            AdapterInts = adapterStrings.Select(int.Parse).ToList();
            var wallOutlet = 0;
            AdapterInts.Add(wallOutlet);
            var deviceJoltage = AdapterInts.Max() + 3;
            AdapterInts.Add(deviceJoltage);
        }

        private List<int> AdapterInts { get; set; }

        public int GetJoltage()
        {
            var orderedAdapterInts = AdapterInts.OrderBy(num => num).ToList();
            var oneJoltDifferences = 0;
            var threeJoltDifferences = 0;

            for (int i = 0; i < orderedAdapterInts.Count - 1; i++)
            {
                var difference = orderedAdapterInts[i + 1] - orderedAdapterInts[i];

                switch (difference)
                {
                    case 1:
                        oneJoltDifferences++;
                        break;
                    case 3:
                        threeJoltDifferences++;
                        break;
                }
            }

            return oneJoltDifferences * threeJoltDifferences;
        }
    }
}

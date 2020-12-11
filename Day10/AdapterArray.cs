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
            WallOutlet = wallOutlet;
            AdapterInts.Add(wallOutlet);
            var deviceJoltage = AdapterInts.Max() + 3;
            DeviceJoltage = deviceJoltage;
            AdapterInts.Add(deviceJoltage);
            AdapterInts = AdapterInts.OrderBy(num => num).ToList();
        }

        private List<int> AdapterInts { get; set; }

        private int DeviceJoltage { get; set; }

        private int WallOutlet { get; set; }

        public int GetJoltage()
        {
            var oneJoltDifferences = 0;
            var threeJoltDifferences = 0;

            for (int i = 0; i < AdapterInts.Count - 1; i++)
            {
                var difference = AdapterInts[i + 1] - AdapterInts[i];

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

        public object GetNumberOfArrangements()
        {
            var paths = AdapterInts.ToDictionary(i => i, i => 0L);
            paths[0] = 1;

            foreach (var adapter in AdapterInts.Skip(1))
            {
                for (int i = 1; i < 4; i++)
                {
                    if (paths.ContainsKey(adapter - i))
                    {
                        paths[adapter] += paths[adapter - i];
                    }
                }
            }

            return paths[AdapterInts[^1]];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day05
{
    public static class BoardingPassDecoder
    {
        public static List<int> Decode(string[] boardingPasses)
        {
            var seatIds = new List<int>();

            foreach (var boardingPass in boardingPasses)
            {
                var currentRowRange = Enumerable.Range(0, 128).ToList();
                var currentColumnRange = Enumerable.Range(0, 8).ToList();

                foreach (var code in boardingPass)
                {
                    var currentRowRangeCount = currentRowRange.Count();
                    var currentColumnRangeCount = currentColumnRange.Count();

                    switch (code)
                    {
                        case 'F':
                            currentRowRange = currentRowRange.GetRange(0, currentRowRangeCount / 2);
                            break;
                        case 'B':
                            currentRowRange = currentRowRange.GetRange(currentRowRangeCount / 2, currentRowRangeCount / 2);
                            break;
                        case 'R':
                            currentColumnRange = currentColumnRange.GetRange(currentColumnRangeCount / 2, currentColumnRangeCount / 2);
                            break;
                        case 'L':
                            currentColumnRange = currentColumnRange.GetRange(0, currentColumnRangeCount / 2);
                            break;
                    }
                }

                var currentSeatId = (currentRowRange.First() * 8) + currentColumnRange.First();

                seatIds.Add(currentSeatId);
            }

            return seatIds;
        }

        public static int FindMissingSeatId(List<int> seatIds)
        {
            var orderedSeatIds = seatIds.OrderBy(x => x).ToArray();

            for (int i = 0; i < orderedSeatIds.Count(); i++)
            {
                var nextSeatIdExists = Array.IndexOf(orderedSeatIds, orderedSeatIds[i] + 1);

                if (nextSeatIdExists == -1)
                {
                    return orderedSeatIds[i] + 1;
                }
            }

            return 0;
        }
    }
}

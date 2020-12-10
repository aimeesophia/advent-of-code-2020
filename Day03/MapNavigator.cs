namespace Day03
{
    public class MapNavigator
    {
        public static ulong Navigate(string[] map, int x, int y)
        {
            var initialX = x;
            var initialY = y;
            ulong numberOfTreesEncountered = 0;

            while (y < map.Length)
            {
                char mapItem;

                if (x > map[y].Length - 1)
                {
                    var tempX = x - map[y].Length;

                    mapItem = map[y][tempX];

                    x = tempX + initialX;
                }
                else
                {
                    mapItem = map[y][x];

                    x += initialX;
                }

                if (mapItem == '#')
                {
                    numberOfTreesEncountered++;
                }

                y += initialY;
            }

            return numberOfTreesEncountered;
        }
    }
}

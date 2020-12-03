using NUnit.Framework;

namespace Day3.Tests
{
    public class Tests
    {
        private string[] _map;

        [SetUp]
        public void Setup()
        {
            _map = new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
        }

        [TestCase(1, 1, 2)]
        [TestCase(3, 1, 7)]
        [TestCase(5, 1, 3)]
        [TestCase(7, 1, 4)]
        [TestCase(1, 2, 2)]
        public void MapNavigate_Navigate_Returns_Number_Of_Trees_Encountered(int x, int y, int expectedResult)
        {
            // Act
            var actualResult = MapNavigator.Navigate(_map, x, y);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
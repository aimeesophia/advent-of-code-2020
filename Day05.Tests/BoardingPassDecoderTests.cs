using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Day05.Tests
{
    public class BoardingPassDecoderTests
    {
        private string[] _boardingPasses;

        [SetUp]
        public void Setup()
        {
            _boardingPasses = File.ReadAllLines("Data/Data.txt");
        }

        [Test]
        public void BoardingPassDecoder_Decode_Returns_Seat_Ids()
        {
            // Arrange
            var expectedResult = new List<int>
            {
                567,
                119,
                820
            };

            // Act
            var actualResult = BoardingPassDecoder.Decode(_boardingPasses);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
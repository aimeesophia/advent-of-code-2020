using System.IO;
using NUnit.Framework;

namespace Day10.Tests
{
    public class AdapterArrayTests
    {
        private AdapterArray _adapterArray;

        [SetUp]
        public void Setup()
        {
            var adapterStrings = File.ReadAllLines("Data/Data.txt");
            _adapterArray = new AdapterArray(adapterStrings);
        }

        [Test]
        public void AdapterArray_GetJoltage_Returns_Joltage_Multiplier()
        {
            // Arrange
            var expectedResult = 220;

            // Act
            var actualResult = _adapterArray.GetJoltage();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AdapterArray_GetNumberOfArrangements_Returns_Joltage_Multiplier()
        {
            // Arrange
            var expectedResult = 19208;

            // Act
            var actualResult = _adapterArray.GetNumberOfArrangements();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
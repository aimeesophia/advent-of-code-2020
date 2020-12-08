using System.IO;
using NUnit.Framework;

namespace Day8.Tests
{
    public class BootLoaderTests
    {
        private string[] _bootInstructions;

        [SetUp]
        public void Setup()
        {
            _bootInstructions = File.ReadAllLines("Data/Data.txt");
        }

        [Test]
        public void BootLoader_GetAccumulatorValueBeforeInfiniteLoop_Returns_Value_Of_Accumulator_Before_Second_Execution()
        {
            // Arrange
            var expectedResult = 5;

            // Act
            var actualResult = BootLoader.GetAccumulatorValueBeforeInfiniteLoop(_bootInstructions);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
using System.Collections.Generic;
using System.IO;
using Day8.Enums;
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
            var expectedResult = new Dictionary<EvaluatedInstructions, int>
            {
                { EvaluatedInstructions.UnsuccessfulRunAccumulator, 5 },
                { EvaluatedInstructions.SuccessfulRunAccumulator, 8 }
            };

            // Act
            var actualResult = BootLoader.EvaluateInstructions(_bootInstructions);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
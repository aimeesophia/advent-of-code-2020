using System.IO;
using Day06.Enums;
using NUnit.Framework;

namespace Day06.Tests
{
    public class CustomsCalculatorTests
    {
        private string[] _customsAnswersInput;

        [SetUp]
        public void Setup()
        {
            _customsAnswersInput = File.ReadAllLines("Data/Data.txt");
        }

        [TestCase(CalculationType.QuestionsAnyoneAnswered, 11)]
        [TestCase(CalculationType.QuestionsEveryoneAnswered, 6)]
        public void CustomsCalculator_Returns_Number_Of_Questions_Answered(CalculationType calculationType, int expectedResult)
        {
            // Act
            var actualResult = CustomsCalculator.Calculate(calculationType, _customsAnswersInput);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
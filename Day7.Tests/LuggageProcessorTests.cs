using System.IO;
using Day7.Enums;
using NUnit.Framework;

namespace Day7.Tests
{
    public class LuggageProcessorTests
    {
        private string[] _luggageRules;

        [SetUp]
        public void Setup()
        {
            _luggageRules = File.ReadAllLines("Data/Data.txt");
        }

        [TestCase(LuggageProcessorType.TotalNumberOfBagsThatCanEventuallyContainSpecificBagColour, 4)]
        [TestCase(LuggageProcessorType.TotalNumberOfBagsContainedWithinSpecificBagColour, 32)]
        public void LuggageProcessor_Process_Returns_List_Of_Bag_Colours(LuggageProcessorType luggageProcessorType, int expectedResult)
        {
            // Act
            var actualResult = LuggageProcessor.ProcessRules(_luggageRules, "shiny gold", luggageProcessorType);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
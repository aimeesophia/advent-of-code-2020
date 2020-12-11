using System.Collections.Generic;
using Day02.Enums;
using NUnit.Framework;

namespace Day02.Tests
{
    public class PasswordValidatorTests
    {
        private List<string> _passwordDatabaseList;

        [SetUp]
        public void Setup()
        {
            _passwordDatabaseList = new List<string>
            {
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc"
            };
        }

        [TestCase(ValidationType.MinMaxAmountOfRequiredCharacter, 2)]
        [TestCase(ValidationType.PositionOfRequiredCharacter, 1)]
        public void PasswordValidator_Validate_Returns_Number_Of_Valid_Passwords(ValidationType validationType, int expectedNumberOfValidPasswords)
        {
            // Act
            var actualNumberOfValidPasswords = PasswordValidator.Validate(validationType, _passwordDatabaseList);

            // Assert
            Assert.AreEqual(expectedNumberOfValidPasswords, actualNumberOfValidPasswords);
        }
    }
}
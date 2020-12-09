using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Day9.Tests
{
    public class XMASDecoderTests
    {
        private string[] _numberStrings;

        [SetUp]
        public void Setup()
        {
            _numberStrings = File.ReadAllLines("Data/Data.txt");
        }

        [Test]
        public void XMASDecoder_Decode_Returns_First_Number_That_Is_Not_The_Sum_Of_Two_Of_The_Previous_5_Numbers_Before_It()
        {
            // Arrange
            var expectedResult = new KeyValuePair<ulong, ulong>(127, 62);

            // Act
            var actualResult = XMASDecoder.Decode(_numberStrings, 5);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
using Xunit;
using RomanNumeralKata.Services;
namespace RomanNumeralKata.Services.Tests
{
    public class RomanNumeralGeneratorTests
    {
        [Fact]
        public void WhenOneIsProvided_ThenTheCorrectSymbolIsReturned()
        {
            // Arrange
            var expected = "I";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(1);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenTwoIsProvided_ThenTheCorrectSymbolIsReturned()
        {
            // Arrange
            var expected = "II";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(2);

            // Assert
            Assert.Equal(actual, expected);
        }
    }
}

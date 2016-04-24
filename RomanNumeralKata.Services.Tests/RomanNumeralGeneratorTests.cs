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

        [Fact]
        public void WhenFiveIsProvided_ThenTheCorrectSymbolIsReturned()
        {
            // Arrange
            var expected = "V";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(5);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenTenIsProvided_ThenTheCorrectSymbolIsReturned()
        {
            // Arrange
            var expected = "X";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(10);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenAValueCanContainFourOfTheSameSymbol_ThenTheNextSymbolReplacesTheFourth()
        {
            // Arrange
            var expected = "IV";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(4);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenALargerNumberIsSubstituted_ThenTheNextSymbolReplacesTheFourth()
        {
            // Arrange
            var expected = "IX";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(9);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenALargeNumberIsCalculated_ThenACorrectResultShouldbeReturned()
        {
            // Arrange
            var expected = "MMMCMXCIX";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(3999);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void WhenANumberOver3999IsProvided_ThenAnErrorMessageIsReturned()
        {
            // Arrange
            var expected = "Please enter a number less than 3999";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(4000);

            // Assert
            Assert.Equal(actual, expected);
        }
    }
}

using Xunit;
using RomanNumeralKata.Services;
namespace RomanNumeralKata.Services.Tests
{
    public class RomanNumeralGeneratorTests
    {
        [Fact]
        public void WhenScanningAnItem_ThenTheTotalPriceShouldBeCorrectlyUpdated()
        {
            // Arrange
            var expected = "I";
            var service = new RomanNumeralGeneratorService();

            // Act
            var actual = service.Generate(1);

            // Assert
            Assert.Equal(actual, expected);
        }
    }
}

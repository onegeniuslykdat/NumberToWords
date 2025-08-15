using App.Services;
using App.Services.Extensions;
using App.Services.Model;
using Moq;

namespace App.Tests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("Dollar", 3)]
        [InlineData("Cent", 90)]
        public void CheckPluralOfWordEndingWithConsonant(string word, long quantity)
        {
            // Act
            var result = word.GetQuantityTextForm(quantity);

            // Assert
            Assert.True(char.Equals(char.ToLower(result[^1]), 's'));
        }
        [Theory]
        [InlineData("naira", 30)]
        public void CheckPluralOfWordEndingWithA(string word, long quantity)
        {
            // Act
            var result = word.GetQuantityTextForm(quantity);

            // Assert
            Assert.True(string.Equals(result, word, StringComparison.InvariantCultureIgnoreCase));
        }
        [Theory]
        [InlineData("kobo")]
        public void CheckPluralAndSingularOfKoboIsSame(string word)
        {
            // Act
            var resultPlural = word.GetQuantityTextForm(10);
            var resultSingular = word.GetQuantityTextForm(1);

            // Assert
            Assert.True(string.Equals(resultSingular, resultPlural, StringComparison.InvariantCultureIgnoreCase));
            Assert.True(string.Equals(resultSingular, word, StringComparison.InvariantCultureIgnoreCase));
            Assert.True(string.Equals(word, resultPlural, StringComparison.InvariantCultureIgnoreCase));
        }
        [Theory]
        [InlineData("Dollar", 1)]
        [InlineData("Pound", 100)]
        [InlineData("Cent", 50)]
        public void CheckQuantityDeterminesPluralOrSingular(string word, long quantity)
        {
            // Act
            var result = word.GetQuantityTextForm(quantity);

            // Assert
            if(quantity > 1)
            {
                Assert.True(char.Equals(char.ToLower(result[^1]), 's'));
            } else
            {
                Assert.True(string.Equals(result, word, StringComparison.InvariantCultureIgnoreCase));
            }
            
        }


    }
}
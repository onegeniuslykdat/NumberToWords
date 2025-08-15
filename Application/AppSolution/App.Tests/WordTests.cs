using App.Services;
using Moq;

namespace App.Tests
{
    public class WordTests
    {
        private readonly IWordServices wordService;
        public static IEnumerable<object[]> GetSampleWords() {
            yield return new object[] { new List<string> { "Seven Hundred and Twenty", "Four Hundred Thousand", "Nine million" } };
        }
        public WordTests()
        {
            var dataServicesMock = new Mock<IDataServices>();
            dataServicesMock.Setup(d => d.GetCurrencies()).Returns(new TestData().Currencies);
            dataServicesMock.Setup(d => d.GetNumbers()).Returns(new TestData().Numbers);
            wordService = new WordServices(dataServicesMock.Object);
        }
        [Theory]
        [InlineData(0, "")]
        [InlineData(12, "Twelve")]
        [InlineData(10, "Ten")]
        [InlineData(20, "Twenty")]
        [InlineData(145, "One Hundred and Forty-Five")]
        [InlineData(999, "Nine Hundred and Ninety-Nine")]
        public void CheckBasicNumbersAndWordsMatch(int digit, string word)
        {
            // Act
            var result = wordService.GetWordForNumber(digit).Result;

            // Assert
            Assert.True(string.Equals(result, word, StringComparison.InvariantCultureIgnoreCase));
        }
        [Theory]
        [InlineData(0, "")]
        [InlineData(3, "Thousand")]
        [InlineData(6, "Million")]
        [InlineData(9, "Billion")]
        public void CheckTagCanBeGotten(int tag, string tagWord)
        {
            // Act
            var result = wordService.GetWordForBaseTag(tag).Result;

            // Assert
            Assert.True(result == tagWord);
        }
        [Theory]
        [MemberData(nameof(GetSampleWords))]
        public void CheckWordsCanBeCombined(List<string> words)
        {
            // Act
            var result = wordService.GetCombinedWords(words);

            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
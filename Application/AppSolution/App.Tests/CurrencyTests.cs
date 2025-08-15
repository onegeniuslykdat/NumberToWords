using App.Services;
using App.Services.Model;
using Moq;

namespace App.Tests
{
    public class CurrencyTests
    {
        private readonly ICurrencyServices currencyService;
        public CurrencyTests()
        {
            var dataServicesMock = new Mock<IDataServices>();
            dataServicesMock.Setup(d => d.GetCurrencies()).Returns(new TestData().Currencies);
            currencyService = new CurrencyServices(dataServicesMock.Object);
        }
        [Fact]
        public void CheckCurrenciesAreAvailable()
        {
            // Act
            var result = currencyService.GetCurrencies().Result;

            // Assert
            Assert.NotNull(result);
        }
        [Theory]
        [InlineData("AUD")]
        [InlineData("NGN")]
        [InlineData("USD")]
        public void CheckCurrencyWithCodeIsAvailable(string code)
        {
            // Act
            var result = currencyService.GetCurrencyByCode(code).Result;

            // Assert
            Assert.True(result.Code == code);
        }
    }
}
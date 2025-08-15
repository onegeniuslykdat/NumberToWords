using App.Services;
using App.Services.Model;
using Moq;

namespace App.Tests
{
    public class DataTests
    {
        private readonly IDataServices dataService;
        public DataTests()
        {
            var dataServicesMock = new Mock<IDataServices>();
            dataServicesMock.Setup(d => d.GetCurrencies()).Returns(new TestData().Currencies);
            dataServicesMock.Setup(d => d.GetNumbers()).Returns(new TestData().Numbers);
            dataService = dataServicesMock.Object;
        }
        [Fact]
        public void CheckCurrenciesCanBeGotten()
        {
            // Act
            var result = dataService.GetCurrencies();

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void CheckNumbersCanBeGotten()
        {
            // Act
            var result = dataService.GetNumbers();

            // Assert
            Assert.NotNull(result);
        }
    }
}
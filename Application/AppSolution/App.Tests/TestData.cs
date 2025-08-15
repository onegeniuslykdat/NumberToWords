using App.Services.Data;
using App.Services.Model;

namespace App.Tests
{
    class TestData
    {
        public Dictionary<string, Currency> Currencies { get; set; } = AppData.currencies;

        public Dictionary<long, Number> Numbers { get; set; } = AppData.numbers;
    }
}

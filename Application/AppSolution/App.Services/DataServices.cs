using App.Services.Data;
using App.Services.Model;

namespace App.Services
{
    public class DataServices : IDataServices
    {
        public Dictionary<string, Currency> GetCurrencies()
        {
            var result = AppData.currencies;

            if(result != null)
            {
                return result;
            } else
            {
                return [];
            }
        }
        public Dictionary<long, Number> GetNumbers()
        {
            var result = AppData.numbers;

            if (result != null)
            {
                return result;
            }
            else
            {
                return [];
            }
        }
    }
}

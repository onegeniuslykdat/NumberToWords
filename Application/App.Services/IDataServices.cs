using App.Services.Model;

namespace App.Services
{
    public interface IDataServices
    {
        public Dictionary<string, Currency> GetCurrencies();
        public Dictionary<long, Number> GetNumbers();
    }
}

using App.Services.DTO;
using App.Services.Model;

namespace App.Services
{
    public interface ICurrencyServices
    {
        public ResultDTO<Currency[]> GetCurrencies();
        public ResultDTO<Currency> GetCurrencyByCode(string code);
    }
}

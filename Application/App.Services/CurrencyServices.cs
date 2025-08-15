using App.Services.DTO;
using App.Services.Model;

namespace App.Services
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly IDataServices dataServices;
        public CurrencyServices(IDataServices _dataServices)
        {
            dataServices = _dataServices;
        }
        public ResultDTO<Currency[]> GetCurrencies()
        {
            try
            {
                var result = dataServices.GetCurrencies().Select(c => new Currency()
                {
                    Code = c.Key,
                    Country = c.Value.Country,
                    MajorName = c.Value.MajorName,
                    MinorName = c.Value.MinorName
                }).ToArray();
                return new ResultDTO<Currency[]> {
                    Result = result!,
                    IsSuccess = true,

                };
            }
            catch (Exception)
            {
                return new ResultDTO<Currency[]>
                {
                    IsSuccess = false,
                    ErrorMessage = "Could  not retrieve currencies"
                };
            }
        }
        public ResultDTO<Currency> GetCurrencyByCode(string code)
        {
            try
            {
                var result = dataServices.GetCurrencies()[code];
                return new ResultDTO<Currency>
                {
                    Result = result,
                    IsSuccess = true
                };
            }
            catch (Exception)
            {
                return new ResultDTO<Currency>
                {
                    IsSuccess = false,
                    ErrorMessage = $"Could not retrieve currency for this code: {code}"
                };
            }
        }
    }
}

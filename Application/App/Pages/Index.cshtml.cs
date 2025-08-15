using App.Services;
using App.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;
    private readonly IConfiguration config;
    private readonly ICurrencyServices currencyServices;

    [BindProperty]
    public string? ErrorMsg { set; get; }

    [BindProperty]
    public string? Result { set; get; } = String.Empty;

    [BindProperty]
    [TempData]
    public string? CurrencyCode { set; get; }

    [BindProperty]
    public double Number { set; get; }

    public List<SelectListItem> CurrencyOptions { set; get; } = new List<SelectListItem>();

    public IndexModel(ILogger<IndexModel> _logger, IConfiguration _config, ICurrencyServices _currencyServices)
    {
        logger = _logger;
        config = _config;
        currencyServices = _currencyServices;
    }

    public void OnGet()
    {
        LoadData();
    }

    public IActionResult OnPost()
    {
        if(ModelState.IsValid)
        {
            var currency = currencyServices.GetCurrencyByCode(CurrencyCode!).Result;
            Result = GenerateWord(currency!, Number);
            LoadData();
            return Page();
        } else
        {
            return Page();
        }
    }

    private string GenerateWord(Currency currency, double number)
    {
        return $"Worked - {number}";
    }

    private void LoadData()
    {
        var result = currencyServices.GetCurrencies();
        if (result.Result!.Any())
        {
            var currencies = result.Result!;

            foreach (var currency in currencies)
            {
                if (string.Equals(currency.Country, config["Home"], StringComparison.InvariantCultureIgnoreCase))
                {
                    CurrencyOptions.Add(new SelectListItem($"{currency.MajorName} ({currency.Code})", currency.Code, true));
                }
                else
                {
                    CurrencyOptions.Add(new SelectListItem($"{currency.MajorName} ({currency.Code})", currency.Code, false));
                }
            }
        }
        else
        {
            ErrorMsg = result!.ErrorMessage;
        }
    }
}

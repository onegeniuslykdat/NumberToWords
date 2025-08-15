using App.Services;
using App.Services.Extensions;
using App.Services.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace App.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> logger;
    private readonly IConfiguration config;
    private readonly ICurrencyServices currencyServices;
    private readonly IWordServices wordServices;

    [BindProperty]
    public string? ErrorMsg { set; get; }

    [BindProperty]
    public string? Result { set; get; } = String.Empty;

    [BindProperty]
    public string? CurrencyCode { set; get; }

    [BindProperty]
    public double Number { set; get; }

    public List<SelectListItem> CurrencyOptions { set; get; } = new List<SelectListItem>();

    public IndexModel(ILogger<IndexModel> _logger, IConfiguration _config, ICurrencyServices _currencyServices, IWordServices _wordServices)
    {
        logger = _logger;
        config = _config;
        currencyServices = _currencyServices;
        wordServices = _wordServices;
    }

    public void OnGet()
    {
        LoadData();
    }

    public async Task<IActionResult> OnPost()
    {
        if(ModelState.IsValid)
        {
            var currency = currencyServices.GetCurrencyByCode(CurrencyCode!).Result;
            Result = await GenerateWord(currency!, Number);
        }

        LoadData();
        return Page();
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

    public async Task<string> GenerateWord(Currency currency, double number)
    {
        StringBuilder resultBuilder = new StringBuilder();

        // split number based on decimal point
        string[] wholeAndFraction = number.ToString("F2").Split('.');
        int fraction = int.Parse(wholeAndFraction[1]);
        long whole = long.Parse(wholeAndFraction[0]);

        // convert concurrently
        Task<string> taskFraction = Task.Run(() => {
            string words = $"{wordServices.GetWordForNumber(fraction).Result!} {currency.MinorName!.GetQuantityTextForm(fraction)}";
            return words;
        });
        Task<string> taskWhole = Task.Run(() => {
            int startTag = 0;
            long quotient = whole;
            List<string> wordsList = new List<string>();
            while (quotient > 0)
            {
                int remainder = (int)(quotient % 1000);
                quotient /= 1000;
                string? tagWord = wordServices.GetWordForBaseTag(startTag).Result;
                StringBuilder wordBuilder = new StringBuilder(wordServices.GetWordForNumber(remainder).Result!);
                if (wordBuilder.Length > 0)
                {
                    if(!string.IsNullOrWhiteSpace(tagWord))
                    {
                        wordBuilder.Append($" {tagWord}");
                    }
                    wordsList.Add(wordBuilder.ToString());
                }                
                startTag += 3;
            }
            string words = $"{wordServices.GetCombinedWords(wordsList).Result!} {currency.MajorName!.GetQuantityTextForm(whole)}";

            return words;
        });

        // combine results
        string[] results = await Task.WhenAll(taskWhole, taskFraction);
        if (whole > 0 && fraction > 0)
        {
            resultBuilder.Append($"{results[0]} and {results[1]}");
        } else if (whole > 0 && fraction == 0)
        {
            resultBuilder.Append($"{results[0]}");
        } else
        {
            resultBuilder.Append($"{results[1]}");
        }
        
        return resultBuilder.ToString();
    }
}

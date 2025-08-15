using App.Services.DTO;
using System.Text;

namespace App.Services
{
    public class WordServices : IWordServices
    {
        private readonly IDataServices dataServices;
        public WordServices(IDataServices _dataServices)
        {
            dataServices = _dataServices;
        }
        public ResultDTO<string> GetWordForNumber(int number)
        {
            try
            {
                StringBuilder resultBuilder = new StringBuilder();
                if (number == 0)
                {
                    return new ResultDTO<string>
                    {
                        IsSuccess = true,
                        Result = String.Empty
                    };
                } else
                {
                    int remainderFromHundred = number % 100;
                    if (number > 99)
                    {
                        int hundreds = (number - remainderFromHundred) / 100;
                        string hundredsWord = $"{dataServices.GetNumbers()[hundreds].Words!} Hundred";
                        if(remainderFromHundred > 0)
                        {
                            resultBuilder.Append($"{hundredsWord} and ");
                        } else
                        {
                            resultBuilder.Append($"{hundredsWord}");
                        }                        
                    }
                    int remainderFromTen = remainderFromHundred % 10;
                    if (remainderFromHundred > 20 && remainderFromTen > 0)
                    {
                        int tens = remainderFromHundred - remainderFromTen;
                        string tensWord = $"{dataServices.GetNumbers()[tens].Words!}";
                        string unitsWord = $"{dataServices.GetNumbers()[remainderFromTen].Words!}";
                        resultBuilder.Append(tensWord);
                        resultBuilder.Append('-');
                        resultBuilder.Append(unitsWord);
                    }
                    else
                    {
                        if(remainderFromHundred > 0)
                        {
                            string tensWord = dataServices.GetNumbers()[remainderFromHundred].Words!;
                            resultBuilder.Append(tensWord);
                        }
                    }
                }
                return new ResultDTO<string>
                {
                    Result = resultBuilder.ToString(),
                    IsSuccess = true,

                };
            }
            catch (Exception)
            {
                return new ResultDTO<string>
                {
                    IsSuccess = false,
                    ErrorMessage = $"Could not retrieve word for this number: {number}"
                };
            }
        }
        public ResultDTO<string> GetWordForBaseTag(int tag)
        {
            try
            {
                if(tag == 0)
                {
                    return new ResultDTO<string>
                    {
                        IsSuccess = true,
                        Result = String.Empty
                    };
                }
                var result = dataServices.GetNumbers().FirstOrDefault(n => n.Value.BaseTag.HasValue && n.Value.BaseTag == tag).Value.Words;
                return new ResultDTO<string>
                {
                    Result = result!,
                    IsSuccess = true,

                };
            }
            catch (Exception)
            {
                return new ResultDTO<string>
                {
                    IsSuccess = false,
                    ErrorMessage = $"Could not retrieve word for this tag: {tag}"
                };
            }
        }
        public ResultDTO<string> GetCombinedWords(List<string> words, bool reverseOrder = true)
        {
            try
            {
                StringBuilder resultBuilder = new StringBuilder("");
                if(reverseOrder)
                {
                    words.Reverse();
                }
                for(int i = 0; i < words.Count; i++)
                {
                    resultBuilder.Append(words[i]);
                    if(i + 1 == words.Count - 1)
                    {
                        resultBuilder.Append(" and ");
                    }
                    if (i + 2 <= words.Count - 1)
                    {
                        resultBuilder.Append(", ");
                    }
                }
                return new ResultDTO<string>
                {
                    Result = resultBuilder.ToString(),
                    IsSuccess = true,

                };
            }
            catch (Exception)
            {
                return new ResultDTO<string>
                {
                    IsSuccess = false,
                    ErrorMessage = $"Could not combine words"
                };
            }
        }
    }
}

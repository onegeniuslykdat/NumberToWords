using App.Services.DTO;

namespace App.Services
{
    public interface IWordServices
    {
        public ResultDTO<string> GetWordForNumber(int number);
        public ResultDTO<string> GetWordForBaseTag(int tag);
        public ResultDTO<string> GetCombinedWords(List<string> words, bool reverseOrder = true);
    }
}

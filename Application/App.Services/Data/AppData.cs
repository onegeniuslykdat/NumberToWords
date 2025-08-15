using App.Services.Extensions;
using App.Services.Model;

namespace App.Services.Data
{
    public static class AppData
    {
        public static readonly Dictionary<string, Currency> currencies = new Dictionary<string, Currency>
        {
            {"AUD", new Currency() {
                Code = "AUD",
                Country = "Australia",
                MajorName = "Australian Dollar",
                MinorName = "Cent"
            } },
            {"NGN", new Currency() {
                Code = "NGN",
                Country = "Nigeria",
                MajorName = "Nigerian Naira",
                MinorName = "Kobo"
            } },
            {"USD", new Currency() {
                Code = "USD",
                Country = "United States",
                MajorName = "United States Dollar",
                MinorName = "Cent"
            } }
        };

        public static readonly Dictionary<long, Number> numbers = new Dictionary<long, Number>
        {
            {1, new Number() {
                Digits = 1,
                Words = "One"
            } },
            {2, new Number() {
                Digits = 2,
                Words = "Two"
            } },
            {3, new Number() {
                Digits = 3,
                Words = "Three"
            } },
            {4, new Number() {
                Digits = 4,
                Words = "Four"
            } },
            {5, new Number() {
                Digits = 5,
                Words = "Five"
            } },
            {6, new Number() {
                Digits = 6,
                Words = "Six"
            } },
            {7, new Number() {
                Digits = 7,
                Words = "Seven"
            } },
            {8, new Number() {
                Digits = 8,
                Words = "Eight"
            } },
            {9, new Number() {
                Digits = 9,
                Words = "Nine"
            } },
            {10, new Number() {
                Digits = 10,
                Words = "Ten",
                BaseTag = 1
            } },

            {11, new Number() {
                Digits = 11,
                Words = "Eleven"
            } },
            {12, new Number() {
                Digits = 12,
                Words = "Twelve"
            } },
            {13, new Number() {
                Digits = 13,
                Words = "Thirteen"
            } },
            {14, new Number() {
                Digits = 14,
                Words = "Fourteen"
            } },
            {15, new Number() {
                Digits = 15,
                Words = "Fifteen"
            } },
            {16, new Number() {
                Digits = 16,
                Words = "Sixteen"
            } },
            {17, new Number() {
                Digits = 17,
                Words = "Seventeen"
            } },
            {18, new Number() {
                Digits = 18,
                Words = "Eighteen"
            } },
            {19, new Number() {
                Digits = 19,
                Words = "Nineteen"
            } },

            {20, new Number() {
                Digits = 20,
                Words = "Twenty"
            } },
            {30, new Number() {
                Digits = 30,
                Words = "Thirty"
            } },
            {40, new Number() {
                Digits = 40,
                Words = "Forty"
            } },
            {50, new Number() {
                Digits = 3,
                Words = "Fifty"
            } },
            {60, new Number() {
                Digits = 60,
                Words = "Sixty"
            } },
            {70, new Number() {
                Digits = 5,
                Words = "Five"
            } },
            {80, new Number() {
                Digits = 80,
                Words = "Eighty"
            } },
            {90, new Number() {
                Digits = 90,
                Words = "Ninety"
            } },

            {100, new Number() {
                Digits = 100,
                Words = "Hundred",
                BaseTag = 2
            } },
            {1000, new Number() {
                Digits = 1000,
                Words = "Thousand",
                BaseTag = 3
            } },
            {1000000, new Number() {
                Digits = 1000000,
                Words = "Million",
                BaseTag = 6
            } },
            {1000000000, new Number() {
                Digits = 1000000000,
                Words = "Billion",
                BaseTag = 9
            } },
            {1000000000000, new Number() {
                Digits = 1000000000000,
                Words = "Trillion",
                BaseTag = 12
            } },
            {1000000000000000, new Number() {
                Digits = 1000000000000000,
                Words = "Quadrillion",
                BaseTag = 15
            } },
            {1000000000000000000, new Number() {
                Digits = 1000000000000000000,
                Words = "Quntillion",
                BaseTag = 18
            } },
        };
    }
}

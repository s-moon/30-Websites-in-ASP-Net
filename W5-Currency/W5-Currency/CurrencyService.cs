using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using W5_Currency.CurrencyConverter;

namespace W5_Currency
{
    public class CurrencyService
    {
        public double GetRate(string currencyA, string currencyB)
        {
            return GetRate(StringCurrencyToEnumCurrency(currencyA), StringCurrencyToEnumCurrency(currencyB));
        }

        public double ExchangeCurrency(int amountFrom, string currencyA, string currencyB)
        {
            return ExchangeCurrency(amountFrom, StringCurrencyToEnumCurrency(currencyA), StringCurrencyToEnumCurrency(currencyB));
        }

        private double GetRate(Currency currencyA, Currency currencyB)
        {
            var converter = new CurrencyConverter.CurrencyConvertorSoapClient();
            return converter.ConversionRate(currencyA, currencyB);
        }
        private double ExchangeCurrency(int amountFrom, Currency currencyA, Currency currencyB)
        {
            double rate = GetRate(currencyA, currencyB);
            return (double)amountFrom * rate;   
        }

        private Currency StringCurrencyToEnumCurrency(string currency)
        {
            return (Currency)Enum.Parse(typeof(Currency), currency);
        }
    }
}
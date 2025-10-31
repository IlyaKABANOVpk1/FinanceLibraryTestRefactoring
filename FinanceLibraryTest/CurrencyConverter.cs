using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    public class CurrencyConverter
    {
        private readonly ICurrencyRateProvider _rateProvider;
        private const string BaseCurrency = "USD";

        internal CurrencyConverter(ICurrencyRateProvider rateProvider)
        {
            _rateProvider = rateProvider ?? throw new ArgumentNullException(nameof(rateProvider));
        }

        public double Convert(string from, string to, double amount)
        {
            if (string.IsNullOrWhiteSpace(from)) throw new ArgumentException("Исходная валюта не указана.", nameof(from));
            if (string.IsNullOrWhiteSpace(to)) throw new ArgumentException("Целевая валюта не указана.", nameof(to));
            if (amount < 0) throw new ArgumentException("Сумма не может быть отрицательной.", nameof(amount));

            var rates = _rateProvider.GetCurrentRates();
            if (!rates.ContainsKey(from)) throw new KeyNotFoundException($"Валюта '{from}' не поддерживается.");
            if (!rates.ContainsKey(to)) throw new KeyNotFoundException($"Валюта '{to}' не поддерживается.");

            double amountInBase = amount / rates[from];
            double result = amountInBase * rates[to];
            return result;
        }

        public double CalculateCommission(double amount)
        {
            if (amount < 0) throw new ArgumentException("Сумма не может быть отрицательной.", nameof(amount));
            return amount * 0.01;
        }

        public IReadOnlyList<string> GetRatesHistory()
        {
            return _rateProvider.GetRatesHistory()
                .Select(x => $"{x.Date:yyyy-MM-dd} {x.Currency}: {x.Rate}")
                .ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    public class CurrencyConverter
    {
        private Dictionary<string, double> rates = new Dictionary<string, double>()
        {
            { "USD", 1.0 },
            { "EUR", 0.93 },
            { "RUB", 100.0 },
            { "GBP", 0.82 }
        };

        
        public double Convert(string from, string to, double amount)
        {
            if (!rates.ContainsKey(from) || !rates.ContainsKey(to))
            {
                throw new Exception("Неверная валюта");
            }

            double result = amount / rates[from] * rates[to];
            return result;
        }

        
        public double CalcCommission(double amount)
        {
            return amount * 0.01;
        }

        
        public List<string> GetRatesHistory()
        {
            List<string> history = new List<string>();
            history.Add("USD: 1.0");
            history.Add("EUR: 0.93");
            history.Add("RUB: 100.0");
            history.Add("GBP: 0.82");
            return history;
        }
    }
}

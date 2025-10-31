using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    internal interface ICurrencyRateProvider
    {
        IReadOnlyDictionary<string, double> GetCurrentRates();
        IEnumerable<(DateTime Date, string Currency, double Rate)> GetRatesHistory();
    }
}

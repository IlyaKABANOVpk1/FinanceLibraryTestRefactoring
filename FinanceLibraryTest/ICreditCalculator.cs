using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    public interface ICreditCalculator
    {
        double CalculateMonthlyPayment(CreditParameters parameters);
        double CalculateTotalOverpayment(CreditParameters parameters);
        IReadOnlyList<PaymentScheduleRow> GeneratePaymentSchedule(CreditParameters parameters);
    }
}

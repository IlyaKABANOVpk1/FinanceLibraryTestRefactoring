using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    public class CreditCalculator : ICreditCalculator
    {
        public double CalculateMonthlyPayment(CreditParameters parameters)
        {
            double r = parameters.AnnualRate / 12 / 100;
            if (Math.Abs(r) < double.Epsilon) return parameters.Amount / parameters.Months;

            double power = Math.Pow(1 + r, parameters.Months);
            return parameters.Amount * r * power / (power - 1);
        }

        public double CalculateTotalOverpayment(CreditParameters parameters)
        {
            double monthly = CalculateMonthlyPayment(parameters);
            double totalPaid = monthly * parameters.Months;
            return totalPaid - parameters.Amount;
        }

        public IReadOnlyList<PaymentScheduleRow> GeneratePaymentSchedule(CreditParameters parameters)
        {
            var schedule = new List<PaymentScheduleRow>();
            double monthly = CalculateMonthlyPayment(parameters);
            double remaining = parameters.Amount;

            for (int i = 1; i <= parameters.Months; i++)
            {
                double interest = remaining * parameters.AnnualRate / 12 / 100;
                double principal = monthly - interest;
                remaining -= principal;

                schedule.Add(new PaymentScheduleRow(i, monthly, principal, interest, remaining));
            }

            return schedule;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    public readonly struct PaymentScheduleRow
    {
        public int Month { get; }
        public double Payment { get; }
        public double Principal { get; }
        public double Interest { get; }
        public double RemainingBalance { get; }

        public PaymentScheduleRow(int month, double payment, double principal, double interest, double remainingBalance)
        {
            Month = month;
            Payment = payment;
            Principal = principal;
            Interest = interest;
            RemainingBalance = remainingBalance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceLibraryTest
{
    public readonly struct CreditParameters
    {
        public double Amount { get; }
        public double AnnualRate { get; }
        public int Months { get; }

        public CreditParameters(double amount, double annualRate, int months)
        {
            if (amount <= 0) throw new ArgumentException("Сумма кредита должна быть положительной.", nameof(amount));
            if (annualRate < 0) throw new ArgumentException("Годовая ставка не может быть отрицательной.", nameof(annualRate));
            if (months <= 0) throw new ArgumentException("Срок кредита должен быть положительным.", nameof(months));

            Amount = amount;
            AnnualRate = annualRate;
            Months = months;
        }
    }
}

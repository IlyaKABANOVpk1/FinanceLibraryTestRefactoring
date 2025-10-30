namespace FinanceLibraryTest
{
    public class CreditCalculator
    {
        
        public double CalcMonthlyPayment(double amount, double rate, int months)
        {
            
            double r = rate / 12 / 100;
            double m = months;
            double pay = amount * r * Math.Pow(1 + r, m) / (Math.Pow(1 + r, m) - 1);
            return pay;
        }

        
        public double CalcOverpay(double amount, double rate, int months)
        {
            double monthly = CalcMonthlyPayment(amount, rate, months);
            double total = monthly * months;
            double overpay = total - amount;
            return overpay;
        }

        
        public void PaymentSchedule(double amount, double rate, int months)
        {
            double monthly = CalcMonthlyPayment(amount, rate, months);
            double remaining = amount;

            Console.WriteLine("Месяц\tПлатеж\tОсновной долг\tПроценты\tОстаток");
            for (int i = 1; i <= months; i++)
            {
                double interest = remaining * rate / 12 / 100;
                double principal = monthly - interest;
                remaining -= principal;

                Console.WriteLine($"{i}\t{monthly:F2}\t{principal:F2}\t{interest:F2}\t{remaining:F2}");
            }
        }
    }
}

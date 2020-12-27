using System;
using laba5.Exceptions;

namespace laba5.Accounts
{
    public class DebitAccount : IAccount
    {
        public double Persentage { get; }
        private double _profit = 0;

        public DebitAccount(int id, int balance, double persentage) : base(id, balance)
        {
            Persentage = persentage;
        }

        public void CalculateDayProfit() => _profit += Balance * Persentage / 365;
        
        public void PayProfit()
        {
            Balance += (int)_profit;
            _profit = 0;
        }

        public override bool IsWithdrawAvaliable(int sum) => Balance >= sum;
        public override void TransferTime(DateTime newDate)
        {
            if (newDate < LastPayDate)
                throw new WrongDate( $"{newDate} was earlier than the last withdrawal date {LastPayDate}");
            DateTime currentDate = LastPayDate.Date;
            newDate = newDate.Date;
            while (currentDate != newDate)
            {
                if (currentDate.AddDays(1).Day == 1)
                    PayProfit();
                

                CalculateDayProfit();
                currentDate = currentDate.AddDays(1);
            }

            LastPayDate = currentDate;
        }

        public override int CalcNewSum(int sum)
        {
            return sum;
        }
    }
}
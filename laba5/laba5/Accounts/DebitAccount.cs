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

        public override void CalculateDayProfit()
        {
            _profit += Balance * Persentage / 365 / 100;   
        }
        public override int PayProfit()
        {
            var profitPay = _profit;
            _profit = 0;
            return (int) profitPay;
        }

        public override void ClearProfit()
        {
            _profit = 0;
        }

        public override bool IsWithdrawAvaliable(int sum)
        {
            return Balance >= sum;
        }

        public override int CalcNewSum(int sum)
        {
            return sum;
        }
    }
}